using System.Collections.Generic;
using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
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
  public class NaiveBayesMultinomialText : BaseClassifier<weka.classifiers.bayes.NaiveBayesMultinomialText>
  {
    public NaiveBayesMultinomialText(Runtime rt) : base(rt, new weka.classifiers.bayes.NaiveBayesMultinomialText()) {
      
    }

    /// <summary>
    /// If true, ignores all words that are on the stoplist.
    /// </summary>    
    public NaiveBayesMultinomialText UseStopList (bool u) {
      Impl.setUseStopList(u);
      return this;
    }

    /// <summary>
    /// Use word frequencies rather than binary bag of words representation
    /// </summary>    
    public NaiveBayesMultinomialText UseWordFrequencies (bool u) {
      Impl.setUseWordFrequencies(u);
      return this;
    }

    /// <summary>
    /// How often (number of instances) to prune the dictionary of low frequency
    /// terms. 0 means don't prune. Setting a positive integer n means prune after
    /// every n instances
    /// </summary>    
    public NaiveBayesMultinomialText PeriodicPruning (int p) {
      Impl.setPeriodicPruning(p);
      return this;
    }

    /// <summary>
    /// Ignore any words that don't occur at least min frequency times in the
    /// training data. If periodic pruning is turned on, then the dictionary is pruned
    /// according to this value
    /// </summary>    
    public NaiveBayesMultinomialText MinWordFrequency (double minFreq) {
      Impl.setMinWordFrequency(minFreq);
      return this;
    }

    /// <summary>
    /// If true then document length is normalized according to the settings for
    /// norm and lnorm
    /// </summary>    
    public NaiveBayesMultinomialText NormalizeDocLength (bool norm) {
      Impl.setNormalizeDocLength(norm);
      return this;
    }

    /// <summary>
    /// The norm of the instances after normalization.
    /// </summary>    
    public NaiveBayesMultinomialText Norm (double newNorm) {
      Impl.setNorm(newNorm);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NaiveBayesMultinomialText LNorm (double newLNorm) {
      Impl.setLNorm(newLNorm);
      return this;
    }

    /// <summary>
    /// Whether to convert all tokens to lowercase
    /// </summary>    
    public NaiveBayesMultinomialText LowercaseTokens (bool l) {
      Impl.setLowercaseTokens(l);
      return this;
    }

    /// <summary>
    /// The tokenizing algorithm to use on the strings.
    /// </summary>    
    public NaiveBayesMultinomialText Tokenizer (weka.core.tokenizers.Tokenizer value) {
      Impl.setTokenizer(value);
      return this;
    }

    /// <summary>
    /// The stemming algorithm to use on the words.
    /// </summary>    
    public NaiveBayesMultinomialText Stemmer (weka.core.stemmers.Stemmer value) {
      Impl.setStemmer(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayesMultinomialText Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}