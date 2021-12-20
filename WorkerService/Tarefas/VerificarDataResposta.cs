using Email;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService.Tarefas
{
    public static class VerificarDataResposta
    {
        public static async Task Execute(CancellationToken stoppingToken)
        {
            var agora = DateTime.Now;

            DateTime agendamento;

            agendamento = new DateTime(agora.Year, agora.Month, agora.Day + 1, 0, 0, 0);

            var delay = agendamento - agora;

            await Task.Delay(delay, stoppingToken);

            var ontem = DateTime.Now.AddDays(1);
            ontem = new DateTime(ontem.Year, ontem.Month, ontem.Day);

            using var context = new ApiContext();

            var consultasPublicas = context.ConsultaPublicas
                .Include(x => x.Cliente)
                .Include(x => x.Empresa)
                .AsNoTracking().ToList();

            foreach(var consultaPublica in consultasPublicas)
            {
                if (consultaPublica.DataResposta == ontem)
                {
                    EmailService.EnviarEmailAlertaConsultaPublica(
                        consultaPublica.NumConsulta,
                        consultaPublica.Cliente.Nome,
                        consultaPublica.Empresa.Nome,
                        consultaPublica.DataResposta);
                }
            }

        }
    }
}
