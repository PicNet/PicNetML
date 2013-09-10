// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  public class FiltersSupervisedAttribute
  {
    private readonly Runtime rt;    
    public FiltersSupervisedAttribute(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// A filter for adding the classification, the class distribution and an
    /// error flag to a dataset with a classifier. The classifier is either trained on
    /// the data itself or provided as serialized
    /// model.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-W &lt;classifier
    /// specification&gt; = 	Full class name of classifier to use, followed<br/>	by
    /// scheme options. eg:<br/>		"weka.classifiers.bayes.NaiveBayes
    /// -D"<br/>	(default: weka.classifiers.rules.ZeroR)<br/>-serialized &lt;file&gt; = 	Instead of
    /// training a classifier on the data, one can also provide<br/>	a serialized
    /// model and use that for tagging the data.<br/>-classification = 	Adds an
    /// attribute with the actual classification.<br/>	(default:
    /// off)<br/>-remove-old-class = 	Removes the old class attribute.<br/>	(default:
    /// off)<br/>-distribution = 	Adds attributes with the distribution for all classes <br/>	(for
    /// numeric classes this will be identical to the attribute <br/>	output with
    /// '-classification').<br/>	(default: off)<br/>-error = 	Adds an attribute
    /// indicating whether the classifier output <br/>	a wrong classification (for
    /// numeric classes this is the numeric <br/>	difference).<br/>	(default: off)
    /// </summary>
    public AddClassification AddClassification { get {
      return new AddClassification(rt); 
    } }

    /// <summary>
    /// A supervised attribute filter that can be used to select attributes. It
    /// is very flexible and allows various search and evaluation methods to be
    /// combined.<br/><br/>Options:<br/><br/>-S &lt;"Name of search class [search
    /// options]"&gt; = 	Sets search method for subset evaluators.<br/>	eg. -S
    /// "weka.attributeSelection.BestFirst -S 8"<br/>-E &lt;"Name of attribute/subset
    /// evaluation class [evaluator options]"&gt; = 	Sets attribute/subset
    /// evaluator.<br/>	eg. -E "weka.attributeSelection.CfsSubsetEval -L"<br/><br/>Options
    /// specific to evaluator weka.attributeSelection.CfsSubsetEval: = <br/>-M = 	Treat
    /// missing values as a separate value.<br/>-L = 	Don't include locally
    /// predictive attributes.<br/>-Z = 	Precompute the full correlation matrix at the
    /// outset, rather than compute correlations lazily (as needed) during the search.
    /// Use this in conjuction with parallel processing in order to speed up a
    /// backward search.<br/>-P &lt;int&gt; = 	The size of the thread pool, for
    /// example, the number of cores in the CPU. (default 1)<br/><br/>-E &lt;int&gt; =
    /// 	The number of threads to use, which should be >= size of thread pool.
    /// (default 1)<br/><br/>-D = 	Output debugging info.<br/><br/>Options specific to
    /// search weka.attributeSelection.BestFirst: = <br/>-P &lt;start set&gt; =
    /// 	Specify a starting set of attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward
    /// | 1 = forward | 2 = bi-directional&gt; = 	Direction of search. (default =
    /// 1).<br/>-N &lt;num&gt; = 	Number of non-improving nodes to<br/>	consider
    /// before terminating search.<br/>-S &lt;num&gt; = 	Size of lookup cache for
    /// evaluated subsets.<br/>	Expressed as a multiple of the number
    /// of<br/>	attributes in the data set. (default = 1)
    /// </summary>
    public AttributeSelection AttributeSelection { get {
      return new AttributeSelection(rt); 
    } }

    /// <summary>
    /// Changes the order of the classes so that the class values are no longer
    /// of in the order specified in the header. The values will be in the order
    /// specified by the user -- it could be either in ascending/descending order by
    /// the class frequency or in random order. Note that this filter currently does
    /// not change the header, only the class values of the instances, so there is
    /// not much point in using it in conjunction with the FilteredClassifier. The
    /// value can also be converted back using 'originalValue(double value)'
    /// procedure.<br/><br/>Options:<br/><br/>-R &lt;seed&gt; = 	Specify the seed of
    /// randomization<br/>	used to randomize the class<br/>	order (default: 1)<br/>-C
    /// &lt;order&gt; = 	Specify the class order to be<br/>	sorted, could be 0:
    /// ascending<br/>	1: descending and 2: random.(default: 0)
    /// </summary>
    public ClassOrder ClassOrder { get {
      return new ClassOrder(rt); 
    } }

    /// <summary>
    /// An instance filter that discretizes a range of numeric attributes in the
    /// dataset into nominal attributes. Discretization is by Fayyad & Irani's MDL
    /// method (the default).<br/><br/>For more information, see:<br/><br/>Usama M.
    /// Fayyad, Keki B. Irani: Multi-interval discretization of continuousvalued
    /// attributes for classification learning. In: Thirteenth International Joint
    /// Conference on Articial Intelligence, 1022-1027, 1993.<br/><br/>Igor
    /// Kononenko: On Biases in Estimating Multi-Valued Attributes. In: 14th International
    /// Joint Conference on Articial Intelligence, 1034-1040,
    /// 1995.<br/><br/>Options:<br/><br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to
    /// Discretize. First and last are valid indexes.<br/>	(default none)<br/>-V =
    /// 	Invert matching sense of column indexes.<br/>-D = 	Output binary attributes
    /// for discretized attributes.<br/>-Y = 	Use bin numbers rather than ranges
    /// for discretized attributes.<br/>-E = 	Use better encoding of split point for
    /// MDL.<br/>-K = 	Use Kononenko's MDL criterion.
    /// </summary>
    public Discretize Discretize { get {
      return new Discretize(rt); 
    } }

    /// <summary>
    /// Merges values of all nominal attributes among the specified attributes,
    /// excluding the class attribute, using the CHAID method, but without
    /// considering to re-split merged subsets. It implements Steps 1 and 2 described by
    /// Kass (1980), see<br/><br/>Gordon V. Kass (1980). An Exploratory Technique for
    /// Investigating Large Quantities of Categorical Data. Applied Statistics.
    /// 29(2):119-127.<br/><br/>Once attribute values have been merged, a chi-squared
    /// test using the Bonferroni correction is applied to check if the resulting
    /// attribute is a valid predictor, based on the Bonferroni multiplier in
    /// Equation 3.2 in Kass (1980). If an attribute does not pass this test, all
    /// remaining values (if any) are merged. Nevertheless, useless predictors can slip
    /// through without being fully merged, e.g. identifier attributes.<br/><br/>The
    /// code applies the Yates correction when the chi-squared statistic is
    /// computed.<br/><br/>Note that the algorithm is quadratic in the number of attribute
    /// values for an attribute.<br/><br/>Options:<br/><br/>-D = 	Turns on output
    /// of debugging information.<br/>-L &lt;double&gt; = 	The significance level
    /// (default: 0.05).<br/><br/>-R &lt;range&gt; = 	Sets list of attributes to act
    /// on (or its inverse). 'first and 'last' are accepted as well.'<br/>	E.g.:
    /// first-5,7,9,20-last<br/>	(default: first-last)<br/>-V = 	Invert matching
    /// sense (i.e. act on all attributes not specified in list)<br/>-O = 	Use short
    /// identifiers for merged subsets.
    /// </summary>
    public MergeNominalValues MergeNominalValues { get {
      return new MergeNominalValues(rt); 
    } }

    /// <summary>
    /// Converts all nominal attributes into binary numeric attributes. An
    /// attribute with k values is transformed into k binary attributes if the class is
    /// nominal (using the one-attribute-per-value approach). Binary attributes are
    /// left binary, if option '-A' is not given.If the class is numeric, k - 1 new
    /// binary attributes are generated in the manner described in "Classification
    /// and Regression Trees" by Breiman et al. (i.e. taking the average class
    /// value associated with each attribute value into account)<br/><br/>For more
    /// information, see:<br/><br/>L. Breiman, J.H. Friedman, R.A. Olshen, C.J. Stone
    /// (1984). Classification and Regression Trees. Wadsworth
    /// Inc.<br/><br/>Options:<br/><br/>-N = 	Sets if binary attributes are to be coded as nominal
    /// ones.<br/>-A = 	For each nominal value a new attribute is created, <br/>	not
    /// only if there are more than 2 values.
    /// </summary>
    public NominalToBinary NominalToBinary { get {
      return new NominalToBinary(rt); 
    } }

    /// <summary>
    /// A filter that uses a PartitionGenerator to generate partition membership
    /// values; filtered instances are composed of these values plus the class
    /// attribute (if set in the input data) and rendered as sparse
    /// instances.<br/><br/>Options:<br/><br/>-W &lt;name of partition generator&gt; = 	Full name of
    /// partition generator to use,
    /// e.g.:<br/>		weka.classifiers.trees.J48<br/>	Additional options after the '--'.<br/>	(default: weka.classifiers.trees.J48)
    /// </summary>
    public PartitionMembership PartitionMembership { get {
      return new PartitionMembership(rt); 
    } }

    
  }
}