using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Adds the labels from the given list to an attribute if they are missing.
  /// The labels can also be sorted in an ascending manner. If no labels are
  /// provided then only the (optional) sorting
  /// applies.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index<br/>	(default last).<br/>-L
  /// &lt;label1,label2,...&gt; = 	Comma-separated list of labels to
  /// add.<br/>	(default: none)<br/>-S = 	Turns on the sorting of the labels.
  /// </summary>
  public class AddValues : BaseFilter<weka.filters.unsupervised.attribute.AddValues>
  {
    public AddValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.AddValues()) {
      
    }

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public AddValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Comma-separated list of lables to add.
    /// </summary>    
    public AddValues Labels (string value) {
      Impl.setLabels(value);
      return this;
    }

    /// <summary>
    /// Whether to sort the labels alphabetically.
    /// </summary>    
    public AddValues Sort (bool value) {
      Impl.setSort(value);
      return this;
    }

        
        
  }
}