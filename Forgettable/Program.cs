using Forgettable.Data;
using Microsoft.EntityFrameworkCore;

// Create web application builder.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ForgettableDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Forgettable")));

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
app.Run();