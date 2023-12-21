using aspnet_hotwire.Hubs;
using aspnet_hotwire.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "Views", "Foo", "Scripts")),
    RequestPath = "/foo-js"
});


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
