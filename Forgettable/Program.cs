using Forgettable.Data;
using Forgettable.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

// Create web application builder.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ForgettableDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Forgettable")));
builder.Services.Configure<PaperlessOptions>(builder.Configuration.GetSection("Paperless"));
builder.Services.AddHttpClient<PaperlessClient>();

// Sign in with Pocket ID; the cookie keeps me signed in for 30 days.
AuthenticationBuilder authentication = builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
});
authentication.AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});
authentication.AddOpenIdConnect(options =>
{
    builder.Configuration.GetSection("Oidc").Bind(options);
    options.ResponseType = "code";
    options.UsePkce = true;
    options.MapInboundClaims = false;
    options.TokenValidationParameters.NameClaimType = "name";
    options.Events.OnTicketReceived = context =>
    {
        context.Properties!.IsPersistent = true;
        return Task.CompletedTask;
    };
});

// Require a signed in user everywhere by default.
builder.Services.AddAuthorizationBuilder().SetFallbackPolicy(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

// Trust the Cloudflare Tunnel's forwarded headers so sign-in redirects use https.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

// Create the web application.
WebApplication app = builder.Build();

// Apply any pending database migrations.
using (IServiceScope scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ForgettableDbContext>().Database.Migrate();
}

// Configure the request pipeline.
app.UseForwardedHeaders();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets().AllowAnonymous();
app.MapRazorPages().WithStaticAssets();
app.MapGet("/paperless/thumbnail/{id:int}", async (int id, PaperlessClient paperless) => await paperless.GetThumbnailAsync(id) is byte[] content ? Results.File(content, "image/webp") : Results.NotFound());
app.Run();