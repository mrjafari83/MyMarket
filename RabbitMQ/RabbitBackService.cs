using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class RabbitBackService : BackgroundService
    {
        public RabbitBackService(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }
        public IServiceProvider Services { get; set; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            reciveCreatedExcel();
        }

        private void reciveCreatedExcel()
        {
            using(var scope = Services.CreateScope())
            {
                var recive = scope.ServiceProvider.GetRequiredService<IRecive>();
                recive.ReciveCreateExcel();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
