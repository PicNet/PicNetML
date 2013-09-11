using NUnit.Framework;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests
{
  [TestFixture]
  public class AttributeExtensionsTests
  {
    [Test] public void test_attribute_to_enumerable_gives_all_distinct_nominal_vals()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 10);
      var pcclass = rt.Impl.attribute(1);
      var values = pcclass.ToEnumerable();
      Assert.AreEqual(new [] {"1", "2", "3"}, values);
    }

    [Test] public void test_attribute_to_enumerable_gives_nothing_on_numerics()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow2>("titanic_train.csv", 0, 10);
      var age = rt.Impl.attribute(4);
      var values = age.ToEnumerable();
      Assert.AreEqual(new string [0], values);
    }
  }
}
