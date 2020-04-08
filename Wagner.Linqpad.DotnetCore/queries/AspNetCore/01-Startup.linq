<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

// ## 2020-04-05
// - `Startup`不是必须的，但使用Startup类可以使代码更加优雅
// - 一般情况下，在Startup类中我们使用Convention的来定义加入服务和中间件的方法。在AspNetCore框架中使用ConventionBasedStartup来加以解析
void Main()
{
	Host.CreateDefaultBuilder()
		.ConfigureAppConfiguration(builder =>
		{
			Console.WriteLine("ConfigureAppConfiguration");
		})
		.ConfigureServices(service =>
		{
			Console.WriteLine("ConfigureServices");
		})
		.ConfigureHostConfiguration(builder =>
		{
			Console.WriteLine("ConfigureHostConfiguration");
		})
		.ConfigureWebHostDefaults(

		webBuilder =>
		{
			Console.WriteLine("ConfigureWebHostDefaults");
			webBuilder.UseStartup<Startup>();
		})
		.Build()
		.Run();
}

// Define other methods, classes and namespaces here
public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Console.WriteLine("Startup.ctor");
	}
	public void ConfigureServices(IServiceCollection services)
	{
		Console.WriteLine("Startup.ConfigureServices");
	}
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		Console.WriteLine("Startup.Configure");
	}
}