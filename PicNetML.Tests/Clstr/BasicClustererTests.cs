using NUnit.Framework;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests.Clstr {
  [TestFixture] public class BasicClustererTests {
     [Test] public void test_basic_clustering() {
       var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));

       // Remove the classifier (which upsets clusterers)
       rt = rt.Filters.UnsupervisedAttribute.Remove.AttributeIndices("1").RunFilter();

       var clusterer = rt.Clusterers.SimpleKMeans.
         NumClusters(10).
         Build();

       Assert.AreEqual(1, clusterer.ClusterInstance(rt[0]));
       Assert.AreEqual(0, clusterer.ClusterInstance(rt[2]));
       Assert.AreEqual(0, clusterer.ClusterInstance(rt[3]));
       Assert.AreEqual(1, clusterer.ClusterInstance(rt[4]));
     }
  }
}