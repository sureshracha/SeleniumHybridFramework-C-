using AutoItX3Lib;
using TestAutomation.AutoIT.KeyboardMouse;

namespace TestAutomation.AutoIT.KeyboardOperations
{
    /// <summary>
    /// 
    /// </summary>
    public class KeyBoard
    {
        readonly private AutoItX3 x = new AutoItX3();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WindowLocatorString"></param>
        public KeyBoard(string WindowLocatorString)
        {
            x.WinActivate(WindowLocatorString);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kkyes"></param>
        public void SendKey(KeyBoardKeys kkyes)
        {
            x.Send("{" + kkyes.ToString() + "}");
        }
    }
    
}
