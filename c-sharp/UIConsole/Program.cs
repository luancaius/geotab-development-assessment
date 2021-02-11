﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IMyService>();
            service.Execute();
        }
    }
}