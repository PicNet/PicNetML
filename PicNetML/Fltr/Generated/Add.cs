using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that adds a new attribute to the dataset. The new
  /// attribute will contain all missing values.<br/><br/>Options:<br/><br/>-T
  /// &lt;NUM|NOM|STR|DAT&gt; = 	The type of attribute to create:<br/>	NUM = Numeric
  /// attribute<br/>	NOM = Nominal attribute<br/>	STR = String attribute<br/>	DAT =
  /// Date attribute<br/>	(default: NUM)<br/>-C &lt;index&gt; = 	Specify where
  /// to insert the column. First and last<br/>	are valid indexes.(default:
  /// last)<br/>-N &lt;name&gt; = 	Name of the new attribute.<br/>	(default:
  /// 'Unnamed')<br/>-L &lt;label1,label2,...&gt; = 	Create nominal attribute with given
  /// labels<br/>	(default: numeric attribute)<br/>-F &lt;format&gt; = 	The format
  /// of the date values (see ISO-8601)<br/>	(default: yyyy-MM-dd'T'HH:mm:ss)
  /// </summary>
  public class Add : BaseFilter<weka.filters.unsupervised.attribute.Add>
  {
    public Add(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Add()) {
      
    }

    /// <summary>
    /// Set the new attribute's name.
    /// </summary>    
    public Add AttributeName (string name) {
      Impl.setAttributeName(name);
      return this;
    }

    /// <summary>
    /// The list of value labels (nominal attribute creation only). The list must
    /// be comma-separated, eg: "red,green,blue". If this is empty, the created
    /// attribute will be numeric.
    /// </summary>    
    public Add NominalLabels (string labelList) {
      Impl.setNominalLabels(labelList);
      return this;
    }

    /// <summary>
    /// Defines the type of the attribute to generate.
    /// </summary>    
    public Add AttributeType (EAttributeType value) {
      Impl.setAttributeType(new weka.core.SelectedTag((int) value, weka.filters.unsupervised.attribute.Add.TAGS_TYPE));
      return this;
    }

    /// <summary>
    /// The position (starting from 1) where the attribute will be inserted
    /// (first and last are valid indices).
    /// </summary>    
    public Add AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The format of the date values (see ISO-8601).
    /// </summary>    
    public Add DateFormat (string value) {
      Impl.setDateFormat(value);
      return this;
    }

        
    public enum EAttributeType {
      Numeric_attribute = 0,
      Nominal_attribute = 1,
      String_attribute = 2,
      Date_attribute = 3
    }

        
  }
}