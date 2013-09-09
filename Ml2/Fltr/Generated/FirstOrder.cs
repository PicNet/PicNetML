using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This instance filter takes a range of N numeric attributes and replaces
  /// them with N-1 numeric attributes, the values of which are the difference
  /// between consecutive attribute values from the original instance. eg:
  /// <br/><br/>Original attribute values<br/><br/> 0.1, 0.2, 0.3, 0.1, 0.3<br/><br/>New
  /// attribute values<br/><br/> 0.1, 0.1, -0.2, 0.2<br/><br/>The range of
  /// attributes used is taken in numeric order. That is, a range spec of 7-11,3-5 will
  /// use the attribute ordering 3,4,5,7,8,9,10,11 for the differences, NOT
  /// 7,8,9,10,11,3,4,5.<br/><br/>Options:<br/><br/>-R
  /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to take the differences between.<br/>	First
  /// and last are valid indexes.<br/>	(default none)
  /// </summary>
  public class FirstOrder : BaseFilter<weka.filters.unsupervised.attribute.FirstOrder>
  {
    public FirstOrder(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.FirstOrder()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public FirstOrder AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public FirstOrder AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}