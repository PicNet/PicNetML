using System;
using System.Linq;
using PicNetML.Arff;
using PicNetML.Arff.Builder;
using NUnit.Framework;

namespace PicNetML.Tests.Arff.Builder
{
  [TestFixture] public class InstanceBuilderTests
  {    
    internal class TestingRow {
      public double CLASS { get; set; }
      [Nominal, Binarize] public int ATT_1 { get; set; } [Nominal, Binarize] public int ATT_2 { get; set; }    
      [Nominal, Binarize] public int ATT_3 { get; set; } [Nominal, Binarize] public int ATT_4 { get; set; }
      [Nominal, Binarize] public int ATT_5 { get; set; } [Nominal, Binarize] public int ATT_6 { get; set; }
      [Nominal, Binarize] public int ATT_7 { get; set; } [Nominal, Binarize] public int ATT_8 { get; set; }
    }

    [Test] public void test_binarisation_in_instances_builder() {
      var rows = new [] { 
        new TestingRow { CLASS = 1, ATT_1 = 111,  ATT_2 = 222,  ATT_3 = 333,  ATT_4 = 444,  ATT_5 = 555,  ATT_6 = 666,  ATT_7 = 777, ATT_8 = 888 },
        new TestingRow { CLASS = 0, ATT_1 = 1112,  ATT_2 = 2222,  ATT_3 = 3332,  ATT_4 = 4442, ATT_5 = 5552,  ATT_6 = 6662,  ATT_7 = 7772,  ATT_8 = 8882 }
      };
      var instances = new InstancesBuilder<TestingRow>(rows, 0).Build();

      Assert.AreEqual(25, instances.numAttributes());
      
      var i1 = instances.instance(0);
      var i2 = instances.instance(1);
      
      // These are the standard properties
      Assert.AreEqual(1.0, i1.value(0)); Assert.AreEqual(1.0, i1.classValue()); 
      Assert.AreEqual(0.0, i2.value(0)); Assert.AreEqual(0.0, i2.classValue()); 
      Assert.AreEqual(0.0, i1.value(1)); Assert.AreEqual("111", i1.stringValue(1));
      Assert.AreEqual(1.0, i2.value(1)); Assert.AreEqual("1112", i2.stringValue(1));
      Assert.AreEqual(0.0, i1.value(2)); Assert.AreEqual("222", i1.stringValue(2));
      Assert.AreEqual(1.0, i2.value(2)); Assert.AreEqual("2222", i2.stringValue(2));
      Assert.AreEqual(0.0, i1.value(3)); Assert.AreEqual("333", i1.stringValue(3));
      Assert.AreEqual(1.0, i2.value(3)); Assert.AreEqual("3332", i2.stringValue(3));
      Assert.AreEqual(0.0, i1.value(4)); Assert.AreEqual("444", i1.stringValue(4));
      Assert.AreEqual(1.0, i2.value(4)); Assert.AreEqual("4442", i2.stringValue(4));
      Assert.AreEqual(0.0, i1.value(5)); Assert.AreEqual("555", i1.stringValue(5));
      Assert.AreEqual(1.0, i2.value(5)); Assert.AreEqual("5552", i2.stringValue(5));
      Assert.AreEqual(0.0, i1.value(6)); Assert.AreEqual("666", i1.stringValue(6));
      Assert.AreEqual(1.0, i2.value(6)); Assert.AreEqual("6662", i2.stringValue(6));
      Assert.AreEqual(0.0, i1.value(7)); Assert.AreEqual("777", i1.stringValue(7));
      Assert.AreEqual(1.0, i2.value(7)); Assert.AreEqual("7772", i2.stringValue(7));
      Assert.AreEqual(0.0, i1.value(8)); Assert.AreEqual("888", i1.stringValue(8));
      Assert.AreEqual(1.0, i2.value(8)); Assert.AreEqual("8882", i2.stringValue(8));

      // These are the new binarized
      for (int i = 9; i < 25; i+=2) {
        Assert.AreEqual(1.0, i1.value(i)); Assert.AreEqual(0.0, i2.value(i));
        Assert.AreEqual(0.0, i1.value(i+1)); Assert.AreEqual(1.0, i2.value(i+1)); 
      }      
    }

    internal class TestingRow2 {
      public double CLASS { get; set; }
      [NominalGroupWhenLessThan(2)] public string ATT_1 { get; set; }    
      [NominalGroupWhenLessThan(3)] public string ATT_2 { get; set; }    
    }

    [Test] public void test_grouping_when_less_than_2() {
      var rows = new [] { 
        new TestingRow2 { ATT_1 = "1" },
        new TestingRow2 { ATT_1 = "1" },
        new TestingRow2 { ATT_1 = "1" },
        new TestingRow2 { ATT_1 = "2" },
        new TestingRow2 { ATT_1 = "3" }
      };
      var instances = new InstancesBuilder<TestingRow2>(rows, 0).Build();

      Assert.AreEqual(3, instances.numAttributes());
      Assert.AreEqual(5, instances.numInstances());      

      Assert.AreEqual("1", instances.instance(0).stringValue(1));
      Assert.AreEqual("1", instances.instance(1).stringValue(1));
      Assert.AreEqual("1", instances.instance(2).stringValue(1));
      Assert.AreEqual("Others", instances.instance(3).stringValue(1));
      Assert.AreEqual("Others", instances.instance(4).stringValue(1));
    }

    [Test] public void test_grouping_when_less_than_3() {
      var rows = new [] { 
        new TestingRow2 { ATT_2 = "1" },
        new TestingRow2 { ATT_2 = "1" },
        new TestingRow2 { ATT_2 = "1" },
        new TestingRow2 { ATT_2 = "2" },
        new TestingRow2 { ATT_2 = "2" },
        new TestingRow2 { ATT_2 = "3" },
        new TestingRow2 { ATT_2 = "3" }
      };
      var instances = new InstancesBuilder<TestingRow2>(rows, 0).Build();

      Assert.AreEqual(3, instances.numAttributes());
      Assert.AreEqual(7, instances.numInstances());      

      Assert.AreEqual("1", instances.instance(0).stringValue(2));
      Assert.AreEqual("1", instances.instance(1).stringValue(2));
      Assert.AreEqual("1", instances.instance(2).stringValue(2));
      Assert.AreEqual("Others", instances.instance(3).stringValue(2));
      Assert.AreEqual("Others", instances.instance(4).stringValue(2));
      Assert.AreEqual("Others", instances.instance(5).stringValue(2));
      Assert.AreEqual("Others", instances.instance(6).stringValue(2));
    }

    internal class TestingRow3 {
      public double CLASS { get; set; }
      [Binarize, NominalGroupWhenLessThan(2)] public string ATT_1 { get; set; }    
    }

    [Test] public void test_goruping_then_binarizing() {
      var rows = new [] { 
        new TestingRow3 { ATT_1 = "1" },
        new TestingRow3 { ATT_1 = "1" },
        new TestingRow3 { ATT_1 = "1" },
        new TestingRow3 { ATT_1 = "2" },
        new TestingRow3 { ATT_1 = "3" }
      };
      var instances = new InstancesBuilder<TestingRow3>(rows, 0).Build();

      Assert.AreEqual(4, instances.numAttributes());
      Assert.AreEqual(5, instances.numInstances());      

      Assert.AreEqual("1", instances.instance(0).stringValue(1)); Assert.AreEqual("1", instances.instance(0).stringValue(2)); Assert.AreEqual("0", instances.instance(0).stringValue(3)); 
      Assert.AreEqual("1", instances.instance(1).stringValue(1)); Assert.AreEqual("1", instances.instance(1).stringValue(2)); Assert.AreEqual("0", instances.instance(1).stringValue(3));
      Assert.AreEqual("1", instances.instance(2).stringValue(1)); Assert.AreEqual("1", instances.instance(2).stringValue(2)); Assert.AreEqual("0", instances.instance(2).stringValue(3));
      Assert.AreEqual("Others", instances.instance(3).stringValue(1)); Assert.AreEqual("0", instances.instance(3).stringValue(2)); Assert.AreEqual("1", instances.instance(3).stringValue(3));
      Assert.AreEqual("Others", instances.instance(4).stringValue(1)); Assert.AreEqual("0", instances.instance(4).stringValue(2)); Assert.AreEqual("1", instances.instance(4).stringValue(3));
    }

    internal class TestingRow4 {
      public double CLASS { get; set; }
      [NominalGroupMaxBins(3)] public string ATT_1 { get; set; }    
    }

    [Test] public void test_goruping_with_max_bins() {
      var rows = new [] { 
        new TestingRow4 { ATT_1 = "1" },
        new TestingRow4 { ATT_1 = "1" },
        new TestingRow4 { ATT_1 = "1" },
        new TestingRow4 { ATT_1 = "2" },
        new TestingRow4 { ATT_1 = "2" },
        new TestingRow4 { ATT_1 = "3" },
        new TestingRow4 { ATT_1 = "3" },
        new TestingRow4 { ATT_1 = "4" },
        new TestingRow4 { ATT_1 = "5" }
      };
      var instances = new InstancesBuilder<TestingRow4>(rows, 0).Build();

      Assert.AreEqual(2, instances.numAttributes());
      Assert.AreEqual(9, instances.numInstances());      

      Assert.AreEqual("1", instances.instance(0).stringValue(1));     
      Assert.AreEqual("1", instances.instance(1).stringValue(1));     
      Assert.AreEqual("1", instances.instance(2).stringValue(1));     
      Assert.AreEqual("2", instances.instance(3).stringValue(1));     
      Assert.AreEqual("2", instances.instance(4).stringValue(1));     
      Assert.AreEqual("3", instances.instance(5).stringValue(1));     
      Assert.AreEqual("3", instances.instance(6).stringValue(1));     
      Assert.AreEqual("Others", instances.instance(7).stringValue(1));
      Assert.AreEqual("Others", instances.instance(8).stringValue(1));
    }

    internal class TestingRow5 {
      public double CLASS { get; set; }
      [Nominal, AppendHasClassifier(33)] public string ATT_1 { get; set; }    
    }

    [Test] public void test_has_class_value() {
      var rows = new [] { 
        new TestingRow5 { CLASS = 1.0, ATT_1 = "1" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "2" },
        new TestingRow5 { CLASS = 22.0, ATT_1 = "3" }
      };
      var instances = new InstancesBuilder<TestingRow5>(rows, 0).Build();

      Assert.AreEqual(3, instances.numAttributes());
      Assert.AreEqual(3, instances.numInstances());      

      CollectionAssert.AreEqual(new [] { "1", "2", "3" }, instances.GetAttrStrings(1));
      CollectionAssert.AreEqual(new [] { "0", "1", "0" }, instances.GetAttrStrings(2));
    }

    [Test] public void test_has_class_value_is_remembered() {
      var rows = new [] { 
        new TestingRow5 { CLASS = 1.0, ATT_1 = "1" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "2" },
        new TestingRow5 { CLASS = 22.0, ATT_1 = "3" },
        new TestingRow5 { CLASS = 22.0, ATT_1 = "2" }
      };
      var instances = new InstancesBuilder<TestingRow5>(rows, 0).Build();

      Assert.AreEqual(3, instances.numAttributes());
      Assert.AreEqual(4, instances.numInstances());      

      CollectionAssert.AreEqual(new [] { "1", "2", "3", "2" }, instances.GetAttrStrings(1));
      CollectionAssert.AreEqual(new [] { "0", "1", "0", "1" }, instances.GetAttrStrings(2));
    }

    [Test] public void test_has_class_value_with_limited_training_set() {
      var rows = new [] { 
        new TestingRow5 { CLASS = 1.0, ATT_1 = "1" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "2" },
        new TestingRow5 { CLASS = 22.0, ATT_1 = "3" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "4" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "5" },
        new TestingRow5 { CLASS = 11.0, ATT_1 = "2" }
      };
      var builder = new InstancesBuilder<TestingRow5>(rows, 0, 3);
      var instances = builder.Build();

      Assert.AreEqual(3, instances.numAttributes());
      Assert.AreEqual(6, instances.numInstances());      

      CollectionAssert.AreEqual(new [] { "1", "2", "3", "4", "5", "2" }, instances.GetAttrStrings(1));
      CollectionAssert.AreEqual(new [] { "0", "1", "0", "0", "0", "1" }, instances.GetAttrStrings(2));
    }
 
    internal class TestingRow6 {
      public double CLASS { get; set; }
      [Nominal] public string ATT_1 { get; set; }    
      [IgnoreFeature] public string ATT_2 { get; set; }    
      [Nominal] public string ATT_3 { get; set; }    
    }
   
    [Test] public void test_ignore_attributes() {
      var rows = new [] { 
        new TestingRow6 { CLASS = 1.0, ATT_1 = "1", ATT_2 = "1.1", ATT_3 = "1.2" },
        new TestingRow6 { CLASS = 2.0, ATT_1 = "2", ATT_2 = "2.1", ATT_3 = "2.2" }
      };
      var builder = new InstancesBuilder<TestingRow6>(rows, 0);
      var instances = builder.Build();

      Assert.AreEqual(3, instances.numAttributes()); // 1 is ignored
      Assert.AreEqual(2, instances.numInstances());      

      CollectionAssert.AreEqual(new [] { "1", "2" }, instances.GetAttrStrings(1));
      CollectionAssert.AreEqual(new [] { "1.2", "2.2" }, instances.GetAttrStrings(2));
    }
   
    private class FlattenClass { 
      public double CLASS { get; set; } 
      [Flatten(5)] public int[] Att1 { private get;set; }
    }

    // TODO: Finish implementation.  Attributes have duplicate names at the 
    // moment and InstanceBuilder has no implementation.
    [Test] public void flatten_attribute() {
      var rows = new [] {
        new FlattenClass { CLASS=0, Att1 = new [] {1,2,3,4,5}},
        new FlattenClass { CLASS=1, Att1 = new [] {6,7,8,9,10}}
      };
      var builder = new InstancesBuilder<FlattenClass>(rows, 0);
      var instances = builder.Build();
      
      Assert.AreEqual(2, instances.numInstances());      
      Assert.AreEqual(6, instances.numAttributes()); 

      CollectionAssert.AreEqual(new [] { "1", "2" }, instances.GetAttrStrings(1));
      CollectionAssert.AreEqual(new [] { "1.2", "2.2" }, instances.GetAttrStrings(2));
    }

    [Test] public void test_has_class_value_on_extendable() {
      var rows = new [] { 
        new TestingRow5 { CLASS = 1.0, ATT_1 = "1" },
        new TestingRow5 { CLASS = 33.0, ATT_1 = "2" },
        new TestingRow5 { CLASS = 22.0, ATT_1 = "3" }
      };
      var extendable = rows.Select(r => ExtendableObj.Create(r).AddNominal("added", "yes"));
      var instances = new InstancesBuilder<ExtendableObj<TestingRow5>>(extendable.ToArray(), 0).Build();

      Assert.AreEqual(4, instances.numAttributes());
      Assert.AreEqual(3, instances.numInstances());      

      CollectionAssert.AreEqual(
          new [] { 1.0, 33.0, 22.0 }, 
          instances.GetAttrDoubles(0),
          "Actual: " + String.Join(", ", instances.GetAttrDoubles(0)));
      CollectionAssert.AreEqual(
          new [] { "1", "2", "3" }, 
          instances.GetAttrStrings(1),
          "Actual: " + String.Join(", ", instances.GetAttrStrings(1)));
      CollectionAssert.AreEqual(
          new [] { "yes", "yes", "yes" }, 
          instances.GetAttrStrings(2),
          "Actual: " + String.Join(", ", instances.GetAttrStrings(2)));
    }
  }  
}