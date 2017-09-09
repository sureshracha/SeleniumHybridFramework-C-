 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace TestAutomation.Reporting
{
  internal class HtmlReporter
  {
    private static int passCount = 0;
    private static StringBuilder htmlReportString = new StringBuilder();
    private static TextWriter reportFile;
    private string startTime;
    private string stopTime;
    private string basePath;

    public void initializeReport(string pkgName, string basePath)
    {
      this.basePath = basePath;
      Directory.CreateDirectory(basePath);
      string str1 = "Logs\\TestRunLog.html";
      this.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
      string machineName = Environment.MachineName;
      string userName = Environment.UserName;
      string str2 = basePath;
      string str3 = "Not Specified";
      
      HtmlReporter.htmlReportString.AppendLine(this.getHeader());
      HtmlReporter.htmlReportString.AppendLine("<div class=\"topright\">TestAutomationFramework</div>");
      HtmlReporter.htmlReportString.AppendLine("<hr>");
      HtmlReporter.htmlReportString.AppendLine("<h2>Automation Test Run Report</h2>");
      HtmlReporter.htmlReportString.AppendLine("<table style=\"width:80%\">");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Test Package</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + pkgName + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Test Suite Started at</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + this.startTime + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Test Run Log File</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><a href=" + str1 + "><i>Click Here for LogFile</i></a></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>UserName/Machine Name</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + userName + "/" + machineName + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Results Location</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + str2 + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Environment</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + str3 + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("</table>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<table id=\"t01\">");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<th style=\"width:35%\"><b>Test Class<b></th>");
      HtmlReporter.htmlReportString.AppendLine("<th style=\"width:25%\"><b>Test Case<b></th>");
      HtmlReporter.htmlReportString.AppendLine("<th style=\"width:25%\"><b>Execution Time (hh:mm:ss)<b></th>");
      HtmlReporter.htmlReportString.AppendLine("<th style=\"width:15%\"><b>Status<b></th>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
    }

    public void updateReport(TestContext context, string timeElapsed)
    {
      string str1 = ((object) context.CurrentTestOutcome).ToString();
      string str2 = "bgcolor = \"red\"";
      if (str1.Equals("Passed"))
      {
        str2 = "bgcolor = \"green\"";
        ++HtmlReporter.passCount;
      }
      string str3 = "Logs\\TestRunLog.html#" + context.TestName;
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + context.FullyQualifiedTestClassName + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + context.TestName + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + timeElapsed + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td " + str2 + "><a href=" + str3 + ">" + str1 + "</a></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
    }

    public void updateReportForScenario(string status, string featureName, string testName, string timeElapsed)
    {
      string str1 = status;
      string str2 = "bgcolor = \"red\"";
      if (str1.Equals("Passed"))
      {
        str2 = "bgcolor = \"green\"";
        ++HtmlReporter.passCount;
      }
      string str3 = "Logs\\TestRunLog.html#" + testName;
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + featureName + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + testName + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + timeElapsed + "</td>");
      HtmlReporter.htmlReportString.AppendLine("<td " + str2 + "><a href=" + str3 + ">" + str1 + "</a></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
    }

    public void concludeReport(int testCount)
    {
      this.stopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
      float num = (float) ((double) HtmlReporter.passCount / (double) testCount * 100.0);
      HtmlReporter.htmlReportString.AppendLine("</table>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<table style=\"width:30%\">");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Test Suite Started at</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + this.startTime + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Test Suite Ended at</td>");
      HtmlReporter.htmlReportString.AppendLine("<td><i>" + this.stopTime + "</i></td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Total # of Test Cases</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + (object) testCount + "</td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td># of Tests Passed</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + (object) HtmlReporter.passCount + "</td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("<tr>");
      HtmlReporter.htmlReportString.AppendLine("<td>Pass Percentage</td>");
      HtmlReporter.htmlReportString.AppendLine("<td>" + (object) num + "%</td>");
      HtmlReporter.htmlReportString.AppendLine("</tr>");
      HtmlReporter.htmlReportString.AppendLine("</table>");
      HtmlReporter.htmlReportString.AppendLine("</body>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<br>");
      HtmlReporter.htmlReportString.AppendLine("<hr>");
      HtmlReporter.htmlReportString.AppendLine("<a font-size=6px text-align=\"center\">Test Automation Framework</a>");
      HtmlReporter.htmlReportString.AppendLine("</html>");
      this.stringToHtmlReport();
    }

    private string getHeader()
    {
      return "<!DOCTYPE html><html><head><style>table {width:80%;}table, th, td {border: 1px solid black;border-collapse: collapse;}td {padding: 5px;text-align: left;}th {padding: 5px;text-align: center;}table#t01 tr:nth-child(even) {background-color: #BDBDBD;}table#t01 tr:nth-child(odd) {background-color:#fff;}table#t01 th\t{background-color: #0404B4;color: white;}.topright {position: absolute;font-size: 18px;top: 8px;right: 16px;}</style></head><body>";
    }

    private void stringToHtmlReport()
    {
      HtmlReporter.reportFile = (TextWriter) new StreamWriter(this.basePath + "\\TestReport.html");
      HtmlReporter.reportFile.WriteLine(((object) HtmlReporter.htmlReportString).ToString());
      HtmlReporter.reportFile.Close();
    }
  }
}
