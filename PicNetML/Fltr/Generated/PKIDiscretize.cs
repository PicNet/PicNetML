using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Discretizes numeric attributes using equal frequency binning, where the
  /// number of bins is equal to the square root of the number of non-missing
  /// values.<br/><br/>For more information, see:<br/><br/>Ying Yang, Geoffrey I.
  /// Webb: Proportional k-Interval Discretization for Naive-Bayes Classifiers. In:
  /// 12th European Conference on Machine Learning, 564-575,
  /// 2001.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily
  /// before the filter is<br/>	applied to the data.<br/>	(default: no)<br/>-R
  /// &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to Discretize. First
  /// and last are valid indexes.<br/>	(default: first-last)<br/>-V = 	Invert
  /// matching sense of column indexes.<br/>-D = 	Output binary attributes for
  /// discretized attributes.
  /// </summary>
  public class PKIDiscretize : BaseFilter<weka.filters.unsupervised.attribute.PKIDiscretize>
  {
    public PKIDiscretize(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.PKIDiscretize()) {
      
    }

    /// <summary>
    /// Ignored.
    /// </summary>    
    public PKIDiscretize FindNumBins (bool newFindNumBins) {
      Impl.setFindNumBins(newFindNumBins);
      return this;
    }

    /// <summary>
    /// Always true.
    /// </summary>    
    public PKIDiscretize UseEqualFrequency (bool newUseEqualFrequency) {
      Impl.setUseEqualFrequency(newUseEqualFrequency);
      return this;
    }

    /// <summary>
    /// Ignored.
    /// </summary>    
    public PKIDiscretize Bins (int numBins) {
      Impl.setBins(numBins);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public PKIDiscretize AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public PKIDiscretize InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Make resulting attributes binary.
    /// </summary>    
    public PKIDiscretize MakeBinary (bool makeBinary) {
      Impl.setMakeBinary(makeBinary);
      return this;
    }

    /// <summary>
    /// Use bin numbers (eg BXofY) rather than ranges for for discretized
    /// attributes
    /// </summary>    
    public PKIDiscretize UseBinNumbers (bool useBinNumbers) {
      Impl.setUseBinNumbers(useBinNumbers);
      return this;
    }

    /// <summary>
    /// Sets the desired weight of instances per interval for equal-frequency
    /// binning.
    /// </summary>    
    public PKIDiscretize DesiredWeightOfInstancesPerInterval (double newDesiredNumber) {
      Impl.setDesiredWeightOfInstancesPerInterval(newDesiredNumber);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public PKIDiscretize AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public PKIDiscretize IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}