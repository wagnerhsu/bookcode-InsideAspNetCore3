using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;

namespace App
{
    class Program
    {
        static async Task Main()
        {
            var assembly = Assembly.GetEntryAssembly();

            var content1 = await new ServiceCollection()
                .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assembly))
                .AddSingleton<IFileManager, FileManager>()
                .BuildServiceProvider()
                .GetRequiredService<IFileManager>()
                .ReadAllTextAsync("data.txt");

            var resourceName = $"{assembly.GetName().Name}.data.txt";
            Console.WriteLine(resourceName);
            var stream = assembly.GetManifestResourceStream(resourceName);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            var content2 = Encoding.Default.GetString(buffer);

            Debug.Assert(content1 == content2);
        }
    }
}
