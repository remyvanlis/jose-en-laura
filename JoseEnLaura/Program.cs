using Microsoft.EntityFrameworkCore;
using JoseEnLaura.Components;
using JoseEnLaura.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<WeddingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")));

builder.Services.AddHttpClient();

var app = builder.Build();
// Auto-migrate database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WeddingDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

// Serve site images from DB
app.MapGet("/api/site-image/{slot}", async (string slot, IDbContextFactory<WeddingDbContext> dbFactory) =>
{
    await using var db = await dbFactory.CreateDbContextAsync();
    var image = await db.SiteImages.FirstOrDefaultAsync(i => i.Slot == slot);
    if (image is null)
        return Results.NotFound();
    return Results.File(image.Data, image.ContentType, image.FileName);
});

// Serve planning attachments
app.MapGet("/api/planning-attachment/{id:int}", async (int id, IDbContextFactory<WeddingDbContext> dbFactory) =>
{
    await using var db = await dbFactory.CreateDbContextAsync();
    var attachment = await db.PlanningAttachments.FindAsync(id);
    if (attachment is null)
        return Results.NotFound();
    return Results.File(attachment.Data, attachment.ContentType, attachment.FileName);
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
