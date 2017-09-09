 

using System.IO;

namespace TestAutomation.Utilities
{
  public class DirActions
  {
    public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      DirectoryInfo directoryInfo1 = new DirectoryInfo(sourceDirName);
      if (!directoryInfo1.Exists)
        throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
      DirectoryInfo[] directories = directoryInfo1.GetDirectories();
      if (!Directory.Exists(destDirName))
        Directory.CreateDirectory(destDirName);
      foreach (FileInfo fileInfo in directoryInfo1.GetFiles())
      {
        string destFileName = Path.Combine(destDirName, fileInfo.Name);
        fileInfo.CopyTo(destFileName, false);
      }
      if (!copySubDirs)
        return;
      foreach (DirectoryInfo directoryInfo2 in directories)
      {
        string destDirName1 = Path.Combine(destDirName, directoryInfo2.Name);
        DirActions.DirectoryCopy(directoryInfo2.FullName, destDirName1, copySubDirs);
      }
    }
  }
}
