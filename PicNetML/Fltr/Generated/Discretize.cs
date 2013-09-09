using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that discretizes a range of numeric attributes in the
  /// dataset into nominal attributes. Discretization is by simple binning. Skips
  /// the class attribute if
  /// set.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
  /// is<br/>	applied to the data.<br/>	(default: no)<br/>-B &lt;num&gt; = 	Specifies the
  /// (maximum) number of bins to divide numeric attributes into.<br/>	(default =
  /// 10)<br/>-M &lt;num&gt; = 	Specifies the desired weight of instances per bin
  /// for<br/>	equal-frequency binning. If this is set to a positive<br/>	number
  /// then the -B option will be ignored.<br/>	(default = -1)<br/>-F = 	Use
  /// equal-frequency instead of equal-width discretization.<br/>-O = 	Optimize number
  /// of bins using leave-one-out estimate<br/>	of estimated entropy (for
  /// equal-width discretization).<br/>	If this is set then the -B option will be
  /// ignored.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to
  /// Discretize. First and last are valid indexes.<br/>	(default: first-last)<br/>-V =
  /// 	Invert matching sense of column indexes.<br/>-D = 	Output binary
  /// attributes for discretized attributes.<br/>-Y = 	Use bin numbers rather than ranges
  /// for discretized attributes.
  /// </summary>
  public class Discretize : BaseFilter<weka.filters.unsupervised.attribute.Discretize>
  {
    public Discretize(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Discretize()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Discretize AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Number of bins.
    /// </summary>    
    public Discretize Bins (int numBins) {
      Impl.setBins(numBins);
      return this;
    }

    /// <summary>
    /// If set to true, equal-frequency binning will be used instead of
    /// equal-width binning.
    /// </summary>    
    public Discretize UseEqualFrequency (bool newUseEqualFrequency) {
      Impl.setUseEqualFrequency(newUseEqualFrequency);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public Discretize InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Make resulting attributes binary.
    /// </summary>    
    public Discretize MakeBinary (bool makeBinary) {
      Impl.setMakeBinary(makeBinary);
      return this;
    }

    /// <summary>
    /// Use bin numbers (eg BXofY) rather than ranges for for discretized
    /// attributes
    /// </summary>    
    public Discretize UseBinNumbers (bool useBinNumbers) {
      Impl.setUseBinNumbers(useBinNumbers);
      return this;
    }

    /// <summary>
    /// Optimize number of equal-width bins using leave-one-out. Doesn't work for
    /// equal-frequency binning
    /// </summary>    
    public Discretize FindNumBins (bool newFindNumBins) {
      Impl.setFindNumBins(newFindNumBins);
      return this;
    }

    /// <summary>
    /// Sets the desired weight of instances per interval for equal-frequency
    /// binning.
    /// </summary>    
    public Discretize DesiredWeightOfInstancesPerInterval (double newDesiredNumber) {
      Impl.setDesiredWeightOfInstancesPerInterval(newDesiredNumber);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Discretize AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Discretize IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}