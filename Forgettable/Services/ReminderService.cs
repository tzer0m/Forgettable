using Forgettable.Data;
using Forgettable.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using t0m.Ting;

namespace Forgettable.Services
{
    /// <summary>
    /// Sends a daily Ting notification listing everything due today or overdue that isn't booked or archived.
    /// </summary>
    /// <param name="scopeFactory">Creates a scope for the database context and Ting client on each run.</param>
    /// <param name="options">The reminder settings.</param>
    /// <param name="logger">The logger.</param>
    public partial class ReminderService(IServiceScopeFactory scopeFactory, IOptions<ReminderOptions> options, ILogger<ReminderService> logger) : BackgroundService
    {
        /// <summary>
        /// Waits until the reminder time each day, then sends the reminder.
        /// </summary>
        /// <param name="stoppingToken">Signals when the app is shutting down.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeUntilNextRun(), stoppingToken);
                try
                {
                    await SendReminderAsync(stoppingToken);
                }
                catch (Exception exception) when (exception is not OperationCanceledException)
                {
                    LogReminderFailed(logger, exception);
                }
            }
        }

        /// <summary>
        /// Sends one notification listing every item due today or overdue, if there are any.
        /// </summary>
        /// <param name="cancellationToken">Signals when the app is shutting down.</param>
        private async Task SendReminderAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = scopeFactory.CreateScope();
            ForgettableDbContext db = scope.ServiceProvider.GetRequiredService<ForgettableDbContext>();
            TingClient ting = scope.ServiceProvider.GetRequiredService<TingClient>();
            DateOnly today = DateOnly.FromDateTime(TimeZoneInfo.ConvertTime(DateTime.UtcNow, Zone));
            List<Item> items = await db.Items.AsNoTracking().Where(x => !x.Archived && !x.Booked).ToListAsync(cancellationToken);
            List<Item> due = [.. items.Where(x => x.DueDate <= today).OrderBy(x => x.DueDate)];
            int count = due.Count;
            if (count == 0)
            {
                return;
            }
            string title = count == 1 ? "Forgettable: 1 Item Due" : $"Forgettable: {count} Items Due";
            string body = string.Join("\n", due.Select(x => $"{x.Subject} - {ItemTypes.GetDisplayName(x.GetType())}: {Overdue(today.DayNumber - x.DueDate.DayNumber)}"));
            await ting.SendAsync(title, body);
            LogReminderSent(logger, count);
        }

        /// <summary>
        /// Logs that the daily reminder was sent.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="count">The number of items in the reminder.</param>
        [LoggerMessage(Level = LogLevel.Information, Message = "Sent the daily reminder for {Count} items")]
        private static partial void LogReminderSent(ILogger logger, int count);

        /// <summary>
        /// Logs that the daily reminder failed to send.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The error.</param>
        [LoggerMessage(Level = LogLevel.Error, Message = "Failed to send the daily reminder")]
        private static partial void LogReminderFailed(ILogger logger, Exception exception);

        /// <summary>
        /// Describes how many days overdue an item is, e.g. "Due Today" or "3 Days Overdue".
        /// </summary>
        /// <param name="days">The number of days past the due date.</param>
        private static string Overdue(int days)
        {
            return days switch { 0 => "Due Today", 1 => "1 Day Overdue", _ => $"{days} Days Overdue" };
        }

        /// <summary>
        /// Returns how long until the next reminder time in the configured time zone.
        /// </summary>
        private TimeSpan TimeUntilNextRun()
        {
            DateTime now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, Zone);
            DateTime next = now.Date + options.Value.Time.ToTimeSpan();
            if (next <= now)
            {
                next = next.AddDays(1);
            }
            return TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(next, DateTimeKind.Unspecified), Zone) - DateTime.UtcNow;
        }

        /// <summary>
        /// The configured time zone for the reminder time.
        /// </summary>
        private TimeZoneInfo Zone => TimeZoneInfo.FindSystemTimeZoneById(options.Value.TimeZone);
    }
}