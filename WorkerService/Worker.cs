using Application.Repository.Sla;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Tarefas;

namespace WorkerService
{
    public class Worker : BackgroundService
    {

        private readonly ISlaRepository slaRepository;

        public Worker(ISlaRepository slaRepository)
        {
            this.slaRepository = slaRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await VerificarSlaEditais.Execute(stoppingToken, slaRepository);

            }
        }
    }
}
