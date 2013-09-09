using weka.associations;

// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  /// <summary>
  /// Class implementing an Apriori-type algorithm. Iteratively reduces the
  /// minimum support until it finds the required number of rules with the given
  /// minimum confidence.<br/>The algorithm has an option to mine class association
  /// rules. It is adapted as explained in the second reference.<br/><br/>For
  /// more information see:<br/><br/>R. Agrawal, R. Srikant: Fast Algorithms for
  /// Mining Association Rules in Large Databases. In: 20th International Conference
  /// on Very Large Data Bases, 478-499, 1994.<br/><br/>Bing Liu, Wynne Hsu,
  /// Yiming Ma: Integrating Classification and Association Rule Mining. In: Fourth
  /// International Conference on Knowledge Discovery and Data Mining, 80-86,
  /// 1998.<br/><br/>Options:<br/><br/>-N &lt;required number of rules output&gt; =
  /// 	The required number of rules. (default = 10)<br/>-T &lt;0=confidence |
  /// 1=lift | 2=leverage | 3=Conviction&gt; = 	The metric type by which to rank
  /// rules. (default = confidence)<br/>-C &lt;minimum metric score of a rule&gt; =
  /// 	The minimum confidence of a rule. (default = 0.9)<br/>-D &lt;delta for
  /// minimum support&gt; = 	The delta by which the minimum support is decreased
  /// in<br/>	each iteration. (default = 0.05)<br/>-U &lt;upper bound for minimum
  /// support&gt; = 	Upper bound for minimum support. (default = 1.0)<br/>-M
  /// &lt;lower bound for minimum support&gt; = 	The lower bound for the minimum
  /// support. (default = 0.1)<br/>-S &lt;significance level&gt; = 	If used, rules are
  /// tested for significance at<br/>	the given level. Slower. (default = no
  /// significance testing)<br/>-I = 	If set the itemsets found are also output.
  /// (default = no)<br/>-R = 	Remove columns that contain all missing values
  /// (default = no)<br/>-V = 	Report progress iteratively. (default = no)<br/>-A = 	If
  /// set class association rules are mined. (default = no)<br/>-Z = 	Treat zero
  /// (i.e. first value of nominal attributes) as missing<br/>-B &lt;toString
  /// delimiters&gt; = 	If used, two characters to use as rule delimiters<br/>	in
  /// the result of toString: the first to delimit fields,<br/>	the second to
  /// delimit items within fields.<br/>	(default = traditional toString result)<br/>-c
  /// &lt;the class index&gt; = 	The class index. (default = last)
  /// </summary>
  public class Apriori : BaseAssociation<weka.associations.Apriori>
  {
    public Apriori(Runtime rt) : base(rt, new weka.associations.Apriori()) {
      
    }

    /// <summary>
    /// Set the type of metric by which to rank rules. Confidence is the
    /// proportion of the examples covered by the premise that are also covered by the
    /// consequence (Class association rules can only be mined using confidence). Lift
    /// is confidence divided by the proportion of all examples that are covered by
    /// the consequence. This is a measure of the importance of the association
    /// that is independent of support. Leverage is the proportion of additional
    /// examples covered by both the premise and consequence above those expected if
    /// the premise and consequence were independent of each other. The total number
    /// of examples that this represents is presented in brackets following the
    /// leverage. Conviction is another measure of departure from independence.
    /// Conviction is given by P(premise)P(!consequence) / P(premise, !consequence).
    /// </summary>    
    public Apriori MetricType (EMetricType d) {
      Impl.setMetricType(new weka.core.SelectedTag((int) d, weka.associations.Apriori.TAGS_SELECTION));
      return this;
    }    

    /// <summary>
    /// Upper bound for minimum support. Start iteratively decreasing minimum
    /// support from this value.
    /// </summary>    
    public Apriori UpperBoundMinSupport (double v) {
      Impl.setUpperBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Remove columns with all missing values.
    /// </summary>    
    public Apriori RemoveAllMissingCols (bool r) {
      Impl.setRemoveAllMissingCols(r);
      return this;
    }    

    /// <summary>
    /// Minimum metric score. Consider only rules with scores higher than this
    /// value.
    /// </summary>    
    public Apriori MinMetric (double v) {
      Impl.setMinMetric(v);
      return this;
    }    

    /// <summary>
    /// Index of the class attribute. If set to -1, the last attribute is taken
    /// as class attribute.
    /// </summary>    
    public Apriori ClassIndex (int index) {
      Impl.setClassIndex(index);
      return this;
    }    

    /// <summary>
    /// If enabled class association rules are mined instead of (general)
    /// association rules.
    /// </summary>    
    public Apriori Car (bool flag) {
      Impl.setCar(flag);
      return this;
    }    

    /// <summary>
    /// Lower bound for minimum support.
    /// </summary>    
    public Apriori LowerBoundMinSupport (double v) {
      Impl.setLowerBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Number of rules to find.
    /// </summary>    
    public Apriori NumRules (int v) {
      Impl.setNumRules(v);
      return this;
    }    

    /// <summary>
    /// Iteratively decrease support by this factor. Reduces support until min
    /// support is reached or required number of rules has been generated.
    /// </summary>    
    public Apriori Delta (double v) {
      Impl.setDelta(v);
      return this;
    }    

    /// <summary>
    /// Significance level. Significance test (confidence metric only).
    /// </summary>    
    public Apriori SignificanceLevel (double v) {
      Impl.setSignificanceLevel(v);
      return this;
    }    

    /// <summary>
    /// If enabled the itemsets are output as well.
    /// </summary>    
    public Apriori OutputItemSets (bool flag) {
      Impl.setOutputItemSets(flag);
      return this;
    }    

    /// <summary>
    /// If enabled the algorithm will be run in verbose mode.
    /// </summary>    
    public Apriori Verbose (bool flag) {
      Impl.setVerbose(flag);
      return this;
    }    

    /// <summary>
    /// If enabled, zero (that is, the first value of a nominal) is treated in
    /// the same way as a missing value.
    /// </summary>    
    public Apriori TreatZeroAsMissing (bool z) {
      Impl.setTreatZeroAsMissing(z);
      return this;
    }    

          
    public enum EMetricType {
      Confidence = 0,
      Lift = 1,
      Leverage = 2,
      Conviction = 3
    }

        
  }
}