using Vite.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddViteServices(options =>
{
	options.Server.AutoRun = true;
	options.Server.UseFullDevUrl = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
	app.UseViteDevMiddleware();
}

app.Run();
