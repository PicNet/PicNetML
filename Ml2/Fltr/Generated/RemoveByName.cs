using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Removes attributes based on a regular expression matched against their
  /// names.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
  /// information.<br/>-E &lt;regular expression&gt; = 	The regular expression to match
  /// the attribute names against.<br/>	(default: ^.*id$)<br/>-V = 	Flag for
  /// inverting the matching sense. If set, attributes are kept<br/>	instead of
  /// deleted.<br/>	(default: off)
  /// </summary>
  public class RemoveByName : BaseFilter<weka.filters.unsupervised.attribute.RemoveByName>
  {
    public RemoveByName(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RemoveByName()) {
      
    }

    /// <summary>
    /// The regular expression to match the attribute names against.
    /// </summary>    
    public RemoveByName Expression (string value) {
      Impl.setExpression(value);
      return this;
    }

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public RemoveByName InvertSelection (bool value) {
      Impl.setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RemoveByName Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}