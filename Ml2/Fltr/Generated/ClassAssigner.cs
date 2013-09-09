using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filter that can set and unset the class
  /// index.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-C
  /// &lt;num|first|last|0&gt; = 	The index of the class attribute. Index starts with 1,
  /// 'first'<br/>	and 'last' are accepted, '0' unsets the class index.<br/>	(default: last)
  /// </summary>
  public class ClassAssigner : BaseFilter<weka.filters.unsupervised.attribute.ClassAssigner>
  {
    public ClassAssigner(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.ClassAssigner()) {
      
    }

    /// <summary>
    /// The index of the class attribute, starts with 1, 'first' and 'last' are
    /// accepted as well, '0' unsets the class index.
    /// </summary>    
    public ClassAssigner ClassIndex (string value) {
      Impl.setClassIndex(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public ClassAssigner Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}