using adventofcode2021.Puzzles.Day1;
using adventofcode2021.Puzzles.Day2;
using adventofcode2021.Puzzles.Day3;
using adventofcode2021.Puzzles.Day4;
using adventofcode2021.Puzzles.Day5;
using adventofcode2021.Puzzles.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace adventofcode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            var day = 5;
            switch (day)
            {
                case 1:
                    var svc = host.Services.GetService<IDay1Service>();
                    svc.Execute();
                    break;

                case 2:
                    var svc2 = host.Services.GetService<IDay2Service>();
                    svc2.Execute();
                    break;
                case 3:
                    var svc3 = host.Services.GetService<IDay3Service>();
                    svc3.Execute();
                    break;
                case 4:
                    var svc4 = host.Services.GetService<IDay4Service>();
                    svc4.Execute();
                    break;
                case 5:
                    var svc5 = host.Services.GetService<IDay5Service>();
                    svc5.Execute();
                    break;
            }
        }


        static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((_, services) =>
            {
                services.AddTransient<IFileDataReader, FileDataReader>();
                services.AddTransient<IDay1Service, Day1Service>();
                services.AddTransient<IDay1Engine, Day1Engine>();
                services.AddTransient<IDay2Service, Day2Service>();
                services.AddTransient<IDay2Engine, Day2Engine>();
                services.AddTransient<IDay3Service, Day3Service>();
                services.AddTransient<IDay3Engine, Day3Engine>();
                services.AddTransient<IDay4Service, Day4Service>();
                services.AddTransient<IDay4Engine, Day4Engine>();
                services.AddTransient<IDay5Service, Day5Service>();
                services.AddTransient<IDay5Engine, Day5Engine>();
            });
    }
}
