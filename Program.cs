using Microsoft.Extensions.DependencyInjection;
using System;

namespace VendingMachine_CSPD
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
           scope.ServiceProvider.GetRequiredService<VendingMachine>().DisplayItems();
            DisposeServices();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IProducts, Products>();
            services.AddSingleton<VendingMachine>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}