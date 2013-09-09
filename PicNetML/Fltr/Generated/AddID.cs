using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that adds an ID attribute to the dataset. The new
  /// attribute contains a unique ID for each instance.<br/>Note: The ID is not reset
  /// for the second batch of files (using -b and -r and
  /// -s).<br/><br/>Options:<br/><br/>-C &lt;index&gt; = 	Specify where to insert the ID. First and
  /// last<br/>	are valid indexes.(default first)<br/>-N &lt;name&gt; = 	Name of the
  /// new attribute.<br/>	(default = 'ID')
  /// </summary>
  public class AddID : BaseFilter<weka.filters.unsupervised.attribute.AddID>
  {
    public AddID(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.AddID()) {
      
    }

    /// <summary>
    /// Set the new attribute's name.
    /// </summary>    
    public AddID AttributeName (string value) {
      Impl.setAttributeName(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddID IDIndex (string value) {
      Impl.setIDIndex(value);
      return this;
    }

        
        
  }
}