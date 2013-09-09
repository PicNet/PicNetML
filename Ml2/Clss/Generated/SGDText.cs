using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
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
  public class SGDText : BaseClassifier<weka.classifiers.functions.SGDText>
  {
    public SGDText(Runtime rt) : base(rt, new weka.classifiers.functions.SGDText()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// If true, ignores all words that are on the stoplist.
    /// </summary>    
    public SGDText UseStopList (bool u) {
      Impl.setUseStopList(u);
      return this;
    }

    /// <summary>
    /// The loss function to use. Hinge loss (SVM), log loss (logistic
    /// regression) or squared loss (regression).
    /// </summary>    
    public SGDText LossFunction (ELossFunction function) {
      Impl.setLossFunction(new weka.core.SelectedTag((int) function, weka.classifiers.functions.SGDText.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// Fit a logistic regression to the output of SVM for producing probability
    /// estimates
    /// </summary>    
    public SGDText OutputProbsForSVM (bool o) {
      Impl.setOutputProbsForSVM(o);
      return this;
    }

    /// <summary>
    /// The regularization constant. (default = 0.0001)
    /// </summary>    
    public SGDText Lambda (double lambda) {
      Impl.setLambda(lambda);
      return this;
    }

    /// <summary>
    /// The learning rate.
    /// </summary>    
    public SGDText LearningRate (double lr) {
      Impl.setLearningRate(lr);
      return this;
    }

    /// <summary>
    /// The number of epochs to perform (batch learning). The total number of
    /// iterations is epochs * num instances.
    /// </summary>    
    public SGDText Epochs (int e) {
      Impl.setEpochs(e);
      return this;
    }

    /// <summary>
    /// Use word frequencies rather than binary bag of words representation
    /// </summary>    
    public SGDText UseWordFrequencies (bool u) {
      Impl.setUseWordFrequencies(u);
      return this;
    }

    /// <summary>
    /// How often (number of instances) to prune the dictionary of low frequency
    /// terms. 0 means don't prune. Setting a positive integer n means prune after
    /// every n instances
    /// </summary>    
    public SGDText PeriodicPruning (int p) {
      Impl.setPeriodicPruning(p);
      return this;
    }

    /// <summary>
    /// Ignore any words that don't occur at least min frequency times in the
    /// training data. If periodic pruning is turned on, then the dictionary is pruned
    /// according to this value
    /// </summary>    
    public SGDText MinWordFrequency (double minFreq) {
      Impl.setMinWordFrequency(minFreq);
      return this;
    }

    /// <summary>
    /// If true then document length is normalized according to the settings for
    /// norm and lnorm
    /// </summary>    
    public SGDText NormalizeDocLength (bool norm) {
      Impl.setNormalizeDocLength(norm);
      return this;
    }

    /// <summary>
    /// The norm of the instances after normalization.
    /// </summary>    
    public SGDText Norm (double newNorm) {
      Impl.setNorm(newNorm);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SGDText LNorm (double newLNorm) {
      Impl.setLNorm(newLNorm);
      return this;
    }

    /// <summary>
    /// Whether to convert all tokens to lowercase
    /// </summary>    
    public SGDText LowercaseTokens (bool l) {
      Impl.setLowercaseTokens(l);
      return this;
    }

    /// <summary>
    /// The tokenizing algorithm to use on the strings.
    /// </summary>    
    public SGDText Tokenizer (weka.core.tokenizers.Tokenizer value) {
      Impl.setTokenizer(value);
      return this;
    }

    /// <summary>
    /// The stemming algorithm to use on the words.
    /// </summary>    
    public SGDText Stemmer (weka.core.stemmers.Stemmer value) {
      Impl.setStemmer(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SGDText Bias (double bias) {
      Impl.setBias(bias);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SGDText Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum ELossFunction {
      Hinge_loss_SVM = 0,
      Log_loss_logistic_regression = 1
    }

        
  }
}