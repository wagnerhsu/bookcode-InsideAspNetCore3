<Query Kind="Program">
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var logger = new ServiceCollection()
		.AddLogging(builder=>builder.AddConsole())
		.BuildServiceProvider()
		.GetRequiredService<ILoggerFactory>()
		.CreateLogger("Main");
	logger.LogInformation("Hello");
}

// Define other methods, classes and namespaces here
