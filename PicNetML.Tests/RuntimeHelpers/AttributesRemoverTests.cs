using System.Linq;
using NUnit.Framework;
using PicNetML.RuntimeHelpers;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests.RuntimeHelpers
{
  [TestFixture] public class AttributesRemoverTests
  {
    [Test] public void test_removing_attributes_by_index()
    {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var ar = new AttributesRemover(rt);
      var initial = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      ar.RemoveAttributes(2, 3);
      var after = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      Assert.AreEqual(new [] {"survived","pclass","sex","embarked"}, initial);
      Assert.AreEqual(new [] {"survived","pclass"}, after);
    }

    [Test] public void test_removing_attributes_by_names()
    {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var ar = new AttributesRemover(rt);
      var initial = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      ar.RemoveAttributes("embarked", "sex");
      var after = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      Assert.AreEqual(new [] {"survived","pclass","sex","embarked"}, initial);
      Assert.AreEqual(new [] {"survived","pclass"}, after);
    }

    [Test] public void test_keep_attributes_by_index()
    {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var ar = new AttributesRemover(rt);
      var initial = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      ar.KeepAttributes(0, 2, 3);
      var after = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      Assert.AreEqual(new [] {"survived","pclass","sex","embarked"}, initial);
      Assert.AreEqual(new [] {"survived", "sex","embarked"}, after);
    }

    [Test] public void test_keep_attributes_by_names()
    {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var ar = new AttributesRemover(rt);
      var initial = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      ar.KeepAttributes("survived", "embarked", "sex");
      var after = rt.EnumerateAttributes.Select(a => a.Name).ToArray();
      Assert.AreEqual(new [] {"survived","pclass","sex","embarked"}, initial);
      Assert.AreEqual(new [] {"survived", "sex","embarked"}, after);
    }
  }
}
