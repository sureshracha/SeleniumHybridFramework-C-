// Decompiled with JetBrains decompiler
 
 
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using TestAutomation.Framework;

namespace TestAutomation.Reporting
{
  public class Logger
  {
    private static string baseDir = AppDomain.CurrentDomain.BaseDirectory;
    private bool capture;
    private string logDirPath;
    private string className;
        public string LogForRally;
        

    public Logger(bool capture = true)
        {
      this.className = new StackTrace().GetFrames()[1].GetMethod().DeclaringType.Name;
      this.capture = capture;
      this.logDirPath = Constants.LogFolderPath;
      
      
        }

    public void Debug(object message)
    {
      this.logMsg("DEBUG", message.ToString());
      Console.WriteLine(message);
    }

    public void Debug(object message, Exception execption)
    {
      this.logMsg("DEBUG", message.ToString());
      this.logMsg("DEBUG", execption.Message);
      this.logMsg("DEBUG", execption.StackTrace);
      Console.WriteLine((string) message + (object) "\n" + (string) (object) execption);
    }

    public void Info(object message)
    {
            Constants.logAsString.AppendLine(message.ToString()+ "</br>");
            //this.logMsg("INFO", message.ToString());
            
      Console.WriteLine(message);
    }

    public void Info(object message, Exception execption)
    {
      this.logMsg("INFO", message.ToString());
      this.logMsg("INFO", execption.Message);
      this.logMsg("INFO", execption.StackTrace);
      Console.WriteLine((string) message + (object) "\n" + (string) (object) execption);
    }

    public void Warn(object message)
    {
      this.logMsg("WARN", "<font color=\"orange\"><b>" + message + "</b></font><br>");
      Console.WriteLine(message);
    }

    public void Warn(object message, Exception execption)
    {
      this.logMsg("WARN", "<font color=\"orange\"><b>" + message + "</b></font><br>");
      this.logMsg("WARN", execption.Message);
      this.logMsg("WARN", execption.StackTrace);
      Console.WriteLine((string) message + (object) "\n" + (string) (object) execption);
    }

    public void Error(object message)
    {
      this.logMsg("ERROR", "<font color=\"red\"><b>" + message + "</b></font><br>");
      Console.WriteLine(message);
      this.CaptureScreenWithFullLink();
    }

    public void Error(object message, Exception execption)
    {
      this.logMsg("ERROR", "<font color=\"red\"><b>" + message + "</b></font><br>");
      this.logMsg("ERROR", execption.Message);
      this.logMsg("ERROR", execption.StackTrace);
      Console.WriteLine((string) message + (object) "\n" + (string) (object) execption);
      this.CaptureScreenWithFullLink();
    }

    public void Fatal(object message)
    {
      this.logMsg("FATAL", "<font color=\"red\"><b>" + message + "</b></font><br>");
      Console.WriteLine(message);
      this.CaptureScreenWithFullLink();
    }

    public void Fatal(object message, Exception execption)
    {
      this.logMsg("FATAL", "<font color=\"red\"><b>" + message + "</b></font><br>");
      this.logMsg("FATAL", execption.Message);
      this.logMsg("FATAL", execption.StackTrace);
      Console.WriteLine((string) message + (object) "\n" + (string) (object) execption);
      this.CaptureScreenWithFullLink();
    }

    public string CaptureScreen()
    {
      if (!this.capture)
        return (string) null;
      ScreenCapture screenCapture = new ScreenCapture();
      string str1 = Stopwatch.GetTimestamp().ToString();
      string path = this.logDirPath + "\\Images\\";
      Directory.CreateDirectory(path);
      string str2 = "screenshot_" + str1 + ".png";
      string filename = path + "screenshot_" + str1 + ".png";
      string str3 = "..\\Images\\screenshot_" + str1 + ".png";
      screenCapture.CaptureScreenToFile(filename, ImageFormat.Png);
      this.Info((object) ("Screen Captured and Saved. <a href=" + str3 + "><i>Click Here for Screenshot</i></a>"));
      return str2;
    }

    private string CaptureScreenWithFullLink()
    {
      if (!this.capture)
        return (string) null;
      ScreenCapture screenCapture = new ScreenCapture();
      string str1 = Stopwatch.GetTimestamp().ToString();
      string path = this.logDirPath + "\\Images\\";
      Directory.CreateDirectory(path);
      string str2 = "screenshot_" + str1 + ".png";
      string filename = path + "screenshot_" + str1 + ".png";
      string str3 = "..\\Images\\screenshot_" + str1 + ".png";
      screenCapture.CaptureScreenToFile(filename, ImageFormat.Png);
      this.Info((object) ("Screen Captured and Saved. <a href=" + str3 + "><i>Click Here for Screenshot</i></a>"));
      
      return str2;
    }

    private void logMsg(string type, string message)
    {
      string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");
      Constants.logAsString.AppendLine("[" + str + "][" + this.className + "][" + type + "] " + message + "<br>");
    }
  }
}
