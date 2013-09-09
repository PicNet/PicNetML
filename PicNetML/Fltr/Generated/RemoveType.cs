using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Removes attributes of a given type.<br/><br/>Options:<br/><br/>-T
  /// &lt;nominal|numeric|string|date|relational&gt; = 	Attribute type to delete. Valid
  /// options are "nominal", <br/>	"numeric", "string", "date" and
  /// "relational".<br/>	(default "string")<br/>-V = 	Invert matching sense (i.e. only keep
  /// specified columns)
  /// </summary>
  public class RemoveType : BaseFilter<weka.filters.unsupervised.attribute.RemoveType>
  {
    public RemoveType(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RemoveType()) {
      
    }

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public RemoveType InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// The type of attribute to remove.
    /// </summary>    
    public RemoveType AttributeType (EAttributeType type) {
      Impl.setAttributeType(new weka.core.SelectedTag((int) type, weka.filters.unsupervised.attribute.RemoveType.TAGS_ATTRIBUTETYPE));
      return this;
    }

        
    public enum EAttributeType {
      Delete_nominal_attributes = 1,
      Delete_numeric_attributes = 0,
      Delete_string_attributes = 2,
      Delete_date_attributes = 3,
      Delete_relational_attributes = 4
    }

        
  }
}