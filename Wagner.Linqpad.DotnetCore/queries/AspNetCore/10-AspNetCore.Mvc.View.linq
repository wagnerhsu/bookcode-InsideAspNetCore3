<Query Kind="Program">
  <NuGetReference>Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation</NuGetReference>
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var currentDir = Path.GetDirectoryName(Util.CurrentQueryPath);
	Host.CreateDefaultBuilder()
		.ConfigureWebHostDefaults(builder =>
		{
			builder.UseContentRoot(currentDir);
			builder.UseStartup<Startup>();
			builder.UseUrls("http://*:5000");
		})
		.Build()
		.Run();
}

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages().AddRazorRuntimeCompilation(sa =>
			   Util.Framework.GetReferenceAssemblies(true)
				   .Prepend(GetType().Assembly.Location)
				   .ToList()
				   .ForEach(sa.AdditionalReferencePaths.Add));
		services.AddControllersWithViews();
	}
	public void Configure(IApplicationBuilder app)
	{
		app.UseStaticFiles();
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}"));
	}
}
public class HomeController : Controller
{
	[HttpGet("/")]
	public ViewResult Index()
	{
		return View((object)"Hello");
	}
}