using OtoServis.Entities;
using System.Net;
using System.Net.Mail;

namespace OtoServis.WebUI.Utils
{
    public class MainHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com",587);
            smtpClient.Credentials = new NetworkCredential("emailKullanıcıad","emailşifre");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadı.com");
            message.To.Add("info@siteadı.com");
            message.To.Add("bilgi@siteadı.com");
            message.Subject="siteden mesaj geldi";
            message.Body=$"Mail bilgiler <hr/> Ad Soyad:{musteri.Adi} {musteri.Soyadi}" +
                $" <hr/> İlgilendiği araç ıd: {musteri.AracId}<hr/> email: {musteri.Email}<hr/> tel: {musteri.Telefon} <hr/> Notlar: {musteri.Notlar}";
            message.IsBodyHtml = true;
           // smtpClient.Send(message);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
