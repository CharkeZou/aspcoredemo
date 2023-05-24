using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrleansHelloWorld
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            try
            {
                using IHost host = await StartSiloAsync();
                Console.WriteLine("\n\n Press Enter to terminate...\n\n");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<IHost> StartSiloAsync()
        {
            var builder = new HostBuilder()
                .UseOrleans(silo =>
                {
                    silo.UseLocalhostClustering().ConfigureLogging(logging => logging.AddConsole());
                });

            var host = builder.Build();
            await host.StartAsync();

            return host;
        }
    }
}