﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosEnviarEmail
    {
        string FromMail;
        string MailPsw;
        string Copia1;
        string Copia2;
        public MetodosEnviarEmail()
        {
             FromMail = ConfigurationManager.AppSettings["mail"];
             MailPsw = ConfigurationManager.AppSettings["psw"];
             Copia1 = ConfigurationManager.AppSettings["bcc"];
             Copia2 = ConfigurationManager.AppSettings["bcc1"];
        }

       

        public async Task<string> EnviarMensaje(string para, string clave)
        {
            var mensaje = new MailMessage(FromMail, para);
            mensaje.Bcc.Add(Copia1);
            mensaje.Bcc.Add(Copia2);
            mensaje.Subject = "Recuperar Contraseña de Proveedor";
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.Body = $"La clave para ingresar al sistemas es {clave}";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                await servidor.SendMailAsync(mensaje);
                return $"Su contraseña ha sido enviada al siguiente Correo: {para}";
            };
        }

        public async Task<string> EnviarMensaje(string para)
        {
            var mensaje = new MailMessage(FromMail, para);
            mensaje.Bcc.Add(Copia1);
            mensaje.Bcc.Add(Copia2);
            mensaje.Subject = "Autorización de Descuentos";
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.Body = $"Ingrese al siguiente <a href='http://186.116.15.58:8084/'>Link<a/> para aprobar el descuento";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                await servidor.SendMailAsync(mensaje);
                return $"El correo ha sido enviado para su aprobación";
            };
        }

        public async Task<string> EnviarMensajeRech(string para)
        {
            var mensaje = new MailMessage(FromMail, para);
            mensaje.Bcc.Add(Copia1);
            mensaje.Bcc.Add(Copia2);
            mensaje.Subject = "Autorización de Descuentos";
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.Body = $"Ingrese al siguiente Link para aprobar el descuento";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                await servidor.SendMailAsync(mensaje);
                return $"El correo ha sido enviado para su aprobación";
            };
        }

    }
}
