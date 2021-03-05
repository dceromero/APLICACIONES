using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

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
            //mensaje.Bcc.Add(Copia1);
            //mensaje.Bcc.Add(Copia2);
            mensaje.Subject = "Recuperar Contraseña de Usuario";
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
            //mensaje.Bcc.Add(Copia1);
            //mensaje.Bcc.Add(Copia2);
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
            //mensaje.Bcc.Add(Copia1);
            //mensaje.Bcc.Add(Copia2);
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

        public async Task<string> EnviarMensajeCredito(string para, string subject, FUNC_VIEW_EMAILCUPO inforech =null)
        {
            string result = "El correo ha sido enviado para su aprobación";
            var mensaje = new MailMessage(FromMail, para);
            //mensaje.Bcc.Add(Copia1);
            //mensaje.Bcc.Add(Copia2);
            mensaje.Subject = $"{subject} de Credito";
            mensaje.BodyEncoding = Encoding.UTF8;
            string msj = $"Ingrese al siguiente <a href='http://186.116.15.58:8084/'>Link<a/> para aprobar la Solicitud de Cupo";
            if(subject == "Rechazado")
            {
                result = "Se ha enviado la notificación de rechazo";
                msj = $"La Solicitud para el Cliente : {inforech.cliente} por {inforech.TSOL} <br/>" +
                    $"a sido rechazada por: {inforech.Aprobador} <br/>" +
                    $"Motivo del Rechazo : {inforech.OBS}";
            }
            else if(subject == "Notificación")
            {
                result = "Se ha enviado la notificación";
                msj = $"La Solicitud para el Cliente : {inforech.cliente} por {inforech.TSOL} a sido aprobada y Actualizada en SAP.";
            }
            mensaje.Body = msj;
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                await servidor.SendMailAsync(mensaje);
                return result;
            };
        }

        public async Task<string> NotificarCartera( FUNC_VIEW_EMAILCUPO inforech )
        {
            string result = "Se ha enviado la notificación";
            var mensaje = new MailMessage(FromMail, "carteragloria@gloria.com.co");
            //mensaje.Bcc.Add(Copia1);
            //mensaje.Bcc.Add(Copia2);
            mensaje.Subject = $"Notificación de Crédito";
            mensaje.BodyEncoding = Encoding.UTF8;
            var dia = DateTime.Now.Hour >= 12 ? "Buenas Tardes" : "Buenos días";
            string msj = $"{ dia } <br/> La Solicitud para el Cliente : {inforech.cliente} por {inforech.TSOL} a sido aprobada y Actualizada en SAP.";
            mensaje.Body = msj;
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                await servidor.SendMailAsync(mensaje);
                return result;
            };
        }
        
        public string EnviarMensajeInventario(string para, string cd)
        {
            var mensaje = new MailMessage(FromMail, para);
            //mensaje.Bcc.Add("j.robayo@gloria.com.co");
            mensaje.Subject = $"Autorización Ajustes Inventarios: {cd}";
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.Body = "Para informarle que tiene una autorización pendiente sobre Ajuste de Inventario:   <a href='http://186.116.15.58:8084/'>link</a>";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                 servidor.Send(mensaje);
                return "El correo ha sido enviado para su aprobación";
            };
        }

        public string EnviarMensajeContabilidad(string para)
        {
            var mensaje = new MailMessage(FromMail, para);
            mensaje.Subject = $"Notificación Ajustes Inventarios";
            mensaje.BodyEncoding = Encoding.UTF8;
            string saludo = DateTime.Now.Hour >= 12 ? "Buenas Tardes" : "Buenos días";
            mensaje.Body = $"{saludo} <br> Se le informa que su solicitud de ajuste de inventarios <br>" +
                $"ha sido registrada en SAP por el área contable. <br> <br> <br> <br>" +
                $" Por favor no responder este correo ya que es un proceso automático. ";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                return "El correo ha sido enviado para su aprobación";
            };
        }

        public string EnviarMensajeNotasComerciales(string para)
        {
            var datos = para.Split('|');
            var mensaje = new MailMessage(FromMail, datos[0]);
            mensaje.Bcc.Add("j.robayo@gloria.com.co");
            if (datos[1] == "Autorización - Modificación")
            {
                mensaje.CC.Add("e.martinez@gloria.com.co");
            }
            mensaje.Subject = $"{datos[1]}, Nota({datos[2]}) {datos[3]} ";
            mensaje.BodyEncoding = Encoding.UTF8;
            string saludo = DateTime.Now.Hour >= 12 ? "Buenas Tardes" : "Buenos días";
            mensaje.Body = $"{saludo} <br> Para Informarle que tiene una solicitud {datos[2]} del cliente {datos[3]} {datos[4]} <br>" +
                $"Favor ingrese al siguiente <a href='http://186.116.15.58:8084/'>link</a> para la aprobación.   <br> <br> <br> <br>" +
                $" Por favor no responder este correo ya que es un proceso automático. ";
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.High;
            using (var servidor = new SmtpClient("smtp.office365.com", 587))
            {
                servidor.Credentials = new NetworkCredential(FromMail, MailPsw);
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                return "El correo ha sido enviado para su aprobación";
            };
        }

    }
}
