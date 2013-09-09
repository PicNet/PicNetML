using System.Linq;
using Ml2.Arff;
using NUnit.Framework;

namespace Ml2.Tests.Arff.Builder
{
  [TestFixture] public class ExtendableObjTests
  {
    internal class TestingRow {
      public double CLASS { get; set; }
      [Nominal] public string ATT_1 { get; set; }    
    }

    [Test] public void test_creation() {
      var rows = new [] { 
        new TestingRow { CLASS = 1.0, ATT_1 = "1" },
        new TestingRow { CLASS = 2.0, ATT_1 = "2" }
      }.Select(ExtendableObj.Create).ToArray();
      
      rows[0].AddNumerical("additional1", 3); 
      rows[1].AddNumerical("additional1", 4);

      rows[0].AddBinary("additional2", true); 
      rows[1].AddBinary("additional2", false);

      rows[0].AddNumerical("additional3", 5); 
      rows[1].AddNumerical("additional3", 6);

      var rt = Runtime.LoadFromRows(0, rows);
      var r1 = rt.ElementAt(0);
      var r2 = rt.ElementAt(1);
      Assert.AreEqual(1, r1.Value(0));
      Assert.AreEqual(2, r2.Value(0));

      Assert.AreEqual(0, r1.Value(1));
      Assert.AreEqual(1, r2.Value(1));      

      Assert.AreEqual(3, r1.Value(2)); // additional1
      Assert.AreEqual(4, r2.Value(2));

      Assert.AreEqual(1, r1.Value(3)); // additional2
      Assert.AreEqual(0, r2.Value(3));

      Assert.AreEqual(5, r1.Value(4)); // additional3
      Assert.AreEqual(6, r2.Value(4));
    }
  }
}