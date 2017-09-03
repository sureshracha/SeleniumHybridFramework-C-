
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TestAutomation.Reporting
{
  internal class ScreenCapture
  {
    public Image CaptureScreen()
    {
      return this.CaptureWindow(ScreenCapture.User32.GetDesktopWindow());
    }

    public Image CaptureWindow(IntPtr handle)
    {
      IntPtr windowDc = ScreenCapture.User32.GetWindowDC(handle);
      ScreenCapture.User32.RECT rect = new ScreenCapture.User32.RECT();
      ScreenCapture.User32.GetWindowRect(handle, ref rect);
      int nWidth = rect.right - rect.left;
      int nHeight = rect.bottom - rect.top;
      IntPtr compatibleDc = ScreenCapture.GDI32.CreateCompatibleDC(windowDc);
      IntPtr compatibleBitmap = ScreenCapture.GDI32.CreateCompatibleBitmap(windowDc, nWidth, nHeight);
      IntPtr hObject = ScreenCapture.GDI32.SelectObject(compatibleDc, compatibleBitmap);
      ScreenCapture.GDI32.BitBlt(compatibleDc, 0, 0, nWidth, nHeight, windowDc, 0, 0, 13369376);
      ScreenCapture.GDI32.SelectObject(compatibleDc, hObject);
      ScreenCapture.GDI32.DeleteDC(compatibleDc);
      ScreenCapture.User32.ReleaseDC(handle, windowDc);
      Image image = (Image) Image.FromHbitmap(compatibleBitmap);
      ScreenCapture.GDI32.DeleteObject(compatibleBitmap);
      return image;
    }

    public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
    {
      this.CaptureWindow(handle).Save(filename, format);
    }

    public void CaptureScreenToFile(string filename, ImageFormat format)
    {
      this.CaptureScreen().Save(filename, format);
    }

    private class GDI32
    {
      public const int SRCCOPY = 13369376;

      [DllImport("gdi32.dll")]
      public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

      [DllImport("gdi32.dll")]
      public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

      [DllImport("gdi32.dll")]
      public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

      [DllImport("gdi32.dll")]
      public static extern bool DeleteDC(IntPtr hDC);

      [DllImport("gdi32.dll")]
      public static extern bool DeleteObject(IntPtr hObject);

      [DllImport("gdi32.dll")]
      public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }

    private class User32
    {
      [DllImport("user32.dll")]
      public static extern IntPtr GetDesktopWindow();

      [DllImport("user32.dll")]
      public static extern IntPtr GetWindowDC(IntPtr hWnd);

      [DllImport("user32.dll")]
      public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

      [DllImport("user32.dll")]
      public static extern IntPtr GetWindowRect(IntPtr hWnd, ref ScreenCapture.User32.RECT rect);

      public struct RECT
      {
        public int left;
        public int top;
        public int right;
        public int bottom;
      }
    }
  }
}
