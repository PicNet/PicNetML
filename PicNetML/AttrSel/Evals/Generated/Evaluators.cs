using weka.core;

// ReSharper disable once CheckNamespace
namespace PicNetML.AttrSel.Evals
{
  public class Evaluators
  {
    private readonly Runtime rt;
    public Evaluators(Runtime rt) {
      this.rt = rt;
    }

    /// <summary>
    /// CfsSubsetEval :<br/><br/>Evaluates the worth of a subset of attributes by
    /// considering the individual predictive ability of each feature along with
    /// the degree of redundancy between them.<br/><br/>Subsets of features that are
    /// highly correlated with the class while having low intercorrelation are
    /// preferred.<br/><br/>For more information see:<br/><br/>M. A. Hall (1998).
    /// Correlation-based Feature Subset Selection for Machine Learning. Hamilton, New
    /// Zealand.<br/><br/>Options:<br/><br/>-M = 	Treat missing values as a
    /// separate value.<br/>-L = 	Don't include locally predictive attributes.<br/>-Z =
    /// 	Precompute the full correlation matrix at the outset, rather than compute
    /// correlations lazily (as needed) during the search. Use this in conjuction
    /// with parallel processing in order to speed up a backward search.<br/>-P
    /// &lt;int&gt; = 	The size of the thread pool, for example, the number of cores in
    /// the CPU. (default 1)<br/><br/>-E &lt;int&gt; = 	The number of threads to
    /// use, which should be >= size of thread pool. (default 1)<br/><br/>-D = 	Output
    /// debugging info.
    /// </summary>
    public CfsSubset CfsSubset { get { 
      return new CfsSubset(rt); 
    } }

    /// <summary>
    /// CorrelationAttributeEval :<br/><br/>Evaluates the worth of an attribute
    /// by measuring the correlation (Pearson's) between it and the
    /// class.<br/><br/>Nominal attributes are considered on a value by value basis by treating
    /// each value as an indicator. An overall correlation for a nominal attribute is
    /// arrived at via a weighted average.<br/><br/><br/>Options:<br/><br/>-D =
    /// 	Output detailed info for nominal attributes
    /// </summary>
    public CorrelationAttribute CorrelationAttribute { get { 
      return new CorrelationAttribute(rt); 
    } }

    /// <summary>
    /// GainRatioAttributeEval :<br/><br/>Evaluates the worth of an attribute by
    /// measuring the gain ratio with respect to the class.<br/><br/>GainR(Class,
    /// Attribute) = (H(Class) - H(Class | Attribute)) /
    /// H(Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat missing values as a seperate value.
    /// </summary>
    public GainRatioAttribute GainRatioAttribute { get { 
      return new GainRatioAttribute(rt); 
    } }

    /// <summary>
    /// InfoGainAttributeEval :<br/><br/>Evaluates the worth of an attribute by
    /// measuring the information gain with respect to the
    /// class.<br/><br/>InfoGain(Class,Attribute) = H(Class) - H(Class |
    /// Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat missing values as a seperate value.<br/>-B = 	just
    /// binarize numeric attributes instead <br/>	of properly discretizing them.
    /// </summary>
    public InfoGainAttribute InfoGainAttribute { get { 
      return new InfoGainAttribute(rt); 
    } }

    /// <summary>
    /// OneRAttributeEval :<br/><br/>Evaluates the worth of an attribute by using
    /// the OneR classifier.<br/><br/><br/>Options:<br/><br/>-S &lt;seed&gt; =
    /// 	Random number seed for cross validation<br/>	(default = 1)<br/>-F
    /// &lt;folds&gt; = 	Number of folds for cross validation<br/>	(default = 10)<br/>-D =
    /// 	Use training data for evaluation rather than cross validaton<br/>-B
    /// &lt;minimum bucket size&gt; = 	Minimum number of objects in a bucket<br/>	(passed on
    /// to OneR, default = 6)
    /// </summary>
    public OneRAttribute OneRAttribute { get { 
      return new OneRAttribute(rt); 
    } }

    /// <summary>
    /// Performs a principal components analysis and transformation of the data.
    /// Use in conjunction with a Ranker search. Dimensionality reduction is
    /// accomplished by choosing enough eigenvectors to account for some percentage of
    /// the variance in the original data---default 0.95 (95%). Attribute noise can
    /// be filtered by transforming to the PC space, eliminating some of the worst
    /// eigenvectors, and then transforming back to the original
    /// space.<br/><br/>Options:<br/><br/>-C = 	Center (rather than standardize) the<br/>	data and
    /// compute PCA using the covariance (rather<br/>	 than the correlation)
    /// matrix.<br/>-R = 	Retain enough PC attributes to account <br/>	for this proportion
    /// of variance in the original data.<br/>	(default = 0.95)<br/>-O = 	Transform
    /// through the PC space and <br/>	back to the original space.<br/>-A =
    /// 	Maximum number of attributes to include in <br/>	transformed attribute names. (-1
    /// = include all)
    /// </summary>
    public PrincipalComponents PrincipalComponents { get { 
      return new PrincipalComponents(rt); 
    } }

