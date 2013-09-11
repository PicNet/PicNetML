using System.IO;
using System.Linq;

namespace PicNetML.Tests.TestUtils {
  public static class TestingHelpers {

    public static string GetResourceFileName(string filename) {
      return @"..\..\resources\" + filename;
    }

    public static Runtime LoadSmallRuntime<T>(string filename, int classidx, int count) where T : new() {
      var file = GetResourceFileName(filename);
      using (var fs = File.OpenText(file)) {
        string[] lines = Enumerable.Range(0, count + 1).          
          Select(i => fs.ReadLine()).
          Skip(1).
          ToArray();
        var rows = Runtime.LoadRowsFromLines<T>(lines);
        return Runtime.LoadFromRows(classidx, rows);
      }            
    }
  }
}