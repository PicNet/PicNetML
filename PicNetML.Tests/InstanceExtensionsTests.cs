using System.Linq;
using NUnit.Framework;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests
{
  [TestFixture]
  public class InstanceExtensionsTests
  {
    [Test] public void test_ToStrings_gets_the_string_representation_of_the_instance()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow2>("titanic_train.csv", 0, 3);
      var instance = rt[0].Impl;
      var strs = instance.ToStrings();
      Assert.AreEqual(new [] {"0", "3", "Braund, Mr. Owen Harris", "male", "22", "1", "0", "A/5 21171", "7.25", "?", "S"}, strs);
    }

    [Test] public void test_ToEnumerableAttributes()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 3);
      var atts = rt[0].Impl.ToEnumerableAttributes();
      var names = atts.Select(a => a.Name).ToArray();
      Assert.AreEqual(new [] {"survived", "pclass", "sex", "embarked"}, names);
    }
  }
}
