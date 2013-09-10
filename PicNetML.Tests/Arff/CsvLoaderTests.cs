using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PicNetML.Arff;

namespace PicNetML.Tests.Arff {
  [TestFixture] public class CsvLoaderTests {
    
    [SetUp][TearDown] public void CleanOutTestFiles() {
      Directory.GetFiles(".", ".csv").ForEach2(File.Delete);
    }

    [Test] public void Test_loading_file_without_a_preprocessor() {
      var c = new  CsvLoader<C1>();
      var csvcontent = "prop1,prop2\n0,1\n2,3";
      var file = "Test_loading_file_without_a_preprocessor.csv";
      File.WriteAllText(file, csvcontent);
      var rows = c.Load(file).ToArray();
      
      Assert.AreEqual(2, rows.Length);
      Assert.AreEqual(0, rows[0].prop1);
      Assert.AreEqual(1, rows[0].prop2);
      Assert.AreEqual(2, rows[1].prop1);
      Assert.AreEqual(3, rows[1].prop2);
    }

    [Test] public void Test_loading_file_with_a_preprocessor() {
      var c = new  CsvLoader<C1>();
      var csvcontent = "prop1,prop2\n0,1\n2,3";
      var file = "Test_loading_file_with_a_preprocessor.csv";
      File.WriteAllText(file, csvcontent);
      var rows = c.Load(file, l => {
        var tokens = l.Split(',');
        Assert.AreEqual(2, tokens.Length);
        return String.Join(",", tokens.Select(t => "1" + t));
      }).ToArray();
      
      Assert.AreEqual(2, rows.Length);
      Assert.AreEqual(10, rows[0].prop1);
      Assert.AreEqual(11, rows[0].prop2);
      Assert.AreEqual(12, rows[1].prop1);
      Assert.AreEqual(13, rows[1].prop2);
    }

    [Test] public void Test_loading_lines_without_a_preprocessor() {
      var c = new  CsvLoader<C1>();
      var lines = new [] {"0,1", "2,3"};
      var rows = c.LoadLines(lines).ToArray();
      
      Assert.AreEqual(2, rows.Length);
      Assert.AreEqual(0, rows[0].prop1);
      Assert.AreEqual(1, rows[0].prop2);
      Assert.AreEqual(2, rows[1].prop1);
      Assert.AreEqual(3, rows[1].prop2);
    }

    [Test] public void Test_loading_lines_with_a_preprocessor() {
      var c = new  CsvLoader<C1>();
      var lines = new [] {"0,1", "2,3"};
      var rows = c.LoadLines(lines, l => {        
        var tokens = l.Split(',');        
        Assert.AreEqual(2, tokens.Length);        
        return String.Join(",", tokens.Select(t => "1" + t));
      }).ToArray();
      
      Assert.AreEqual(2, rows.Length);
      Assert.AreEqual(10, rows[0].prop1);
      Assert.AreEqual(11, rows[0].prop2);
      Assert.AreEqual(12, rows[1].prop1);
      Assert.AreEqual(13, rows[1].prop2);
    }
   
    class C1 {
      public int prop1 { get;set; }
      public int prop2 { get;set; }
    }
  }   
}