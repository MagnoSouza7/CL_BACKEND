using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Tarefas;

namespace WorkerService
{
    public class WokerDataResposta : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await VerificarDataResposta.Execute(stoppingToken);
            }
        }
    }
}
