var builder = WebApplication.CreateBuilder(args);

// controller width view
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");
app.Run();
