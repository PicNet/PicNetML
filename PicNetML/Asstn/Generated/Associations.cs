// ReSharper disable once CheckNamespace
namespace PicNetML.Asstn
{
  public class Associations
  {
    private readonly Runtime rt;    
    public Associations(Runtime rt) { this.rt = rt; }   

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
    public Apriori Apriori() { return new Apriori(rt); }

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
    public FPGrowth FPGrowth() { return new FPGrowth(rt); }

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
    public FilteredAssociator FilteredAssociator() { return new FilteredAssociator(rt); }

    
  }
}