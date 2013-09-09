// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersMeta
  {
    private readonly Runtime rt;    
    public ClassifiersMeta(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Class for boosting a nominal class classifier using the Adaboost M1
    /// method. Only nominal class problems can be tackled. Often dramatically improves
    /// performance, but sometimes overfits.<br/><br/>For more information,
    /// see<br/><br/>Yoav Freund, Robert E. Schapire: Experiments with a new boosting
    /// algorithm. In: Thirteenth International Conference on Machine Learning, San
    /// Francisco, 148-156, 1996.<br/><br/>Options:<br/><br/>-P &lt;num&gt; =
    /// 	Percentage of weight mass to base training on.<br/>	(default 100, reduce to around
    /// 90 speed up)<br/>-Q = 	Use resampling for boosting.<br/>-S &lt;num&gt; =
    /// 	Random number seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
    /// base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier weka.classifiers.trees.DecisionStump: =
    /// <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public AdaBoostM1 AdaBoostM1 { get {
      return new AdaBoostM1(rt); 
    } }

    /// <summary>
    /// Meta classifier that enhances the performance of a regression base
    /// classifier. Each iteration fits a model to the residuals left by the classifier
    /// on the previous iteration. Prediction is accomplished by adding the
    /// predictions of each classifier. Reducing the shrinkage (learning rate) parameter
    /// helps prevent overfitting and has a smoothing effect but increases the
    /// learning time.<br/><br/>For more information see:<br/><br/>J.H. Friedman (1999).
    /// Stochastic Gradient Boosting.<br/><br/>Options:<br/><br/>-S = 	Specify
    /// shrinkage rate. (default = 1.0, ie. no shrinkage)<br/><br/>-I &lt;num&gt; =
    /// 	Number of iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run
    /// in debug mode and<br/>	may output additional info to the console<br/>-W =
    /// 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console
    /// </summary>
    public AdditiveRegression AdditiveRegression { get {
      return new AdditiveRegression(rt); 
    } }

    /// <summary>
    /// Dimensionality of training and test data is reduced by attribute
    /// selection before being passed on to a classifier.<br/><br/>Options:<br/><br/>-E
    /// &lt;attribute evaluator specification&gt; = 	Full class name of attribute
    /// evaluator, followed<br/>	by its options.<br/>	eg:
    /// "weka.attributeSelection.CfsSubsetEval -L"<br/>	(default weka.attributeSelection.CfsSubsetEval)<br/>-S
    /// &lt;search method specification&gt; = 	Full class name of search method,
    /// followed<br/>	by its options.<br/>	eg: "weka.attributeSelection.BestFirst -D
    /// 1"<br/>	(default weka.attributeSelection.BestFirst)<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.J48)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
    /// &lt;pruning confidence&gt; = 	Set confidence threshold for
    /// pruning.<br/>	(default 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum
    /// number of instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
    /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
    /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B =
    /// 	Use binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L =
    /// 	Do not clean up after the tree has been built.<br/>-A = 	Laplace smoothing
    /// for predicted probabilities.<br/>-J = 	Do not use MDL correction for info
    /// gain on numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data
    /// shuffling (default 1).
    /// </summary>
    public AttributeSelectedClassifier AttributeSelectedClassifier { get {
      return new AttributeSelectedClassifier(rt); 
    } }

    /// <summary>
    /// Class for bagging a classifier to reduce variance. Can do classification
    /// and regression depending on the base learner. <br/><br/>For more
    /// information, see<br/><br/>Leo Breiman (1996). Bagging predictors. Machine Learning.
    /// 24(2):123-140.<br/><br/>Options:<br/><br/>-P = 	Size of each bag, as a
    /// percentage of the<br/>	training set size. (default 100)<br/>-O = 	Calculate the
    /// out of bag error.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 1)<br/>-num-slots &lt;num&gt; = 	Number of execution slots.<br/>	(default 1
    /// - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options specific
    /// to classifier weka.classifiers.trees.REPTree: = <br/>-M &lt;minimum number
    /// of instances&gt; = 	Set minimum number of instances per leaf (default
    /// 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric class
    /// variance proportion<br/>	of train variance for split (default 1e-3).<br/>-N
    /// &lt;number of folds&gt; = 	Number of folds for reduced error pruning (default
    /// 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P
    /// = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
    /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread initial count
    /// over all class values (i.e. don't use 1 per value)
    /// </summary>
    public Bagging Bagging { get {
      return new Bagging(rt); 
    } }

    /// <summary>
    /// Class for performing parameter selection by cross-validation for any
    /// classifier.<br/><br/>For more information, see:<br/><br/>R. Kohavi (1995).
    /// Wrappers for Performance Enhancement and Oblivious Decision Graphs. Department
    /// of Computer Science, Stanford University.<br/><br/>Options:<br/><br/>-X
    /// &lt;number of folds&gt; = 	Number of folds used for cross validation (default
    /// 10).<br/>-P &lt;classifier parameter&gt; = 	Classifier parameter
    /// options.<br/>	eg: "N 1 5 10" Sets an optimisation parameter for the<br/>	classifier
    /// with name -N, with lower bound 1, upper bound<br/>	5, and 10 optimisation
    /// steps. The upper bound may be the<br/>	character 'A' or 'I' to substitute the
    /// number of<br/>	attributes or instances in the training
    /// data,<br/>	respectively. This parameter may be supplied more than<br/>	once to optimise over
    /// several classifier options<br/>	simultaneously.<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug
    /// mode and<br/>	may output additional info to the console<br/>-W = 	Full
    /// name of base classifier.<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR: = <br/>-D =
    /// 	If set, classifier is run in debug mode and<br/>	may output additional info
    /// to the console
    /// </summary>
    public CVParameterSelection CVParameterSelection { get {
      return new CVParameterSelection(rt); 
    } }

    /// <summary>
    /// Class for doing classification using regression methods. Class is
    /// binarized and one regression model is built for each class value. For more
    /// information, see, for example<br/><br/>E. Frank, Y. Wang, S. Inglis, G. Holmes,
    /// I.H. Witten (1998). Using model trees for classification. Machine Learning.
    /// 32(1):63-76.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console<br/>-W = 	Full
    /// name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.M5P)<br/><br/>Options specific to classifier weka.classifiers.trees.M5P: = <br/>-N =
    /// 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed predictions<br/>-R =
    /// 	Build regression tree/rule rather than a model tree/rule<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes in<br/>	the tree (for
    /// visualization purposes)
    /// </summary>
    public ClassificationViaRegression ClassificationViaRegression { get {
      return new ClassificationViaRegression(rt); 
    } }

    /// <summary>
    /// A metaclassifier that makes its base classifier cost-sensitive. Two
    /// methods can be used to introduce cost-sensitivity: reweighting training
    /// instances according to the total cost assigned to each class; or predicting the
    /// class with minimum expected misclassification cost (rather than the most
    /// likely class). Performance can often be improved by using a Bagged classifier to
    /// improve the probability estimates of the base
    /// classifier.<br/><br/>Options:<br/><br/>-M = 	Minimize expected misclassification cost. Default is
    /// to<br/>	reweight training instances according to costs per class<br/>-C &lt;cost
    /// file name&gt; = 	File name of a cost matrix to use. If this is not
    /// supplied,<br/>	a cost matrix will be loaded on demand. The name of
    /// the<br/>	on-demand file is the relation name of the training data<br/>	plus ".cost", and
    /// the path to the on-demand file is<br/>	specified with the -N option.<br/>-N
    /// &lt;directory&gt; = 	Name of a directory to search for cost files when
    /// loading<br/>	costs on demand (default current directory).<br/>-cost-matrix
    /// &lt;matrix&gt; = 	The cost matrix in Matlab single line format.<br/>-S
    /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR:
    /// = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public CostSensitiveClassifier CostSensitiveClassifier { get {
      return new CostSensitiveClassifier(rt); 
    } }

    /// <summary>
    /// Class for running an arbitrary classifier on data that has been passed
    /// through an arbitrary filter. Like the classifier, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their
    /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
    /// followed<br/>	by filter options.<br/>	eg:
    /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
    /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
    /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
    /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is
    /// used as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
    /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
    /// has been built.<br/>-A = 	Laplace smoothing for predicted
    /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
    /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
    /// </summary>
    public FilteredClassifier FilteredClassifier { get {
      return new FilteredClassifier(rt); 
    } }

    /// <summary>
    /// Class for performing additive logistic regression. <br/>This class
    /// performs classification using a regression scheme as the base learner, and can
    /// handle multi-class problems. For more information, see<br/><br/>J. Friedman,
    /// T. Hastie, R. Tibshirani (1998). Additive Logistic Regression: a
    /// Statistical View of Boosting. Stanford University.<br/><br/>Can do efficient internal
    /// cross-validation to determine appropriate number of
    /// iterations.<br/><br/>Options:<br/><br/>-Q = 	Use resampling instead of reweighting for
    /// boosting.<br/>-P &lt;percent&gt; = 	Percentage of weight mass to base training
    /// on.<br/>	(default 100, reduce to around 90 speed up)<br/>-F &lt;num&gt; = 	Number
    /// of folds for internal cross-validation.<br/>	(default 0 -- no
    /// cross-validation)<br/>-R &lt;num&gt; = 	Number of runs for internal
    /// cross-validation.<br/>	(default 1)<br/>-L &lt;num&gt; = 	Threshold on the improvement of the
    /// likelihood.<br/>	(default -Double.MAX_VALUE)<br/>-H &lt;num&gt; = 	Shrinkage
    /// parameter.<br/>	(default 1)<br/>-S &lt;num&gt; = 	Random number
    /// seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default
    /// 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to
    /// classifier weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public LogitBoost LogitBoost { get {
      return new LogitBoost(rt); 
    } }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy.<br/><br/>Options:<br/><br/>-M &lt;num&gt; =
    /// 	Sets the method to use. Valid values are 0 (1-against-all),<br/>	1 (random
    /// codes), 2 (exhaustive code), and 3 (1-against-1). (default 0)<br/><br/>-R
    /// &lt;num&gt; = 	Sets the multiplier when using random codes. (default
    /// 2.0)<br/>-P = 	Use pairwise coupling (only has an effect for 1-against1)<br/>-S
    /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier
    /// is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier
    /// weka.classifiers.functions.Logistic: = <br/>-D = 	Turn on debugging output.<br/>-C = 	Use
    /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; = 	Set
    /// the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the maximum
    /// number of iterations (default -1, until convergence).
    /// </summary>
    public MultiClassClassifier MultiClassClassifier { get {
      return new MultiClassClassifier(rt); 
    } }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy. The base classifier must be an updateable
    /// classifier<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	Sets the method to use.
    /// Valid values are 0 (1-against-all),<br/>	1 (random codes), 2 (exhaustive
    /// code), and 3 (1-against-1). (default 0)<br/><br/>-R &lt;num&gt; = 	Sets the
    /// multiplier when using random codes. (default 2.0)<br/>-P = 	Use pairwise
    /// coupling (only has an effect for 1-against1)<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
    /// base classifier.<br/>	(default:
    /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier weka.classifiers.functions.SGD: = <br/>-F
    /// = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log loss
    /// (logistic regression),<br/>	2 = squared loss (regression).<br/>	(default =
    /// 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned off (as it is
    /// automatically for streaming data), then the<br/>	default learning rate
    /// will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
    /// &lt;double&gt; = 	The lambda regularization constant (default = 0.0001)<br/>-E
    /// &lt;integer&gt; = 	The number of epochs to perform (batch learning only, default
    /// = 500)<br/>-N = 	Don't normalize the data<br/>-M = 	Don't replace missing
    /// values
    /// </summary>
    public MultiClassClassifierUpdateable MultiClassClassifierUpdateable { get {
      return new MultiClassClassifierUpdateable(rt); 
    } }

    /// <summary>
    /// Class for selecting a classifier from among several using cross
    /// validation on the training data or the performance on the training data. Performance
    /// is measured based on percent correct (classification) or mean-squared
    /// error (regression).<br/><br/>Options:<br/><br/>-X &lt;number of folds&gt; =
    /// 	Use cross validation for model selection using the<br/>	given number of
    /// folds. (default 0, is to<br/>	use training error)<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-B &lt;classifier specification&gt; =
    /// 	Full class name of classifier to include, followed<br/>	by scheme options. May
    /// be specified multiple times.<br/>	(default:
    /// "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public MultiScheme MultiScheme { get {
      return new MultiScheme(rt); 
    } }

    /// <summary>
    /// Class for building an ensemble of randomizable base classifiers. Each
    /// base classifiers is built using a different random number seed (but based one
    /// the same data). The final prediction is a straight average of the
    /// predictions generated by the individual base
    /// classifiers.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
    /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
    /// parallelism)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default 10)<br/>-D =
    /// 	If set, classifier is run in debug mode and<br/>	may output additional info
    /// to the console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.RandomTree)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.RandomTree: = <br/>-K &lt;number of attributes&gt; =
    /// 	Number of attributes to randomly investigate<br/>	(<0 =
    /// int(log_2(#attributes)+1)).<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf.<br/>-S &lt;num&gt; = 	Seed for random number
    /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0
    /// for unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for
    /// backfitting (default 0, no backfitting).<br/>-U = 	Allow unclassified
    /// instances.<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public RandomCommittee RandomCommittee { get {
      return new RandomCommittee(rt); 
    } }

    /// <summary>
    /// This method constructs a decision tree based classifier that maintains
    /// highest accuracy on training data and improves on generalization accuracy as
    /// it grows in complexity. The classifier consists of multiple trees
    /// constructed systematically by pseudorandomly selecting subsets of components of the
    /// feature vector, that is, trees constructed in randomly chosen
    /// subspaces.<br/><br/>For more information, see<br/><br/>Tin Kam Ho (1998). The Random
    /// Subspace Method for Constructing Decision Forests. IEEE Transactions on
    /// Pattern Analysis and Machine Intelligence. 20(8):832-844. URL
    /// http://citeseer.ist.psu.edu/ho98random.html.<br/><br/>Options:<br/><br/>-P = 	Size of each
    /// subspace:<br/>		< 1: percentage of the number of attributes<br/>		>=1:
    /// absolute number of attributes<br/><br/>-S &lt;num&gt; = 	Random number
    /// seed.<br/>	(default 1)<br/>-num-slots &lt;num&gt; = 	Number of execution
    /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.REPTree: = <br/>-M
    /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per leaf
    /// (default 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric
    /// class variance proportion<br/>	of train variance for split (default
    /// 1e-3).<br/>-N &lt;number of folds&gt; = 	Number of folds for reduced error pruning
    /// (default 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default
    /// 1).<br/>-P = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
    /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread
    /// initial count over all class values (i.e. don't use 1 per value)
    /// </summary>
    public RandomSubSpace RandomSubSpace { get {
      return new RandomSubSpace(rt); 
    } }

    /// <summary>
    /// A regression scheme that employs any classifier on a copy of the data
    /// that has the class attribute discretized. The predicted value is the expected
    /// value of the mean class value for each discretized interval (based on the
    /// predicted probabilities for each interval). This class now also supports
    /// conditional density estimation by building a univariate density estimator from
    /// the target values in the training data, weighted by the class
    /// probabilities. <br/><br/>For more information on this process, see<br/><br/>Eibe Frank,
    /// Remco R. Bouckaert: Conditional Density Estimation with Class Probability
    /// Estimators. In: First Asian Conference on Machine Learning, Berlin, 65-81,
    /// 2009.<br/><br/>Options:<br/><br/>-B &lt;int&gt; = 	Number of bins for
    /// equal-width discretization<br/>	(default 10).<br/><br/>-E = 	Whether to delete
    /// empty bins after discretization<br/>	(default false).<br/><br/>-A = 	Whether
    /// to minimize absolute error, rather than squared error.<br/>	(default
    /// false).<br/><br/>-F = 	Use equal-frequency instead of equal-width
    /// discretization.<br/>-K = 	What type of density estimator to use:
    /// 0=histogram/1=kernel/2=normal (default: 0).<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
    /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
    /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
    /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is used
    /// as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
    /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
    /// has been built.<br/>-A = 	Laplace smoothing for predicted
    /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
    /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
    /// </summary>
    public RegressionByDiscretization RegressionByDiscretization { get {
      return new RegressionByDiscretization(rt); 
    } }

    /// <summary>
    /// Combines several classifiers using the stacking method. Can do
    /// classification or regression.<br/><br/>For more information, see<br/><br/>David H.
    /// Wolpert (1992). Stacked generalization. Neural Networks.
    /// 5:241-259.<br/><br/>Options:<br/><br/>-M &lt;scheme specification&gt; = 	Full name of meta
    /// classifier, followed by options.<br/>	(default:
    /// "weka.classifiers.rules.Zero")<br/>-X &lt;number of folds&gt; = 	Sets the number of cross-validation
    /// folds.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
    /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
    /// parallelism)<br/>-B &lt;classifier specification&gt; = 	Full class name of
    /// classifier to include, followed<br/>	by scheme options. May be specified multiple
    /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public Stacking Stacking { get {
      return new Stacking(rt); 
    } }

    /// <summary>
    /// Class for combining classifiers. Different combinations of probability
    /// estimates for classification are available.<br/><br/>For more information
    /// see:<br/><br/>Ludmila I. Kuncheva (2004). Combining Pattern Classifiers:
    /// Methods and Algorithms. John Wiley and Sons, Inc..<br/><br/>J. Kittler, M.
    /// Hatef, Robert P.W. Duin, J. Matas (1998). On combining classifiers. IEEE
    /// Transactions on Pattern Analysis and Machine Intelligence.
    /// 20(3):226-239.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 1)<br/>-B &lt;classifier specification&gt; = 	Full class name of classifier to
    /// include, followed<br/>	by scheme options. May be specified multiple
    /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier
    /// is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-P &lt;path to serialized classifier&gt; = 	Full path to serialized
    /// classifier to include.<br/>	May be specified multiple times to
    /// include<br/>	multiple serialized classifiers. Note: it does<br/>	not make sense to use
    /// pre-built classifiers in<br/>	a cross-validation.<br/>-R
    /// &lt;AVG|PROD|MAJ|MIN|MAX|MED&gt; = 	The combination rule to use<br/>	(default: AVG)
    /// </summary>
    public Vote Vote { get {
      return new Vote(rt); 
    } }

    /// <summary>
    /// This metaclassifier makes its base classifier cost-sensitive using the
    /// method specified in<br/><br/>Pedro Domingos: MetaCost: A general method for
    /// making classifiers cost-sensitive. In: Fifth International Conference on
    /// Knowledge Discovery and Data Mining, 155-164, 1999.<br/><br/>This classifier
    /// should produce similar results to one created by passing the base learner to
    /// Bagging, which is in turn passed to a CostSensitiveClassifier operating on
    /// minimum expected cost. The difference is that MetaCost produces a single
    /// cost-sensitive classifier of the base learner, giving the benefits of fast
    /// classification and interpretable output (if the base learner itself is
    /// interpretable). This implementation uses all bagging iterations when
    /// reclassifying training data (the MetaCost paper reports a marginal improvement when
    /// only those iterations containing each training instance are used in
    /// reclassifying that instance).<br/><br/>Options:<br/><br/>-I &lt;num&gt; = 	Number of
    /// bagging iterations.<br/>	(default 10)<br/>-C &lt;cost file name&gt; =
    /// 	File name of a cost matrix to use. If this is not supplied,<br/>	a cost matrix
    /// will be loaded on demand. The name of the<br/>	on-demand file is the
    /// relation name of the training data<br/>	plus ".cost", and the path to the
    /// on-demand file is<br/>	specified with the -N option.<br/>-N &lt;directory&gt; =
    /// 	Name of a directory to search for cost files when loading<br/>	costs on
    /// demand (default current directory).<br/>-cost-matrix &lt;matrix&gt; = 	The
    /// cost matrix in Matlab single line format.<br/>-P = 	Size of each bag, as a
    /// percentage of the<br/>	training set size. (default 100)<br/>-S &lt;num&gt; =
    /// 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console<br/>-W =
    /// 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR: =
    /// <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public MetaCost MetaCost { get {
      return new MetaCost(rt); 
    } }

    
  }
}