using Email.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Email.Emails
{
    public class NotificacaoAlertaConsultaPublica
    {
        public static void Send(int numConsulta, string nomeCliente, string nomeEmpresa, DateTime dataResposta)
        {

            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("Equipe de Licitação", "licita@globalweb.com.br"));
            message.From.Add(new MailboxAddress("Central de Licitações", Config.From));

            message.Subject = "Prezados a Consulta Publica de Número " + numConsulta +" acontecerá amanha.";

            var mensagem = @$"
                                <article style='padding-top: 90px'>
                                    <h1 style='font-size: 2.1em;font-weight: 600;letter-spacing: 0.2em;line-height: 1.1em;margin: 0 0 0.6em 0; text-align: center'>CENTRAL DE LICITAÇÕES</h1>
                                    <p style='font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0'>Notificação</p>
                                </article>

                                <article style='padding: 20px'>
                                    <div class='pro' style='background-color: #fff;padding: 30px 90px'>
                                    <h3 style='font-size: 1.2em;font-weight: 600;letter-spacing: 0.1em; margin: 0 0 1em 0'>Alerta!</h3>
                                    <p style='font-family: &quot;Times New Roman&quot;, serif;line-height: 1.3em;margin: 0 0 1em 0;margin-bottom: 25px'>
                            
                                    Prezados, <br/>
 
                                    Atenção!!! A Consulta Publica ocorrerá amanha:<br/>
                                    Número da Consulta: {numConsulta}<br/>
                                    Cliente: {nomeCliente}<br/>
                                    Empresa: {nomeEmpresa}<br/>
                                    Data da Resposta: {dataResposta.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)} <br/>
                                    <br/>
                                    <br/>";


            mensagem += @$"Clique <a href='https://cl.globalweb.com.br/'>aqui</a> para acompanhar

                                    </p>
                                    </div>
                                </article>

                                <footer style='padding: 30px 20px;margin: 0 auto'>
 
                                 <p> Toda a Equipe de Licitação Reservado </p>
   
                                   <br/>
   
                                   <p class='note' style='font-family: &quot;Times New Roman&quot;, serif;margin: 0;font-size: 0.6em;font-weight: 700'>Equipe de Sistemas Internos GlobalWeb</p>
                                </footer>";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = mensagem
            };

            try
            {
                using var emailClient = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };

                emailClient.Connect(Config.Host, Config.Port, SecureSocketOptions.Auto);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
            catch (Exception) { }
        }
    }
}
