using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for mail
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class mail : System.Web.Services.WebService
{
    [WebMethod]
    public bool SendMail(string sEmail, string sName, string sMessage)
    {
        try
        {
            MailMessage mail = new MailMessage(sEmail, "mariusmeyer42@gmail.com");

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mariusmeyer42@gmail.com", "Lenore@117");

            mail.Subject = "Contact from mariusmeyer.co.za - " + sName;
            mail.Body = sMessage;
            SmtpServer.Send(mail);

            return true;
        }
        catch (Exception ex) { return false; }
    }

}
