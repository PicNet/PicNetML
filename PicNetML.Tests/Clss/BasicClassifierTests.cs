using System;
using System.Linq;
using NUnit.Framework;
using PicNetML.Clss;
using PicNetML.Tests.TestUtils;

namespace PicNetML.Tests.Clss {
  [TestFixture] public class BasicClassifierTests {
    [Test] public void test_simple_evaluation() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      rt.Classifiers.Trees.RandomForest.
          NumExecutionSlots(4).
          NumFeatures(5).
          NumTrees(50).
          EvaluateWithCrossValidation();
    }

    [Test] public void test_making_single_predictions_from_trained_model() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var classifier = rt.Classifiers.Trees.RandomForest.
          NumExecutionSlots(4).
          NumFeatures(5).
          NumTrees(50);

      var row = new TitanicDataRow {
        age = 10,
        pclass = "1",
        sex = "male",
        embarked = "C"
      };
      var prediction = classifier.Classify(row);
      var proba = classifier.ClassifyProba(row);
      Assert.AreEqual(0, prediction);
      Assert.IsTrue(proba < 0.5);
    }

    [Test] public void test_building_predictions_lines() {
      var rt = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv"));
      var cls = rt.Classifiers.Trees.RandomForest.
          NumExecutionSlots(4).
          NumFeatures(5).
          NumTrees(50);

      var testset = Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_test.csv"), preprocessor: TestLinePreproc);
      var count = testset.NumInstances;
      var lines = testset.GeneratePredictions(GeneratePredictionLine, cls);
      Assert.AreEqual(count, lines.Count);      
    }

    private string TestLinePreproc(string line) {
      // Need to add a survived column to test data to meet the contract defined
      // in TitanicRow below.
      var tokens = line.Split(',').ToList();
      tokens.Insert(1, "0");
      return String.Join(",", tokens);
    }

    private string GeneratePredictionLine(double prediction, int index) {
      return String.Format("{0},{1}", (index + 1), prediction);
    }

    [Test] public void testing_saving_and_loading_saved_model() {
      // Save
      Runtime.LoadFromFile<TitanicDataRow>(0, TestingHelpers.GetResourceFileName("titanic_train.csv")).
          Classifiers.Trees.RandomForest.
              NumExecutionSlots(4).
              NumFeatures(5).
              NumTrees(50).
              FlushToFile("titanic_randor_forest.model");
    
      // Load
      var classifier = BaseClassifier.Read("titanic_randor_forest.model");
      var row = new TitanicDataRow {
        age = 10,
        pclass = "1",
        sex = "male",
        embarked = "C"
      };
      // Classify
      var prediction = classifier.Classify(Runtime.BuildInstance(0, row));
      var proba = classifier.ClassifyProba(Runtime.BuildInstance(0, row));
      
      Assert.AreEqual(0, prediction);
      Assert.IsTrue(proba < 0.5);
    }
  }
}