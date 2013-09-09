// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersBayes
  {
    private readonly Runtime rt;    
    public ClassifiersBayes(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
    /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
    /// </summary>
    public BayesNet BayesNet { get {
      return new BayesNet(rt); 
    } }

    /// <summary>
    /// Class for a Naive Bayes classifier using estimator classes. Numeric
    /// estimator precision values are chosen based on analysis of the training data.
    /// For this reason, the classifier is not an UpdateableClassifier (which in
    /// typical usage are initialized with zero training instances) -- if you need the
    /// UpdateableClassifier functionality, use the NaiveBayesUpdateable
    /// classifier. The NaiveBayesUpdateable classifier will use a default precision of 0.1
    /// for numeric attributes when buildClassifier is called with zero training
    /// instances.<br/><br/>For more information on Naive Bayes classifiers,
    /// see<br/><br/>George H. John, Pat Langley: Estimating Continuous Distributions in
    /// Bayesian Classifiers. In: Eleventh Conference on Uncertainty in Artificial
    /// Intelligence, San Mateo, 338-345, 1995.<br/><br/>Options:<br/><br/>-K = 	Use
    /// kernel density estimator rather than normal<br/>	distribution for numeric
    /// attributes<br/>-D = 	Use supervised discretization to process numeric
    /// attributes<br/><br/>-O = 	Display model in old format (good when there are many
    /// classes)<br/>
    /// </summary>
    public NaiveBayes NaiveBayes { get {
      return new NaiveBayes(rt); 
    } }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see,<br/><br/>Andrew Mccallum, Kamal Nigam: A Comparison of
    /// Event Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on
    /// 'Learning for Text Categorization', 1998.<br/><br/>The core equation for
    /// this classifier:<br/><br/>P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes
    /// rule)<br/><br/>where Ci is class i and D is a document.<br/><br/>Options:<br/><br/>-D
    /// = 	If set, classifier is run in debug mode and<br/>	may output additional
    /// info to the console
    /// </summary>
    public NaiveBayesMultinomial NaiveBayesMultinomial { get {
      return new NaiveBayesMultinomial(rt); 
    } }

    /// <summary>
    /// Multinomial naive bayes for text data. Operates directly (and only) on
    /// String attributes. Other types of input attributes are accepted but ignored
    /// during training and classification<br/><br/>Options:<br/><br/>-W = 	Use word
    /// frequencies instead of binary bag of words.<br/>-P &lt;# instances&gt; =
    /// 	How often to prune the dictionary of low frequency words (default = 0, i.e.
    /// don't prune)<br/>-M &lt;double&gt; = 	Minimum word frequency. Words with
    /// less than this frequence are ignored.<br/>	If periodic pruning is turned on
    /// then this is also used to determine which<br/>	words to remove from the
    /// dictionary (default = 3).<br/>-normalize = 	Normalize document length (use in
    /// conjunction with -norm and -lnorm)<br/>-norm &lt;num&gt; = 	Specify the
    /// norm that each instance must have (default 1.0)<br/>-lnorm &lt;num&gt; =
    /// 	Specify L-norm to use (default 2.0)<br/>-lowercase = 	Convert all tokens to
    /// lowercase before adding to the dictionary.<br/>-stoplist = 	Ignore words that
    /// are in the stoplist.<br/>-stopwords &lt;file&gt; = 	A file containing
    /// stopwords to override the default ones.<br/>	Using this option automatically
    /// sets the flag ('-stoplist') to use the<br/>	stoplist if the file
    /// exists.<br/>	Format: one stopword per line, lines starting with '#'<br/>	are interpreted
    /// as comments and ignored.<br/>-tokenizer &lt;spec&gt; = 	The tokenizing
    /// algorihtm (classname plus parameters) to use.<br/>	(default:
    /// weka.core.tokenizers.WordTokenizer)<br/>-stemmer &lt;spec&gt; = 	The stemmering algorihtm
    /// (classname plus parameters) to use.
    /// </summary>
    public NaiveBayesMultinomialText NaiveBayesMultinomialText { get {
      return new NaiveBayesMultinomialText(rt); 
    } }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see,<br/><br/>Andrew Mccallum, Kamal Nigam: A Comparison of
    /// Event Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on
    /// 'Learning for Text Categorization', 1998.<br/><br/>The core equation for
    /// this classifier:<br/><br/>P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes
    /// rule)<br/><br/>where Ci is class i and D is a document.<br/><br/>Incremental version
    /// of the algorithm.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public NaiveBayesMultinomialUpdateable NaiveBayesMultinomialUpdateable { get {
      return new NaiveBayesMultinomialUpdateable(rt); 
    } }

    /// <summary>
    /// Class for a Naive Bayes classifier using estimator classes. This is the
    /// updateable version of NaiveBayes.<br/>This classifier will use a default
    /// precision of 0.1 for numeric attributes when buildClassifier is called with
    /// zero training instances.<br/><br/>For more information on Naive Bayes
    /// classifiers, see<br/><br/>George H. John, Pat Langley: Estimating Continuous
    /// Distributions in Bayesian Classifiers. In: Eleventh Conference on Uncertainty in
    /// Artificial Intelligence, San Mateo, 338-345,
    /// 1995.<br/><br/>Options:<br/><br/>-K = 	Use kernel density estimator rather than normal<br/>	distribution
    /// for numeric attributes<br/>-D = 	Use supervised discretization to process
    /// numeric attributes<br/><br/>-O = 	Display model in old format (good when
    /// there are many classes)<br/>
    /// </summary>
    public NaiveBayesUpdateable NaiveBayesUpdateable { get {
      return new NaiveBayesUpdateable(rt); 
    } }

    
  }
}