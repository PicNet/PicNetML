using System;
using System.Linq;

namespace PicNetML.Arff
{  
  public class NominalAttribute : Attribute {
    internal string CommaSeparatedValues { private set; get; }
    public NominalAttribute(string csv = null) { CommaSeparatedValues = csv; }
  }

  public class AppendHasClassifierAttribute : NominalAttribute {
    internal double Classifier { private set; get; }
    public AppendHasClassifierAttribute(double classifier) { Classifier = classifier; }
  }

  public class GroupedNominalAttribute : NominalAttribute {
    internal GroupedNominalAttribute() {} // Only used internally
  }

  public class NominalGroupWhenLessThanAttribute : GroupedNominalAttribute {
    internal int Min { private set; get; }
    public NominalGroupWhenLessThanAttribute(int min) { 
      if (min <= 1) throw new ArgumentOutOfRangeException("min", min, "Minimum value must be 2 or more.");
      Min = min; 
    }
  }

  public class NominalGroupMaxBinsAttribute : GroupedNominalAttribute {
    internal int Max { private set; get; }
    public NominalGroupMaxBinsAttribute (int max) { 
      if (max <= 1) throw new ArgumentOutOfRangeException("max", max, "Max value must be > 1");
      Max = max;
    }
  }

  public class DiscretiseToUpperBoundariesAttribute : Attribute {
    internal double[] UpperClosedBoundaries { private set; get; }

    public DiscretiseToUpperBoundariesAttribute(string upperboundaries) { 
      if (String.IsNullOrEmpty(upperboundaries)) throw new ArgumentNullException("upperboundaries");
      UpperClosedBoundaries = upperboundaries.Split(',').Select(s => Double.Parse(s.Trim())).ToArray();
      if (UpperClosedBoundaries.Length == 0) throw new ArgumentException("No valid numerical intervals found", "upperboundaries");       

      throw new NotImplementedException("DiscretiseToUpperBoundariesAttribute is not implemented, use custom getters");
    }
  }

  public class MissingValueAttribute : Attribute {
    internal string MissingValue { private set; get; }

    public MissingValueAttribute(string missingvalue) { 
      if (String.IsNullOrEmpty(missingvalue)) throw new ArgumentNullException("missingvalue");
      MissingValue = missingvalue;

      throw new NotImplementedException("MissingValueAttribute is not implemented, use custom getters");
    }    
  }

  public class IgnoreFeatureAttribute : Attribute {}
  public class BinarizeAttribute : Attribute {}
  public class FlattenAttribute : Attribute {
    public int IntoHowMany { private set; get; }
    
    public FlattenAttribute(int intoHowMany) { 
      IntoHowMany = intoHowMany; 
      throw new NotImplementedException("FlattenAttribute is not implemented, use custom getters");
    }
  }
}