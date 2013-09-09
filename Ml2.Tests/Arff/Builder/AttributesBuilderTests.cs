using System;
using System.Collections.Generic;
using System.Linq;
using Ml2.Arff;
using Ml2.Arff.Builder;
using NUnit.Framework;

namespace Ml2.Tests.Arff.Builder
{
  // ReSharper disable UnusedMember.Local
  // ReSharper disable UnusedAutoPropertyAccessor.Local
  [TestFixture] public class AttributesBuilderTests
  {    
    private class NumericAtt { public double Att1 { get;set; } }    
    [Test] public void numeric_attributes() {
      var atts = Build<NumericAtt>();
      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsNumeric);
    }

    private class StringAtt { public string Att1 { get;set; } }    
    [Test] public void string_attributes() {
      var atts = Build<StringAtt>();
      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsString);
    }

    private class DateAtt { public DateTime Att1 { get;set; } }    
    [Test] public void date_attributes() {
      var atts = Build<DateAtt>();
      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsDate);
    }

    private class NominalEnumAtt { public StringSplitOptions Att1 { get;set; } }
    [Test] public void enum_nominal() {
      var atts = Build<NominalEnumAtt>();

      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(2, atts[0].NumValues);
      Assert.AreEqual(0, atts[0].IndexOfValue(StringSplitOptions.None.ToString()));
      Assert.AreEqual(1, atts[0].IndexOfValue(StringSplitOptions.RemoveEmptyEntries.ToString()));
    }

    private class NominalSpecifiedAtt { [Nominal("a,b,c")] public string Att1 { get;set; } }
    [Test] public void nominal_with_specified_values() {
      var atts = Build<NominalSpecifiedAtt>();

      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(3, atts[0].NumValues);
      Assert.AreEqual(0, atts[0].IndexOfValue("a"));
      Assert.AreEqual(1, atts[0].IndexOfValue("b"));
      Assert.AreEqual(2, atts[0].IndexOfValue("c"));
    }
    
    private class NominalString { [Nominal] public string Att1 { get;set; } }
    [Test] public void nominal_with_inferred_values() {
      var atts = Build(new [] { new NominalString { Att1 = "a" }, new NominalString { Att1 = "z" }});

      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(2, atts[0].NumValues);
      Assert.AreEqual(0, atts[0].IndexOfValue("a"));
      Assert.AreEqual(1, atts[0].IndexOfValue("z"));
    }

    private class WithIgnoreAtt { public string Att1 { get;set; } [IgnoreFeature] public string Att2 { get;set; } }
    [Test] public void with_ignore_attribute() {
      var atts = Build<WithIgnoreAtt>();

      Assert.AreEqual(1, atts.Count);      
      Assert.IsTrue(atts[0].IsString);
    }

    private class WithBinarizeAtt { [Binarize] public StringSplitOptions Att1 { get;set; }}
    [Test] public void with_binarize_attribute() {
      var atts = Build<WithBinarizeAtt>();
      Assert.AreEqual(3, atts.Count);      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue(StringSplitOptions.None.ToString()));
      Assert.AreEqual(1, atts[0].IndexOfValue(StringSplitOptions.RemoveEmptyEntries.ToString()));

      Assert.IsTrue(atts[1].IsNominal);
      Assert.AreEqual(0, atts[1].IndexOfValue("0"));
      Assert.AreEqual(1, atts[1].IndexOfValue("1"));

      Assert.IsTrue(atts[2].IsNominal);
      Assert.AreEqual(0, atts[2].IndexOfValue("0"));
      Assert.AreEqual(1, atts[2].IndexOfValue("1"));
    }

    private class WithBinarizeAndIgnoreAtt { [Binarize, IgnoreFeature] public StringSplitOptions Att1 { get;set; }}
    [Test] public void with_binarize_and_ignore_attributes() {
      var atts = Build<WithBinarizeAndIgnoreAtt>();
      Assert.AreEqual(2, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue("0"));
      Assert.AreEqual(1, atts[0].IndexOfValue("1"));

      Assert.IsTrue(atts[1].IsNominal);
      Assert.AreEqual(0, atts[1].IndexOfValue("0"));
      Assert.AreEqual(1, atts[1].IndexOfValue("1"));
    }

    private class WithAppendHasAtt { [Nominal("a,b"), AppendHasClassifier(1)] public string Att1 { get;set; }}
    [Test] public void with_append_has_att() {
      var atts = Build<WithAppendHasAtt>();
      Assert.AreEqual(2, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue("a"));
      Assert.AreEqual(1, atts[0].IndexOfValue("b"));

      Assert.IsTrue(atts[1].IsNominal);
      Assert.AreEqual(0, atts[1].IndexOfValue("0"));
      Assert.AreEqual(1, atts[1].IndexOfValue("1"));
    }

    private class WithAppendHasAndIgnoreAtt { [IgnoreFeature, Nominal("a,b"), AppendHasClassifier(1)] public string Att1 { get;set; }}
    [Test] public void with_append_has_and_ignore_atts() {
      var atts = Build<WithAppendHasAndIgnoreAtt>();
      Assert.AreEqual(1, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue("0"));
      Assert.AreEqual(1, atts[0].IndexOfValue("1"));
    }

    private class ExtendableInner { public StringSplitOptions Att1 { get;set; }}
    [Test] public void externdable_with_no_additionals() {
      var atts = Build(new [] { ExtendableObj.Create(new ExtendableInner()) });

      Assert.AreEqual(1, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue(StringSplitOptions.None.ToString()));
      Assert.AreEqual(1, atts[0].IndexOfValue(StringSplitOptions.RemoveEmptyEntries.ToString()));
    }

    [Test] public void externdable_with_some_extended() {
      var o = ExtendableObj.Create(new ExtendableInner()).
        AddBinary("nom1", true).
        AddDate("date1", DateTime.Now).
        AddNominal("nom2", "a").
        AddNumerical("num1", 1).
        AddString("str1", "val");
      var atts = Build(new [] { o });

      // NOTE: The order below is actually fixed, that 
      // is: binary, date, nom, num, str.
      Assert.AreEqual(6, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue(StringSplitOptions.None.ToString()));
      Assert.AreEqual(1, atts[0].IndexOfValue(StringSplitOptions.RemoveEmptyEntries.ToString()));

      Assert.IsTrue(atts[1].IsNominal);
      Assert.AreEqual(0, atts[1].IndexOfValue("0"));
      Assert.AreEqual(1, atts[1].IndexOfValue("1"));

      Assert.IsTrue(atts[2].IsDate);            

      Assert.IsTrue(atts[3].IsNominal);
      Assert.AreEqual(0, atts[3].IndexOfValue("a"));

      Assert.IsTrue(atts[4].IsNumeric);

      Assert.IsTrue(atts[5].IsString);      
    }

    [Test] public void extendable_with_append_has_att() {
       var o = ExtendableObj.Create(new WithAppendHasAtt()).
        AddBinary("nom1", true).
        AddDate("date1", DateTime.Now).
        AddNominal("nom2", "a").
        AddNumerical("num1", 1).
        AddString("str1", "val");
      var atts = Build(new [] { o });
      Assert.AreEqual(7, atts.Count);      
      
      Assert.IsTrue(atts[0].IsNominal);
      Assert.AreEqual(0, atts[0].IndexOfValue("a"));
      Assert.AreEqual(1, atts[0].IndexOfValue("b"));     

      // Extendables:

      Assert.IsTrue(atts[1].IsNominal);
      Assert.AreEqual(0, atts[1].IndexOfValue("0"));
      Assert.AreEqual(1, atts[1].IndexOfValue("1"));

      Assert.IsTrue(atts[2].IsDate);            

      Assert.IsTrue(atts[3].IsNominal);
      Assert.AreEqual(0, atts[3].IndexOfValue("a"));

      Assert.IsTrue(atts[4].IsNumeric);

      Assert.IsTrue(atts[5].IsString);  

      // Has Att
      Assert.IsTrue(atts[6].IsNominal);
      Assert.AreEqual(0, atts[6].IndexOfValue("0"));
      Assert.AreEqual(1, atts[6].IndexOfValue("1"));
    }

    private class FlattenClass { [Flatten(5)] public int[] Att1 { private get;set; }}
    [Test] public void flatten_attribute() {
      var rows = new [] {
        new FlattenClass { Att1 = new [] {1,2,3,4,5}},
        new FlattenClass { Att1 = new [] {6,7,8,9,10}}
      };
      var atts = Build(rows);
      Assert.AreEqual(5, atts.Count);
      Assert.IsTrue(atts.All(a => a.IsNumeric));
    }

    private List<Ml2Attribute> Build<T>(T[] rows = null) where T : new() { 
      return new AttributesBuilder<T>(rows ?? new [] { new T() }).BuildAttributes(); 
    }
  }
}