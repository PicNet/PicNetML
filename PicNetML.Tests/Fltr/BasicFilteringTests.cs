using System.Linq;
using NUnit.Framework;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests.Fltr {
  [TestFixture] public class BasicFilteringTests {
    [Test] public void test_basic_unsupervised_instance_filtering() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var newrt = rt.Filters.UnsupervisedInstance.RemoveRange.
        InstancesIndices("1-100").
        RunFilter();
      Assert.AreEqual(rt.NumInstances, newrt.NumInstances + 100);
    }
    
    [Test] public void test_basic_supervised_instance_filtering() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var newrt = rt.Filters.SupervisedInstance.SpreadSubsample.
        DistributionSpread(1.0).
        RunFilter();
      Assert.AreEqual(rt.NumInstances, 891);
      Assert.AreEqual(newrt.NumInstances, 684);
      Assert.AreEqual(newrt.Count(i => i.ClassValue == 0.0), 342);
      Assert.AreEqual(newrt.Count(i => i.ClassValue == 1.0), 342);
    }
    
    [Test] public void test_basic_unsupervised_attribute_filtering() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var newrt = rt.Filters.UnsupervisedAttribute.RemoveByName.
        Expression("sex").
        RunFilter();
      Assert.AreEqual(rt.NumAttributes, newrt.NumAttributes + 1);
    }
    
    [Test] public void test_basic_supervised_attribute_filtering() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var newrt = rt.Filters.SupervisedAttribute.NominalToBinary.
        AttributeIndices("2"). // pcclass (1,2,3)
        RunFilter();
      // Add 3 new binary attributes and remove orignial
      Assert.AreEqual(rt.NumAttributes + 3 - 1, newrt.NumAttributes); 
    }
  }
}