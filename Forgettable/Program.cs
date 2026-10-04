using Forgettable.Data;
using Forgettable.Services;
using Microsoft.EntityFrameworkCore;

// Create web application builder.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ForgettableDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Forgettable")));
builder.Services.Configure<PaperlessOptions>(builder.Configuration.GetSection("Paperless"));
builder.Services.AddHttpClient<PaperlessClient>();

// Create the web application and configure.
WebApplication app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
app.MapGet("/paperless/thumbnail/{id:int}", async (int id, PaperlessClient paperless) => await paperless.GetThumbnailAsync(id) is byte[] content ? Results.File(content, "image/webp") : Results.NotFound());
app.Run();