<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	Host.CreateDefaultBuilder()
		.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().UseUrls("http://*:5000"))
		.Build()
		.Run();
}

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllersWithViews();
	}
	public void Configure(IApplicationBuilder app)
	{
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}"));
	}
}

public class HomeController : Controller
{
	ILogger _logger;
	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}
	public IActionResult Index()
	{
		return Content("<h1>title</h1>", "text/html");
	}
}