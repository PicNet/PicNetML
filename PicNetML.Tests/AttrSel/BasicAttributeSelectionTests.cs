using System.Linq;
using NUnit.Framework;
using PicNetML.AttrSel.Algs;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests.AttrSel {
  [TestFixture] public class BasicAttributeSelectionTests {
    [Test] public void simple_attribute_selection_tests_with_indexes() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var alg = rt.AttributeSelections.Algorithms.BestFirst.
          Direction(BestFirst.EDirection.Bi_directional).
          LookupCacheSize(10);
      var eval = rt.AttributeSelections.Evaluators.CfsSubset.
        LocallyPredictive(true).
        MissingSeparate(true);

      var indexes = alg.SearchIndexes(eval);
      Assert.AreEqual(new[] {2, 0}, indexes); 
    }     

    [Test] public void simple_attribute_selection_tests_with_new_runtime() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var alg = rt.AttributeSelections.Algorithms.BestFirst.
          Direction(BestFirst.EDirection.Bi_directional).
          LookupCacheSize(10);
      var eval = rt.AttributeSelections.Evaluators.CfsSubset.
        LocallyPredictive(true).
        MissingSeparate(true);

      var newrt = alg.Search(eval);
      var names = newrt.EnumerateAttributes.Select(a => a.Name).ToArray();
      Assert.AreEqual(new[] {"sex", "survived"}, names); 
    }     
  }
}