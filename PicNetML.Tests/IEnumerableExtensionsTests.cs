using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.util;
using PicNetML;
using NUnit.Framework;
namespace PicNetML.Tests
{
  [TestFixture] public class IEnumerableExtensionsTests
  {
    [Test] public void test_GetMajority()
    {
      var possibilities = new [] {"a", "b", "c", "b", "c", "b"};
      Assert.AreEqual("b", possibilities.GetMajority());
    }

    [Test] public void test_Randomize()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var rnd = l.Randomize().ToArray();
      CollectionAssert.AreNotEqual(l, rnd);
      CollectionAssert.AreEqual(l, rnd.OrderBy(v => v));
    }

    [Test] public void test_RandomSample()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var rnd = l.RandomSample(2);
      var rnd2 = l.RandomSample(5).ToArray();

      Assert.AreEqual(2, rnd.Count());
      CollectionAssert.AreNotEqual(l, rnd2);
      CollectionAssert.AreEqual(l, rnd2.OrderBy(v => v));
    }

    [Test] public void test_RandomSampleWithReplacement()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var rnd = l.RandomSampleWithReplacement(2);
      var rnd2 = l.RandomSampleWithReplacement(5).ToArray();

      Assert.AreEqual(2, rnd.Count());
      CollectionAssert.AreNotEqual(l, rnd2);
      CollectionAssert.AreNotEqual(l, rnd2.OrderBy(v => v));
    }

    [Test] public void test_ToArrayList()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var al = l.ToArrayList();
      Assert.AreEqual(typeof(ArrayList), al.GetType());
      CollectionAssert.AreEqual(l, al);
    }

    [Test] public void test_ForEach2()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var l2 = new List<int>();
      l.ForEach2(v => l2.Add(v * 2));
      CollectionAssert.AreEqual(new [] {2, 4, 6, 8, 10}, l2);
    }

    [Test] public void test_ForEach2_witj_index()
    {
      var l = new [] {1, 2, 3, 4, 5};
      var l2 = new List<int>();
      l.ForEach2((v,i) => l2.Add(v + i));
      CollectionAssert.AreEqual(new [] {1, 3, 5, 7, 9}, l2);
    }

    [Test] public void test_ToEnumerable()
    {
      var al = new ArrayList();
      al.add(1); al.add(2); al.add(3);
      var l = al.ToEnumerable<int>();
      CollectionAssert.AreEqual(new [] {1, 2, 3}, l);
    }
  }
}
