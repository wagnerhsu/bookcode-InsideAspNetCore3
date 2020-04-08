<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Http</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	Host.CreateDefaultBuilder()
		.ConfigureWebHostDefaults(builder => builder.Configure(app => app.Use(Middleware1)))
		.Build()
		.Run();
}

RequestDelegate Middleware1(RequestDelegate next)
{
	return async context => await context.Response.WriteAsync("Hello");
}

