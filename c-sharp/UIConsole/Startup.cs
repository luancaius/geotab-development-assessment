using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Interfaces;
using Service.Util;

namespace UIConsole
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOutput, ConsolePrinter>();
            services.AddScoped<IMainService, MainService>();
            services.AddScoped<IMyService, MyService>();
        }
    }
}