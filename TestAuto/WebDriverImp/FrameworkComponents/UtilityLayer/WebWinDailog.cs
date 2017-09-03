using AutoItX3Lib;

using TestAutomation.WebWinComponents.Interfaces;
using System.Threading;

namespace TestAutomation.WebDriver.WebWinComponents
{
    /// <summary>
    /// 
    /// </summary>
    public class WebWinDialog : IWebWinDialog
    {
        AutoItX3 x = new AutoItX3();
        string title;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WebWinDialog(string DialogTitle)
        {
            this.title = DialogTitle;
            Thread.Sleep(5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void BtnClickNo()
        {
             
            if (x.WinExists(this.title).Equals(1))
            {
                x.WinActive(this.title);
                x.ControlFocus(this.title, "&No", "[CLASS:Button]");
                x.Send("{SPACE}");
                Thread.Sleep(10);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void BtnClickYes()
        {
             
            if (x.WinExists(this.title).Equals(1))
            {
                x.WinActive(this.title);
                x.ControlFocus(this.title, "&Yes", "[CLASS:Button]");
                x.Send("{SPACE}");
                Thread.Sleep(10);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void BtnClickCancel()
        {
             
            if (x.WinExists(this.title).Equals(1))
            {
                x.WinActive(this.title);
                x.ControlFocus(this.title, "&Cancel", "[CLASS:Button]");
                x.Send("{SPACE}");
                Thread.Sleep(10);
            }
        }
    }


}
