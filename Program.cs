using aspnet_hotwire.Hubs;
using aspnet_hotwire.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
  endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

if (app.Environment.IsDevelopment())
{
  app.UseSpa(spa =>
    spa.UseProxyToSpaDevelopmentServer("http://localhost:5173/"));
}

app.MapHub<AppHub>("/appHub");
app.Run();
