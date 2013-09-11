using System.Linq;
using NUnit.Framework;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests
{
  [TestFixture] public class InstancesExtensionsTests 
  {
    [Test] public void test_GetAttrStrings()
    {      
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 5);
      var vals = rt.Impl.GetAttrStrings(1);
      CollectionAssert.AreEqual(new [] {"3","1","3","1","3"}, vals);
    }

    [Test] public void test_GetAttrDoubles()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 5);
      var vals = rt.Impl.GetAttrDoubles(1);
      CollectionAssert.AreEqual(new [] {2.0,0.0,2.0,0.0,2.0}, vals);
    }

    [Test] public void test_ToEnumerableAttributes()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 5);
      var atts = rt.Impl.ToEnumerableAttributes();
      var names = atts.Select(a => a.Name).ToArray();
      CollectionAssert.AreEqual(new [] {"survived", "pclass", "sex", "embarked"}, names);
    }

    [Test] public void test_ToEnumerable()
    {
      var rt = TestingHelpers.LoadSmallRuntime<TitanicDataRow>("titanic_train.csv", 0, 5);
      var instances = rt.Impl.ToEnumerable();
      Assert.AreEqual(5, instances.Count());
    }
  }
}
