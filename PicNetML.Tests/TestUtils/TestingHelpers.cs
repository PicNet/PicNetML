using System.IO;

namespace PicNetML.Tests {
  public static class TestingHelpers {
     public static string ReadResourceFile(string filename) {
       return File.ReadAllText(GetResourceFileName(filename));
     }

    public static string GetResourceFileName(string filename) {
      return @"..\..\resources\" + filename;
    }
  }
}