    /// <summary>
    /// ReliefFAttributeEval :<br/><br/>Evaluates the worth of an attribute by
    /// repeatedly sampling an instance and considering the value of the given
    /// attribute for the nearest instance of the same and different class. Can operate
    /// on both discrete and continuous class data.<br/><br/>For more information
    /// see:<br/><br/>Kenji Kira, Larry A. Rendell: A Practical Approach to Feature
    /// Selection. In: Ninth International Workshop on Machine Learning, 249-256,
    /// 1992.<br/><br/>Igor Kononenko: Estimating Attributes: Analysis and Extensions
    /// of RELIEF. In: European Conference on Machine Learning, 171-182,
    /// 1994.<br/><br/>Marko Robnik-Sikonja, Igor Kononenko: An adaptation of Relief for
    /// attribute estimation in regression. In: Fourteenth International Conference on
    /// Machine Learning, 296-304, 1997.<br/><br/>Options:<br/><br/>-M &lt;num
    /// instances&gt; = 	Specify the number of instances to<br/>	sample when
    /// estimating attributes.<br/>	If not specified, then all instances<br/>	will be
    /// used.<br/>-D &lt;seed&gt; = 	Seed for randomly sampling instances.<br/>	(Default
    /// = 1)<br/>-K &lt;number of neighbours&gt; = 	Number of nearest neighbours
    /// (k) used<br/>	to estimate attribute relevances<br/>	(Default = 10).<br/>-W =
    /// 	Weight nearest neighbours by distance<br/>-A &lt;num&gt; = 	Specify sigma
    /// value (used in an exp<br/>	function to control how quickly<br/>	weights for
    /// more distant instances<br/>	decrease. Use in conjunction with
    /// -W.<br/>	Sensible value=1/5 to 1/10 of the<br/>	number of nearest
    /// neighbours.<br/>	(Default = 2)
    /// </summary>
    public ReliefFAttribute ReliefFAttribute { get { 
      return new ReliefFAttribute(rt); 
    } }

    /// <summary>
    /// SymmetricalUncertAttributeEval :<br/><br/>Evaluates the worth of an
    /// attribute by measuring the symmetrical uncertainty with respect to the class.
    /// <br/><br/> SymmU(Class, Attribute) = 2 * (H(Class) - H(Class | Attribute)) /
    /// H(Class) + H(Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat
    /// missing values as a seperate value.
    /// </summary>
    public SymmetricalUncertAttribute SymmetricalUncertAttribute { get { 
      return new SymmetricalUncertAttribute(rt); 
    } }

    /// <summary>
    /// WrapperSubsetEval:<br/><br/>Evaluates attribute sets by using a learning
    /// scheme. Cross validation is used to estimate the accuracy of the learning
    /// scheme for a set of attributes.<br/><br/>For more information
    /// see:<br/><br/>Ron Kohavi, George H. John (1997). Wrappers for feature subset selection.
    /// Artificial Intelligence. 97(1-2):273-324.<br/><br/>Options:<br/><br/>-B
    /// &lt;base learner&gt; = 	class name of base learner to use for 	accuracy
    /// estimation.<br/>	Place any classifier options LAST on the command
    /// line<br/>	following a "--". eg.:<br/>		-B weka.classifiers.bayes.NaiveBayes ... --
    /// -K<br/>	(default: weka.classifiers.rules.ZeroR)<br/>-F &lt;num&gt; = 	number of
    /// cross validation folds to use for estimating accuracy.<br/>	(default=5)<br/>-R
    /// &lt;seed&gt; = 	Seed for cross validation accuracy
    /// testimation.<br/>	(default = 1)<br/>-T &lt;num&gt; = 	threshold by which to execute another cross
    /// validation<br/>	(standard deviation---expressed as a percentage of the
    /// mean).<br/>	(default: 0.01 (1%))<br/>-E &lt;acc | rmse | mae | f-meas | auc |
    /// auprc&gt; = 	Performance evaluation measure to use for selecting
    /// attributes.<br/>	(Default = accuracy for discrete class and rmse for numeric
    /// class)<br/>-IRclass &lt;label | index&gt; = 	Optional class value (label or 1-based
    /// index) to use in conjunction with<br/>	IR statistics (f-meas, auc or
    /// auprc). Omitting this option will use<br/>	the class-weighted
    /// average.<br/><br/>Options specific to scheme weka.classifiers.rules.ZeroR: = <br/>-D = 	If
    /// set, classifier is run in debug mode and<br/>	may output additional info to
    /// the console
    /// </summary>
    public WrapperSubset WrapperSubset { get { 
      return new WrapperSubset(rt); 
    } }

    /// <summary>
    /// Performs latent semantic analysis and transformation of the data. Use in
    /// conjunction with a Ranker search. A low-rank approximation of the full data
    /// is found by either specifying the number of singular values to use or
    /// specifying a proportion of the singular values to
    /// cover.<br/><br/>Options:<br/><br/>-N = 	Normalize input data.<br/>-R = 	Rank approximation used in LSA.
    /// <br/>	May be actual number of LSA attributes <br/>	to include (if greater
    /// than 1) or a <br/>	proportion of total singular values to <br/>	account for
    /// (if between 0 and 1). <br/>	A value less than or equal to zero means
    /// <br/>	use all latent variables.(default = 0.95)<br/>-A = 	Maximum number of
    /// attributes to include<br/>	in transformed attribute names.<br/>	(-1 = include
    /// all)
    /// </summary>
    public LatentSemanticAnalysis LatentSemanticAnalysis { get { 
      return new LatentSemanticAnalysis(rt); 
    } }

    
  }
}