// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersFunctions
  {
    private readonly Runtime rt;    
    public ClassifiersFunctions(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Implements Gaussian processes for regression without
    /// hyperparameter-tuning. To make choosing an appropriate noise level easier, this implementation
    /// applies normalization/standardization to the target attribute as well as
    /// the other attributes (if normalization/standardizaton is turned on). Missing
    /// values are replaced by the global mean/mode. Nominal attributes are
    /// converted to binary ones. Note that kernel caching is turned off if the kernel
    /// used implements CachedKernel.<br/><br/>Options:<br/><br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-L &lt;double&gt; = 	Level of Gaussian Noise wrt transformed target.
    /// (default 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.
    /// (default 0=normalize)<br/>-K &lt;classname and parameters&gt; = 	The Kernel to
    /// use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
    /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if available) to be
    /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
    /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the
    /// cache (a prime number), 0 for full cache and <br/>	-1 to turn it
    /// off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default:
    /// 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public GaussianProcesses GaussianProcesses { get {
      return new GaussianProcesses(rt); 
    } }

    /// <summary>
    /// Class for using linear regression for prediction. Uses the Akaike
    /// criterion for model selection, and is able to deal with weighted
    /// instances.<br/><br/>Options:<br/><br/>-D = 	Produce debugging output.<br/>	(default no
    /// debugging output)<br/>-S &lt;number of selection method&gt; = 	Set the attribute
    /// selection method to use. 1 = None, 2 = Greedy.<br/>	(default 0 = M5'
    /// method)<br/>-C = 	Do not try to eliminate colinear attributes.<br/><br/>-R
    /// &lt;double&gt; = 	Set ridge parameter (default 1.0e-8).<br/><br/>-minimal =
    /// 	Conserve memory, don't keep dataset header and means/stdevs.<br/>	Model cannot
    /// be printed out if this option is enabled.	(default: keep data)
    /// </summary>
    public LinearRegression LinearRegression { get {
      return new LinearRegression(rt); 
    } }

    /// <summary>
    /// Class for building and using a multinomial logistic regression model with
    /// a ridge estimator.<br/><br/>There are some modifications, however,
    /// compared to the paper of leCessie and van Houwelingen(1992): <br/><br/>If there
    /// are k classes for n instances with m attributes, the parameter matrix B to be
    /// calculated will be an m*(k-1) matrix.<br/><br/>The probability for class j
    /// with the exception of the last class is<br/><br/>Pj(Xi) =
    /// exp(XiBj)/((sum[j=1..(k-1)]exp(Xi*Bj))+1) <br/><br/>The last class has
    /// probability<br/><br/>1-(sum[j=1..(k-1)]Pj(Xi)) <br/>	=
    /// 1/((sum[j=1..(k-1)]exp(Xi*Bj))+1)<br/><br/>The (negative) multinomial log-likelihood is thus: <br/><br/>L =
    /// -sum[i=1..n]{<br/>	sum[j=1..(k-1)](Yij * ln(Pj(Xi)))<br/>	+(1 -
    /// (sum[j=1..(k-1)]Yij)) <br/>	* ln(1 - sum[j=1..(k-1)]Pj(Xi))<br/>	} + ridge *
    /// (B^2)<br/><br/>In order to find the matrix B for which L is minimised, a Quasi-Newton
    /// Method is used to search for the optimized values of the m*(k-1) variables. Note
    /// that before we use the optimization procedure, we 'squeeze' the matrix B
    /// into a m*(k-1) vector. For details of the optimization procedure, please
    /// check weka.core.Optimization class.<br/><br/>Although original Logistic
    /// Regression does not deal with instance weights, we modify the algorithm a little
    /// bit to handle the instance weights.<br/><br/>For more information
    /// see:<br/><br/>le Cessie, S., van Houwelingen, J.C. (1992). Ridge Estimators in
    /// Logistic Regression. Applied Statistics. 41(1):191-201.<br/><br/>Note: Missing
    /// values are replaced using a ReplaceMissingValuesFilter, and nominal
    /// attributes are transformed into numeric attributes using a
    /// NominalToBinaryFilter.<br/><br/>Options:<br/><br/>-D = 	Turn on debugging output.<br/>-C = 	Use
    /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; =
    /// 	Set the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the
    /// maximum number of iterations (default -1, until convergence).
    /// </summary>
    public Logistic Logistic { get {
      return new Logistic(rt); 
    } }

    /// <summary>
    /// A Classifier that uses backpropagation to classify instances.<br/>This
    /// network can be built by hand, created by an algorithm or both. The network
    /// can also be monitored and modified during training time. The nodes in this
    /// network are all sigmoid (except for when the class is numeric in which case
    /// the the output nodes become unthresholded linear
    /// units).<br/><br/>Options:<br/><br/>-L &lt;learning rate&gt; = 	Learning Rate for the backpropagation
    /// algorithm.<br/>	(Value should be between 0 - 1, Default = 0.3).<br/>-M
    /// &lt;momentum&gt; = 	Momentum Rate for the backpropagation algorithm.<br/>	(Value
    /// should be between 0 - 1, Default = 0.2).<br/>-N &lt;number of epochs&gt; =
    /// 	Number of epochs to train through.<br/>	(Default = 500).<br/>-V
    /// &lt;percentage size of validation set&gt; = 	Percentage size of validation set to
    /// use to terminate<br/>	training (if this is non zero it can pre-empt num of
    /// epochs.<br/>	(Value should be between 0 - 100, Default = 0).<br/>-S
    /// &lt;seed&gt; = 	The value used to seed the random number generator<br/>	(Value
    /// should be >= 0 and and a long, Default = 0).<br/>-E &lt;threshold for number of
    /// consequetive errors&gt; = 	The consequetive number of errors allowed for
    /// validation<br/>	testing before the netwrok terminates.<br/>	(Value should be
    /// > 0, Default = 20).<br/>-G = 	GUI will be opened.<br/>	(Use this to bring
    /// up a GUI).<br/>-A = 	Autocreation of the network connections will NOT be
    /// done.<br/>	(This will be ignored if -G is NOT set)<br/>-B = 	A NominalToBinary
    /// filter will NOT automatically be used.<br/>	(Set this to not use a
    /// NominalToBinary filter).<br/>-H &lt;comma seperated numbers for nodes on each
    /// layer&gt; = 	The hidden layers to be created for the network.<br/>	(Value
    /// should be a list of comma separated Natural <br/>	numbers or the letters 'a' =
    /// (attribs + classes) / 2, <br/>	'i' = attribs, 'o' = classes, 't' = attribs
    /// .+ classes)<br/>	for wildcard values, Default = a).<br/>-C = 	Normalizing a
    /// numeric class will NOT be done.<br/>	(Set this to not normalize the class
    /// if it's numeric).<br/>-I = 	Normalizing the attributes will NOT be
    /// done.<br/>	(Set this to not normalize the attributes).<br/>-R = 	Reseting the
    /// network will NOT be allowed.<br/>	(Set this to not allow the network to
    /// reset).<br/>-D = 	Learning rate decay will occur.<br/>	(Set this to cause the
    /// learning rate to decay).
    /// </summary>
    public MultilayerPerceptron MultilayerPerceptron { get {
      return new MultilayerPerceptron(rt); 
    } }

    /// <summary>
    /// Implements stochastic gradient descent for learning various linear models
    /// (binary class SVM, binary class logistic regression, squared loss, Huber
    /// loss and epsilon-insensitive loss linear regression). Globally replaces all
    /// missing values and transforms nominal attributes into binary ones. It also
    /// normalizes all attributes, so the coefficients in the output are based on
    /// the normalized data.<br/>For numeric class attributes, the squared, Huber or
    /// epsilon-insensitve loss function must be used. Epsilon-insensitive and
    /// Huber loss may require a much higher learning
    /// rate.<br/><br/>Options:<br/><br/>-F = 	Set the loss function to minimize.<br/>	0 = hinge loss (SVM), 1 =
    /// log loss (logistic regression),<br/>	2 = squared loss (regression), 3 =
    /// epsilon insensitive loss (regression),<br/>	4 = Huber loss
    /// (regression).<br/>	(default = 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned
    /// off (as it is automatically for streaming data), then the<br/>	default
    /// learning rate will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
    /// &lt;double&gt; = 	The lambda regularization constant (default =
    /// 0.0001)<br/>-E &lt;integer&gt; = 	The number of epochs to perform (batch learning
    /// only, default = 500)<br/>-C &lt;double&gt; = 	The epsilon threshold
    /// (epsilon-insenstive and Huber loss only, default = 1e-3)<br/>-N = 	Don't normalize
    /// the data<br/>-M = 	Don't replace missing values
    /// </summary>
    public SGD SGD { get {
      return new SGD(rt); 
    } }

    /// <summary>
    /// Implements stochastic gradient descent for learning a linear binary class
    /// SVM or binary class logistic regression on text data. Operates directly
    /// (and only) on String attributes. Other types of input attributes are accepted
    /// but ignored during training and
    /// classification.<br/><br/>Options:<br/><br/>-F = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log
    /// loss (logistic regression)<br/>	(default = 0)<br/>-outputProbs = 	Output
    /// probabilities for SVMs (fits a logsitic<br/>	model to the output of the
    /// SVM)<br/>-L = 	The learning rate (default = 0.01).<br/>-R &lt;double&gt; = 	The
    /// lambda regularization constant (default = 0.0001)<br/>-E &lt;integer&gt; =
    /// 	The number of epochs to perform (batch learning only, default = 500)<br/>-W =
    /// 	Use word frequencies instead of binary bag of words.<br/>-P &lt;#
    /// instances&gt; = 	How often to prune the dictionary of low frequency words (default
    /// = 0, i.e. don't prune)<br/>-M &lt;double&gt; = 	Minimum word frequency.
    /// Words with less than this frequence are ignored.<br/>	If periodic pruning is
    /// turned on then this is also used to determine which<br/>	words to remove
    /// from the dictionary (default = 3).<br/>-normalize = 	Normalize document
    /// length (use in conjunction with -norm and -lnorm)<br/>-norm &lt;num&gt; =
    /// 	Specify the norm that each instance must have (default 1.0)<br/>-lnorm
    /// &lt;num&gt; = 	Specify L-norm to use (default 2.0)<br/>-lowercase = 	Convert all
    /// tokens to lowercase before adding to the dictionary.<br/>-stoplist = 	Ignore
    /// words that are in the stoplist.<br/>-stopwords &lt;file&gt; = 	A file
    /// containing stopwords to override the default ones.<br/>	Using this option
    /// automatically sets the flag ('-stoplist') to use the<br/>	stoplist if the file
    /// exists.<br/>	Format: one stopword per line, lines starting with '#'<br/>	are
    /// interpreted as comments and ignored.<br/>-tokenizer &lt;spec&gt; = 	The
    /// tokenizing algorihtm (classname plus parameters) to use.<br/>	(default:
    /// weka.core.tokenizers.WordTokenizer)<br/>-stemmer &lt;spec&gt; = 	The stemmering
    /// algorihtm (classname plus parameters) to use.
    /// </summary>
    public SGDText SGDText { get {
      return new SGDText(rt); 
    } }

    /// <summary>
    /// Implements John Platt's sequential minimal optimization algorithm for
    /// training a support vector classifier.<br/><br/>This implementation globally
    /// replaces all missing values and transforms nominal attributes into binary
    /// ones. It also normalizes all attributes by default. (In that case the
    /// coefficients in the output are based on the normalized data, not the original data
    /// --- this is important for interpreting the
    /// classifier.)<br/><br/>Multi-class problems are solved using pairwise classification (1-vs-1 and if logistic
    /// models are built pairwise coupling according to Hastie and Tibshirani,
    /// 1998).<br/><br/>To obtain proper probability estimates, use the option that
    /// fits logistic regression models to the outputs of the support vector machine.
    /// In the multi-class case the predicted probabilities are coupled using
    /// Hastie and Tibshirani's pairwise coupling method.<br/><br/>Note: for improved
    /// speed normalization should be turned off when operating on
    /// SparseInstances.<br/><br/>For more information on the SMO algorithm, see<br/><br/>J. Platt:
    /// Fast Training of Support Vector Machines using Sequential Minimal
    /// Optimization. In B. Schoelkopf and C. Burges and A. Smola, editors, Advances in
    /// Kernel Methods - Support Vector Learning, 1998.<br/><br/>S.S. Keerthi, S.K.
    /// Shevade, C. Bhattacharyya, K.R.K. Murthy (2001). Improvements to Platt's SMO
    /// Algorithm for SVM Classifier Design. Neural Computation.
    /// 13(3):637-649.<br/><br/>Trevor Hastie, Robert Tibshirani: Classification by Pairwise Coupling.
    /// In: Advances in Neural Information Processing Systems,
    /// 1998.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console<br/>-no-checks = 	Turns off all checks
    /// - use with caution!<br/>	Turning them off assumes that data is purely
    /// numeric, doesn't<br/>	contain any missing values, and has a nominal class.
    /// Turning them<br/>	off also means that no header information will be stored if
    /// the<br/>	machine is linear. Finally, it also assumes that no instance
    /// has<br/>	a weight equal to 0.<br/>	(default: checks on)<br/>-C &lt;double&gt; =
    /// 	The complexity constant C. (default 1)<br/>-N = 	Whether to
    /// 0=normalize/1=standardize/2=neither. (default 0=normalize)<br/>-L &lt;double&gt; = 	The
    /// tolerance parameter. (default 1.0e-3)<br/>-P &lt;double&gt; = 	The epsilon for
    /// round-off error. (default 1.0e-12)<br/>-M = 	Fit logistic models to SVM
    /// outputs. <br/>-V &lt;double&gt; = 	The number of folds for the
    /// internal<br/>	cross-validation. (default -1, use training data)<br/>-W &lt;double&gt; =
    /// 	The random number seed. (default 1)<br/>-K &lt;classname and parameters&gt;
    /// = 	The Kernel to use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
    /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if
    /// available) to be printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all
    /// checks - use with caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; =
    /// 	The size of the cache (a prime number), 0 for full cache and <br/>	-1 to
    /// turn it off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to
    /// use.<br/>	(default: 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public SMO SMO { get {
      return new SMO(rt); 
    } }

    /// <summary>
    /// SMOreg implements the support vector machine for regression. The
    /// parameters can be learned using various algorithms. The algorithm is selected by
    /// setting the RegOptimizer. The most popular algorithm (RegSMOImproved) is due
    /// to Shevade, Keerthi et al and this is the default
    /// RegOptimizer.<br/><br/>For more information see:<br/><br/>S.K. Shevade, S.S. Keerthi, C.
    /// Bhattacharyya, K.R.K. Murthy: Improvements to the SMO Algorithm for SVM Regression.
    /// In: IEEE Transactions on Neural Networks, 1999.<br/><br/>A.J. Smola, B.
    /// Schoelkopf (1998). A tutorial on support vector
    /// regression.<br/><br/>Options:<br/><br/>-C &lt;double&gt; = 	The complexity constant C.<br/>	(default
    /// 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.<br/>	(default
    /// 0=normalize)<br/>-I &lt;classname and parameters&gt; = 	Optimizer class used for
    /// solving quadratic optimization problem<br/>	(default
    /// weka.classifiers.functions.supportVector.RegSMOImproved)<br/>-K &lt;classname and parameters&gt;
    /// = 	The Kernel to use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to optimizer ('-I')
    /// weka.classifiers.functions.supportVector.RegSMOImproved: = <br/>-T &lt;double&gt; = 	The
    /// tolerance parameter for checking the stopping criterion.<br/>	(default
    /// 0.001)<br/>-V = 	Use variant 1 of the algorithm when true, otherwise use
    /// variant 2.<br/>	(default true)<br/>-P &lt;double&gt; = 	The epsilon for round-off
    /// error.<br/>	(default 1.0e-12)<br/>-L &lt;double&gt; = 	The epsilon
    /// parameter in epsilon-insensitive loss function.<br/>	(default 1.0e-3)<br/>-W
    /// &lt;double&gt; = 	The random number seed.<br/>	(default 1)<br/><br/>Options
    /// specific to kernel ('-K') weka.classifiers.functions.supportVector.PolyKernel:
    /// = <br/>-D = 	Enables debugging output (if available) to be
    /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
    /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the cache (a prime
    /// number), 0 for full cache and <br/>	-1 to turn it off.<br/>	(default:
    /// 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default: 1.0)<br/>-L =
    /// 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public SMOreg SMOreg { get {
      return new SMOreg(rt); 
    } }

    /// <summary>
    /// Learns a simple linear regression model. Picks the attribute that results
    /// in the lowest squared error. Missing values are not allowed. Can only deal
    /// with numeric attributes.<br/><br/>Options:<br/><br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public SimpleLinearRegression SimpleLinearRegression { get {
      return new SimpleLinearRegression(rt); 
    } }

    /// <summary>
    /// Classifier for building linear logistic regression models. LogitBoost
    /// with simple regression functions as base learners is used for fitting the
    /// logistic models. The optimal number of LogitBoost iterations to perform is
    /// cross-validated, which leads to automatic attribute selection. For more
    /// information see:<br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model
    /// Trees.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic
    /// Model Tree Induction. In: 9th European Conference on Principles and Practice
    /// of Knowledge Discovery in Databases, 675-683,
    /// 2005.<br/><br/>Options:<br/><br/>-I &lt;iterations&gt; = 	Set fixed number of iterations for
    /// LogitBoost<br/>-S = 	Use stopping criterion on training set (instead
    /// of<br/>	cross-validation)<br/>-P = 	Use error on probabilities (rmse) instead
    /// of<br/>	misclassification error for stopping criterion<br/>-M &lt;iterations&gt; = 	Set
    /// maximum number of boosting iterations<br/>-H &lt;iterations&gt; = 	Set
    /// parameter for heuristic for early stopping of<br/>	LogitBoost.<br/>	If enabled,
    /// the minimum is selected greedily, stopping<br/>	if the current minimum has
    /// not changed for iter iterations.<br/>	By default, heuristic is enabled with
    /// value 50. Set to<br/>	zero to disable heuristic.<br/>-W &lt;beta&gt; =
    /// 	Set beta for weight trimming for LogitBoost. Set to 0 for no weight
    /// trimming.<br/><br/>-A = 	The AIC is used to choose the best iteration (instead of CV
    /// or training error).<br/>
    /// </summary>
    public SimpleLogistic SimpleLogistic { get {
      return new SimpleLogistic(rt); 
    } }

    /// <summary>
    /// Implementation of the voted perceptron algorithm by Freund and Schapire.
    /// Globally replaces all missing values, and transforms nominal attributes
    /// into binary ones.<br/><br/>For more information, see:<br/><br/>Y. Freund, R.
    /// E. Schapire: Large margin classification using the perceptron algorithm. In:
    /// 11th Annual Conference on Computational Learning Theory, New York, NY,
    /// 209-217, 1998.<br/><br/>Options:<br/><br/>-I &lt;int&gt; = 	The number of
    /// iterations to be performed.<br/>	(default 1)<br/>-E &lt;double&gt; = 	The
    /// exponent for the polynomial kernel.<br/>	(default 1)<br/>-S &lt;int&gt; = 	The
    /// seed for the random number generation.<br/>	(default 1)<br/>-M &lt;int&gt; =
    /// 	The maximum number of alterations allowed.<br/>	(default 10000)
    /// </summary>
    public VotedPerceptron VotedPerceptron { get {
      return new VotedPerceptron(rt); 
    } }

    /// <summary>
    /// A wrapper class for the liblinear classifier.<br/>Rong-En Fan, Kai-Wei
    /// Chang, Cho-Jui Hsieh, Xiang-Rui Wang, Chih-Jen Lin (2008). LIBLINEAR - A
    /// Library for Large Linear Classification. URL
    /// http://www.csie.ntu.edu.tw/~cjlin/liblinear/.<br/><br/>Options:<br/><br/>-S &lt;int&gt; = 	Set type of solver
    /// (default: 1)<br/>	for multi-class classification<br/>		 0 --
    /// L2-regularized logistic regression (primal)		 1 -- L2-regularized L2-loss support vector
    /// classification (dual)		 2 -- L2-regularized L2-loss support vector
    /// classification (primal)		 3 -- L2-regularized L1-loss support vector
    /// classification (dual)		 4 -- support vector classification by Crammer and Singer		 5 --
    /// L1-regularized L2-loss support vector classification		 6 -- L1-regularized
    /// logistic regression		 7 -- L2-regularized logistic regression (dual)	for
    /// regression		11 -- L2-regularized L2-loss support vector regression
    /// (primal)		12 -- L2-regularized L2-loss support vector regression (dual)		13 --
    /// L2-regularized L1-loss support vector regression (dual)<br/>-C &lt;double&gt; =
    /// 	Set the cost parameter C<br/>	 (default: 1)<br/>-Z = 	Turn on normalization
    /// of input data (default: off)<br/>-N = 	Turn on nominal to binary
    /// conversion.<br/>-M = 	Turn off missing value replacement.<br/>	WARNING: use only if
    /// your data has no missing values.<br/>-P = 	Use probability estimation
    /// (default: off)<br/>currently for L2-regularized logistic regression,
    /// L1-regularized logistic regression or L2-regularized logistic regression (dual)!
    /// <br/>-E &lt;double&gt; = 	Set tolerance of termination criterion (default:
    /// 0.01)<br/>-W &lt;double&gt; = 	Set the parameters C of class i to
    /// weight[i]*C<br/>	 (default: 1)<br/>-B &lt;double&gt; = 	Add Bias term with the given
    /// value if >= 0; if < 0, no bias term added (default: 1)<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public LibLINEAR LibLINEAR { get {
      return new LibLINEAR(rt); 
    } }

    
  }
}