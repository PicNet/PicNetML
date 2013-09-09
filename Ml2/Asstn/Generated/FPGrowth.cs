using weka.associations;

// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  /// <summary>
  /// Class implementing the FP-growth algorithm for finding large item sets
  /// without candidate generation. Iteratively reduces the minimum support until
  /// it finds the required number of rules with the given minimum metric. For
  /// more information see:<br/><br/>J. Han, J.Pei, Y. Yin: Mining frequent patterns
  /// without candidate generation. In: Proceedings of the 2000 ACM-SIGMID
  /// International Conference on Management of Data, 1-12,
  /// 2000.<br/><br/>Options:<br/><br/>-P &lt;attribute index of positive value&gt; = 	Set the index of the
  /// attribute value to consider as 'positive'<br/>	for binary attributes in
  /// normal dense instances. Index 2 is always<br/>	used for sparse instances.
  /// (default = 2)<br/>-I &lt;max items&gt; = 	The maximum number of items to
  /// include in large items sets (and rules). (default = -1, i.e. no limit.)<br/>-N
  /// &lt;require number of rules&gt; = 	The required number of rules. (default =
  /// 10)<br/>-T &lt;0=confidence | 1=lift | 2=leverage | 3=Conviction&gt; = 	The
  /// metric by which to rank rules. (default = confidence)<br/>-C &lt;minimum
  /// metric score of a rule&gt; = 	The minimum metric score of a rule. (default =
  /// 0.9)<br/>-U &lt;upper bound for minimum support&gt; = 	Upper bound for
  /// minimum support as a fraction or number of instances. (default = 1.0)<br/>-M
  /// &lt;lower bound for minimum support&gt; = 	The lower bound for the minimum
  /// support as a fraction or number of instances. (default = 0.1)<br/>-D
  /// &lt;delta for minimum support&gt; = 	The delta by which the minimum support is
  /// decreased in<br/>	each iteration as a fraction or number of instances.
  /// (default = 0.05)<br/>-S = 	Find all rules that meet the lower bound
  /// on<br/>	minimum support and the minimum metric constraint.<br/>	Turning this mode on will
  /// disable the iterative support reduction<br/>	procedure to find the
  /// specified number of rules.<br/>-transactions &lt;comma separated list of attribute
  /// names&gt; = 	Only consider transactions that contain these items (default
  /// = no restriction)<br/>-rules &lt;comma separated list of attribute
  /// names&gt; = 	Only print rules that contain these items. (default = no
  /// restriction)<br/>-use-or = 	Use OR instead of AND for must contain list(s). Use in
  /// conjunction<br/>	with -transactions and/or -rules
  /// </summary>
  public class FPGrowth : BaseAssociation<weka.associations.FPGrowth>
  {
    public FPGrowth(Runtime rt) : base(rt, new weka.associations.FPGrowth()) {
      
    }

    /// <summary>
    /// Set the index of binary valued attributes that is to be considered the
    /// positive index. Has no effect for sparse data (in this case the first index
    /// (i.e. non-zero values) is always treated as positive. Also has no effect for
    /// unary valued attributes (i.e. when using the Weka Apriori-style format for
    /// market basket data, which uses missing value "?" to indicate absence of an
    /// item.
    /// </summary>    
    public FPGrowth PositiveIndex (int index) {
      Impl.setPositiveIndex(index);
      return this;
    }    

    /// <summary>
    /// The maximum number of items to include in frequent item sets. -1 means no
    /// limit.
    /// </summary>    
    public FPGrowth MaxNumberOfItems (int max) {
      Impl.setMaxNumberOfItems(max);
      return this;
    }    

    /// <summary>
    /// The number of rules to output
    /// </summary>    
    public FPGrowth NumRulesToFind (int numR) {
      Impl.setNumRulesToFind(numR);
      return this;
    }    

    /// <summary>
    /// Minimum metric score. Consider only rules with scores higher than this
    /// value.
    /// </summary>    
    public FPGrowth MinMetric (double v) {
      Impl.setMinMetric(v);
      return this;
    }    

    /// <summary>
    /// Iteratively decrease support by this factor. Reduces support until min
    /// support is reached or required number of rules has been generated.
    /// </summary>    
    public FPGrowth Delta (double v) {
      Impl.setDelta(v);
      return this;
    }    

    /// <summary>
    /// Lower bound for minimum support as a fraction or number of instances.
    /// </summary>    
    public FPGrowth LowerBoundMinSupport (double v) {
      Impl.setLowerBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Upper bound for minimum support as a fraction or number of instances.
    /// Start iteratively decreasing minimum support from this value.
    /// </summary>    
    public FPGrowth UpperBoundMinSupport (double v) {
      Impl.setUpperBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Limit input to FPGrowth to those transactions (instances) that contain
    /// these items. Provide a comma separated list of attribute names.
    /// </summary>    
    public FPGrowth TransactionsMustContain (string list) {
      Impl.setTransactionsMustContain(list);
      return this;
    }    

    /// <summary>
    /// Only print rules that contain these items. Provide a comma separated list
    /// of attribute names.
    /// </summary>    
    public FPGrowth RulesMustContain (string list) {
      Impl.setRulesMustContain(list);
      return this;
    }    

    /// <summary>
    /// Use OR instead of AND for transactions/rules must contain lists.
    /// </summary>    
    public FPGrowth UseORForMustContainList (bool b) {
      Impl.setUseORForMustContainList(b);
      return this;
    }    

    /// <summary>
    /// Find all rules that meet the lower bound on minimum support and the
    /// minimum metric constraint. Turning this mode on will disable the iterative
    /// support reduction procedure to find the specified number of rules.
    /// </summary>    
    public FPGrowth FindAllRulesForSupportLevel (bool s) {
      Impl.setFindAllRulesForSupportLevel(s);
      return this;
    }    

    /// <summary>
    /// 
    /// </summary>    
    public FPGrowth OffDiskReportingFrequency (int freq) {
      Impl.setOffDiskReportingFrequency(freq);
      return this;
    }    

          
        
  }
}