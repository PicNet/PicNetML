using weka.associations;

// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  /// <summary>
  /// Class for running an arbitrary associator on data that has been passed
  /// through an arbitrary filter. Like the associator, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their
  /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
  /// followed<br/>	by filter options.<br/>	eg:
  /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>	(default: weka.filters.MultiFilter
  /// with<br/>	weka.filters.unsupervised.attribute.ReplaceMissingValues)<br/>-c &lt;the class
  /// index&gt; = 	The class index.<br/>	(default: -1, i.e. unset)<br/>-W = 	Full
  /// name of base associator.<br/>	(default:
  /// weka.associations.Apriori)<br/><br/>Options specific to associator weka.associations.Apriori: = <br/>-N
  /// &lt;required number of rules output&gt; = 	The required number of rules.
  /// (default = 10)<br/>-T &lt;0=confidence | 1=lift | 2=leverage | 3=Conviction&gt; =
  /// 	The metric type by which to rank rules. (default = confidence)<br/>-C
  /// &lt;minimum metric score of a rule&gt; = 	The minimum confidence of a rule.
  /// (default = 0.9)<br/>-D &lt;delta for minimum support&gt; = 	The delta by which
  /// the minimum support is decreased in<br/>	each iteration. (default =
  /// 0.05)<br/>-U &lt;upper bound for minimum support&gt; = 	Upper bound for minimum
  /// support. (default = 1.0)<br/>-M &lt;lower bound for minimum support&gt; =
  /// 	The lower bound for the minimum support. (default = 0.1)<br/>-S
  /// &lt;significance level&gt; = 	If used, rules are tested for significance at<br/>	the
  /// given level. Slower. (default = no significance testing)<br/>-I = 	If set the
  /// itemsets found are also output. (default = no)<br/>-R = 	Remove columns
  /// that contain all missing values (default = no)<br/>-V = 	Report progress
  /// iteratively. (default = no)<br/>-A = 	If set class association rules are mined.
  /// (default = no)<br/>-Z = 	Treat zero (i.e. first value of nominal
  /// attributes) as missing<br/>-B &lt;toString delimiters&gt; = 	If used, two characters
  /// to use as rule delimiters<br/>	in the result of toString: the first to
  /// delimit fields,<br/>	the second to delimit items within fields.<br/>	(default
  /// = traditional toString result)<br/>-c &lt;the class index&gt; = 	The class
  /// index. (default = last)
  /// </summary>
  public class FilteredAssociator : BaseAssociation<weka.associations.FilteredAssociator>
  {
    public FilteredAssociator(Runtime rt) : base(rt, new weka.associations.FilteredAssociator()) {
      
    }

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public FilteredAssociator Filter (Fltr.IBaseFilter<weka.filters.Filter> value) {
      Impl.setFilter(value.Impl);
      return this;
    }    

    /// <summary>
    /// Index of the class attribute. If set to -1, the last attribute is taken
    /// as class attribute.
    /// </summary>    
    public FilteredAssociator ClassIndex (int value) {
      Impl.setClassIndex(value);
      return this;
    }    

    /// <summary>
    /// The base associator to be used.
    /// </summary>    
    public FilteredAssociator Associator (BaseAssociation<AbstractAssociator> value) {
      Impl.setAssociator(value.Impl);
      return this;
    }    

          
        
  }
}