PicNetML
========
PicNetML is a .Net wrapper for the [Weka](http://www.cs.waikato.ac.nz/ml/weka/) 
project.  It tries to address several shortcomings of Weka:
* It’s not .Net
* Some parts of the API could be a little easier to use
* Working with files other than ARFF can be a little painful

License
-------
Weka is GPL so unfortunately this project is also GPL.

Weka
----
Weka is awesome, so thanks and kudos to the Weka team and contributors.

Quick Start
-----------
For the benefit of this guide we will be using a unit testing project.  But this 
could just as easily be a wpf, web, console or windows service.  This guide uses 
data from Kaggle's Titanic training competition.

* Create a new Unit Test Project
* Download some [data](http://www.kaggle.com/c/titanic-gettingStarted/download/train.csv)
  and [a bit more](http://www.kaggle.com/c/titanic-gettingStarted/download/test.csv)
* Use NuGet to install the PicNetML package.
    * Tools -> Library Package Manager -> Manage NuGet Packages for Solution
    * Search for PicNetML
    * Click and Install, selecting the test project previously created
* Create a C# file called 'TitanicRow.cs' with the following content:

```csharp
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicNetML.Arff;
    
namespace TestingProjectName {
  public class TitanicRow {
    [IgnoreFeature] public string passengerid { get; set; }
    [Nominal("0,1")] public string survived { get; set; }
    [Nominal("1,2,3")] public string pclass { get; set; }
    [IgnoreFeature] public string name { get; set; }
    [Nominal("male,female")] public string sex { get; set; }
    [IgnoreFeature] public double age { get; set; }
    [IgnoreFeature] public int sibsp { get; set; }
    [IgnoreFeature] public int parch { get; set; }
    [IgnoreFeature] public string ticket { get; set; }
    [IgnoreFeature] public string fare { get; set; }
    [IgnoreFeature] public string cabin { get; set; }
    [Nominal("C,Q,S")] public string embarked { get; set; }
        
    // We can also add some custom properies such as:
        
    [Nominal] public string agec { get {
      if (age <= 0 || age >= 100) return "NA";
      if (age < 4) return "toddler";
      if (age < 7) return "infant";
      if (age < 14) return "child";
      if (age < 20) return "youth";
      if (age < 40) return "adult";
      if (age < 80) return "middleaged";
      if (age < 100) return "old";
          
      throw new ApplicationException("Invalid age: " + age);
    } }
  }
}
```

* Run a classifier on the data.  For this example we will just run a simple 
Random Forest classifier on this data.

```csharp
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicNetML;
using PicNetML.Arff;
    
namespace TestingProjectName {
  [TestClass] public class TestClass {
    [TestMethod] public void Evaluate() {
      var runtime = Runtime.LoadFromFile<TitanicRow>(0, @"..\..\train.csv");
      runtime.Classifiers.Trees.RandomForest.
          NumExecutionSlots(4).
          NumFeatures(5).
          NumTrees(50).
          EvaluateWithCrossValidation();
    }
  }
}
```
 
* Run the test and read the results of your evaluation in the console.
 
Making Single Predictions
-------------------------

```csharp
[TestMethod] public void MakePredictions() {
  var runtime = Runtime.LoadFromFile<TitanicRow>(0, @"..\..\train.csv");
  var classifier = runtime.Classifiers.Trees.RandomForest.
      NumExecutionSlots(4).
      NumFeatures(5).
      NumTrees(50);
      
  var row = new TitanicRow {
    age = 10,
    pclass = "1",
    sex = "male",
    embarked = "C"
  };
  var prediction = classifier.Classify(row);
  var proba = classifier.ClassifyProba(row);
  Console.WriteLine("Prediction: " + prediction + " probability: " + proba);
}
```
  
Building Prediction Files
-------------------------
Generating prediction files is very straight forward you need 2 runtimes created 
the training set runtime and the testing set runtime.  In this example we see 
that because the test.csv file from Kaggle is slightly different in formatting 
than the train.csv file we need to pass in a pre-processor to the 
Runtime.LoadFromFile method.  This method simply massages each line in the 
test.csv file to meet the expected format that train.csv uses.

```csharp
[TestMethod] public void BuildPredictionsFile() {
  var runtime = Runtime.LoadFromFile<TitanicRow>(0, @"..\..\train.csv");
  var cls = runtime.Classifiers.Trees.RandomForest.
      NumExecutionSlots(4).
      NumFeatures(5).
      NumTrees(50);

  var tst = @"..\..\test.csv";
  var testset = Runtime.
      LoadFromFile<TitanicRow>(0, tst, preprocessor: TestLinePreproc);      
  var lines = testset.GeneratePredictions(GeneratePredictionLine, cls);
  lines.Insert(0, "Prediction,Index"); // Insert Header Row
  File.WriteAllLines("predictions.csv", lines);      
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
```

Saving and Reusing Models
-------------------------
Training models can be slow so we do not want to build the model each time a 
prediction is needed.  The way to solve this issue is by saving the model and 
reusing it later.  This is shown by the 2 tests below.

```csharp
[TestMethod] public void BuildAndSaveModel() {
  Runtime.LoadFromFile<TitanicRow>(0, @"..\..\train.csv").
      Classifiers.Trees.RandomForest.
          NumExecutionSlots(4).
          NumFeatures(5).
          NumTrees(50).
          FlushToFile("titanic_randor_forest.model");
}

[TestMethod] public void LoadAndUseModel() {
  var classifier = BaseClassifier.Read("titanic_randor_forest.model");
  var row = new TitanicRow {
    age = 10,
    pclass = "1",
    sex = "male",
    embarked = "C"
  };
  var prediction = classifier.Classify(Runtime.BuildInstance(0, row));
  var proba = classifier.ClassifyProba(Runtime.BuildInstance(0, row));
  Console.WriteLine("Prediction: " + prediction + " probability: " + proba);
}
```

Using the Source
----------------
If you would like to contribute a patch or would just rather work directly out
of git just follow these steps:

- Clone the repo: git clone https://github.com/PicNet/PicNetML.git
- Reference the PicNetML project in your project
- Add a reference to all DLLs in the lib directory (root directory only)
- That’s it, that's all the NuGet package does

Navigating Around PicNetML
--------------------------
Navigation and auto-discovery was one of the main drivers for creating PicNetML.
You just need to start with a Runtime and the easiest way to do this is to load
a runtime like shown in the quick start above.  Once you have a runtim you then
have 5 major directions you can go:

* runtime.AttributeSelections - All the attribute selection algorithms, 
  including all supervised and unsupervised algorithms. 
* runtime.Clusterers - Clustering algorithms.
* runtime.Filters - Attribute and instance filtering algorithms.
* runtime.Associations - Association rule mining algorithms.
* runtime.Classifiers - Classifiers and regressions.

Please use your IDE at this stage.  There are comprehensive comments describing
all algorithms (thanks to Weka for their diligence in this area).  Just hover
your mouse over an algorithm and read the docs.  Using this technique you will
quickly find what you are after.

Comments
--------
This project is used by PicNet for all exploratory analysis of data.  We then 
either stay in the Weka environment or move to scikit-learn or Mahout for more 
performance sensitive work.  This project currently meets most of our needs in 
terms of exploratory data analysis and when we require features we add them.  
However, releasing this code to the public is in no way a commitment that 
PicNet or myself (Guido Tapia) will provide support for this library now or in 
the future.  

However, I will be more than happy to chat/email anyone and help them get 
started adding features to the system.  You can also record any bugs or 
enhancement requests in the Issues list here in github and they may be done in 
the future by PicNet or external contributors but it may also be totally 
ignored.

A Note About PicNet Predictive Analytics Services
-------------------------------------------------
PicNet has a long history of building quality software for large organisations 
(over 11 years).  In the last 2 years we have started making predictive 
analytics part of our offering.  Whether its an embedded prediction model or 
recommender in a web application or a stand alone system that runs in the 
background doing predictive work or anomaly detection.  If you have any 
requirements in this area please feel free to [contact us](http://www.picnet.com.au) 
and we will help you achieve your data goals.
