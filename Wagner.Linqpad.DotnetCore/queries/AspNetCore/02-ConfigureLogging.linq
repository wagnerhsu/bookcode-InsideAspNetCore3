<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.AspNetCore.Http</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	Host.CreateDefaultBuilder()
		.ConfigureLogging(builder => builder.AddConsole(options => options.IncludeScopes = true))
		.ConfigureWebHostDefaults(builder =>
		{
			builder.Configure(app =>
			{
				app.Run(context =>
				{
					var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("Main");
					logger.LogInformation("Log for event Foobar");
					if (context.Request.Path == new PathString("/error"))
					{
						throw new InvalidOperationException("Manually throw exception");
					}
					return Task.CompletedTask;
				});
			});
		})
		.Build()
		.Run();
}

// Define other methods, classes and namespaces here
