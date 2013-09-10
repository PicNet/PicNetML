using System;
using PicNetML.Arff;

using NUnit.Framework;
namespace PicNetML.Tests.Arff
{
  [TestFixture()]
  public class ArffUtilsTests
  {
    [Test()]
    public void GetNonNullableTypeTest()
    {
      Assert.AreEqual(typeof(int), ArffUtils.GetNonNullableType(typeof(int?)));
      Assert.AreEqual(typeof(DateTime), ArffUtils.GetNonNullableType(typeof(DateTime?)));
      Assert.AreEqual(typeof(bool), ArffUtils.GetNonNullableType(typeof(bool?)));
    }
  }
}
