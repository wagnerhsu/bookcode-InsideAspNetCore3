using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace helloworld
{
    internal class Program
    {
        private static void Main()
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder
                    .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World."))))
                .Build()
                .Run();
        }
    }
}