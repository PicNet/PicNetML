using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A simple filter for sorting the labels of nominal
  /// attributes.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-R
  /// &lt;index1,index2-index4,...&gt; = 	Specify list of string attributes to
  /// convert to words.<br/>	(default: select all relational attributes)<br/>-V =
  /// 	Inverts the matching sense of the selection.<br/>-S &lt;CASE|NON-CASE&gt; =
  /// 	Determines the type of sorting:<br/>	CASE = Case-sensitive<br/>	NON-CASE =
  /// Case-insensitive<br/>	(default: CASE)
  /// </summary>
  public class SortLabels : BaseFilter<weka.filters.unsupervised.attribute.SortLabels>
  {
    public SortLabels(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.SortLabels()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; Specify an
    /// inclusive range with "-"; eg: "first-3,5,6-10,last".
    /// </summary>    
    public SortLabels AttributeIndices (string value) {
      Impl.setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected attributes in the
    /// range will be worked on; if true, only non-selected attributes will be
    /// processed.
    /// </summary>    
    public SortLabels InvertSelection (bool value) {
      Impl.setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// The type of sorting to use.
    /// </summary>    
    public SortLabels SortType (ESortType type) {
      Impl.setSortType(new weka.core.SelectedTag((int) type, weka.filters.unsupervised.attribute.SortLabels.TAGS_SORTTYPE));
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public SortLabels Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
    public enum ESortType {
      Case_sensitive = 0,
      Case_insensitive = 1
    }

        
  }
}