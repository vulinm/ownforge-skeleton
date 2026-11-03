using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDb>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Internal only: the web container forwards just /api/*, so this is never reachable from outside.
app.MapGet("/healthz", async (AppDb db) =>
    await db.Database.CanConnectAsync() ? Results.Ok(new { status = "ok" }) : Results.StatusCode(503));

app.MapGet("/api/hello", async (AppDb db) =>
{
    var version = await db.Database.SqlQuery<string>($"select version() as \"Value\"").SingleAsync();
    return new { message = "Hello from the backend!", database = version };
});

app.Run();

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options);
