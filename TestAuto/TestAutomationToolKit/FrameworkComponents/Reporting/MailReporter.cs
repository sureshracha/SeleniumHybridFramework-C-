
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace TestAutomation.Reporting
{
  public class MailReporter
  {
    public void sendMail(string antHillBuildId)
    {
      SmtpClient smtpClient = new SmtpClient();
      smtpClient.Host = ConfigurationManager.AppSettings["Host"];
      string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
      string str1 = ConfigurationManager.AppSettings["MailTo"];
      string machineName = Environment.MachineName;
      try
      {

                try
                {
                    str1 = ConfigurationManager.AppSettings["MailToGroup"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No MailToGroup entry in Config  [Exception :" + ex.Message +"]");
                }
        
      }
      catch (Exception ex)
      {
            Console.WriteLine("MachineName not specified in Config [Exception :" + ex.Message + "]");
      }
      smtpClient.EnableSsl = false;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.Timeout = 5000;
      StreamReader streamReader = File.OpenText("C:\\TestResults\\TestReport.html");
      MailMessage message = new MailMessage();
      message.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"], ConfigurationManager.AppSettings["DisplayName"]);
      message.Subject = ConfigurationManager.AppSettings["MailSubject"];
      message.IsBodyHtml = true;
      string str2 = str1;
      char[] chArray = new char[1]
      {
        ';'
      };
      foreach (string address in str2.Split(chArray))
        ((Collection<MailAddress>) message.To).Add(new MailAddress(address));
      message.Body =   "<I>Note: Links in this mail doesn't work. Please open the \"TestReport.html\" from C:\\TestResults folder \n\n</I>";
      message.Body = message.Body + streamReader.ReadToEnd();
      smtpClient.Send(message);
    }
  }
}
