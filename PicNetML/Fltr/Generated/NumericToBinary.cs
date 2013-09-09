using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Converts all numeric attributes into binary attributes (apart from the
  /// class attribute, if set): if the value of the numeric attribute is exactly
  /// zero, the value of the new attribute will be zero. If the value of the
  /// numeric attribute is missing, the value of the new attribute will be missing.
  /// Otherwise, the value of the new attribute will be one. The new attributes will
  /// be nominal.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets
  /// the class index temporarily before the filter is<br/>	applied to the
  /// data.<br/>	(default: no)
  /// </summary>
  public class NumericToBinary : BaseFilter<weka.filters.unsupervised.attribute.NumericToBinary>
  {
    public NumericToBinary(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NumericToBinary()) {
      
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public NumericToBinary IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}