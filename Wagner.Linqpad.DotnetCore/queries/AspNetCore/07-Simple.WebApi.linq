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
		services.AddControllers();
	}
	public void Configure(IApplicationBuilder app)
	{
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllers());
	}
}

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
	[HttpGet]
	public IEnumerable<int> Get()
	{
		return new[] { 1, 2, 3 };
	}
}