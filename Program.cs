using aspnet_hotwire.Hubs;
using aspnet_hotwire.Services;
using Vite.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
builder.Services.AddSignalR();
builder.Services.AddViteServices(options =>
{
	options.Server.AutoRun = true;
	options.Server.UseFullDevUrl = true;
});

var app = builder.Build();

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

app.MapHub<AppHub>("/appHub");
app.Run();
