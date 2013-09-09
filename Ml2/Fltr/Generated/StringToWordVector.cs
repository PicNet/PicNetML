using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts String attributes into a set of attributes representing word
  /// occurrence (depending on the tokenizer) information from the text contained in
  /// the strings. The set of words (attributes) is determined by the first
  /// batch filtered (typically training data).<br/><br/>Options:<br/><br/>-C =
  /// 	Output word counts rather than boolean word presence.<br/><br/>-R
  /// &lt;index1,index2-index4,...&gt; = 	Specify list of string attributes to convert to
  /// words (as weka Range).<br/>	(default: select all string attributes)<br/>-V =
  /// 	Invert matching sense of column indexes.<br/>-P &lt;attribute name
  /// prefix&gt; = 	Specify a prefix for the created attribute names.<br/>	(default:
  /// "")<br/>-W &lt;number of words to keep&gt; = 	Specify approximate number of word
  /// fields to create.<br/>	Surplus words will be discarded..<br/>	(default:
  /// 1000)<br/>-prune-rate &lt;rate as a percentage of dataset&gt; = 	Specify the
  /// rate (e.g., every 10% of the input dataset) at which to periodically prune
  /// the dictionary.<br/>	-W prunes after creating a full dictionary. You may
  /// not have enough memory for this approach.<br/>	(default: no periodic
  /// pruning)<br/>-T = 	Transform the word frequencies into log(1+fij)<br/>	where fij is
  /// the frequency of word i in jth document(instance).<br/><br/>-I =
  /// 	Transform each word frequency into:<br/>	fij*log(num of Documents/num of documents
  /// containing word i)<br/>	 where fij if frequency of word i in jth
  /// document(instance)<br/>-N = 	Whether to 0=not normalize/1=normalize all
  /// data/2=normalize test data only<br/>	to average length of training documents (default
  /// 0=don't normalize).<br/>-L = 	Convert all tokens to lowercase before adding
  /// to the dictionary.<br/>-S = 	Ignore words that are in the
  /// stoplist.<br/>-stemmer &lt;spec&gt; = 	The stemmering algorihtm (classname plus parameters)
  /// to use.<br/>-M &lt;int&gt; = 	The minimum term frequency (default =
  /// 1).<br/>-O = 	If this is set, the maximum number of words and the <br/>	minimum
  /// term frequency is not enforced on a per-class <br/>	basis but based on the
  /// documents in all the classes <br/>	(even if a class attribute is
  /// set).<br/>-stopwords &lt;file&gt; = 	A file containing stopwords to override the default
  /// ones.<br/>	Using this option automatically sets the flag ('-S') to use
  /// the<br/>	stoplist if the file exists.<br/>	Format: one stopword per line,
  /// lines starting with '#'<br/>	are interpreted as comments and
  /// ignored.<br/>-tokenizer &lt;spec&gt; = 	The tokenizing algorihtm (classname plus parameters)
  /// to use.<br/>	(default: weka.core.tokenizers.WordTokenizer)
  /// </summary>
  public class StringToWordVector : BaseFilter<weka.filters.unsupervised.attribute.StringToWordVector>
  {
    public StringToWordVector(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.StringToWordVector()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector SelectedRange (string newSelectedRange) {
      Impl.setSelectedRange(newSelectedRange);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected attributes in the
    /// range will be worked on; if true, only non-selected attributes will be
    /// processed.
    /// </summary>    
    public StringToWordVector InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Prefix for the created attribute names. (default: "")
    /// </summary>    
    public StringToWordVector AttributeNamePrefix (string newPrefix) {
      Impl.setAttributeNamePrefix(newPrefix);
      return this;
    }

    /// <summary>
    /// The number of words (per class if there is a class attribute assigned) to
    /// attempt to keep.
    /// </summary>    
    public StringToWordVector WordsToKeep (int newWordsToKeep) {
      Impl.setWordsToKeep(newWordsToKeep);
      return this;
    }

    /// <summary>
    /// Specify the rate (x% of the input dataset) at which to periodically prune
    /// the dictionary. wordsToKeep prunes after creating a full dictionary. You
    /// may not have enough memory for this approach.
    /// </summary>    
    public StringToWordVector PeriodicPruning (double newPeriodicPruning) {
      Impl.setPeriodicPruning(newPeriodicPruning);
      return this;
    }

    /// <summary>
    /// Sets the minimum term frequency. This is enforced on a per-class basis.
    /// </summary>    
    public StringToWordVector MinTermFreq (int newMinTermFreq) {
      Impl.setMinTermFreq(newMinTermFreq);
      return this;
    }

    /// <summary>
    /// Output word counts rather than boolean 0 or 1(indicating presence or
    /// absence of a word).
    /// </summary>    
    public StringToWordVector OutputWordCounts (bool outputWordCounts) {
      Impl.setOutputWordCounts(outputWordCounts);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector TFTransform (bool TFTransform) {
      Impl.setTFTransform(TFTransform);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector IDFTransform (bool IDFTransform) {
      Impl.setIDFTransform(IDFTransform);
      return this;
    }

    /// <summary>
    /// If this is set, the maximum number of words and the minimum term
    /// frequency is not enforced on a per-class basis but based on the documents in all
    /// the classes (even if a class attribute is set).
    /// </summary>    
    public StringToWordVector DoNotOperateOnPerClassBasis (bool newDoNotOperateOnPerClassBasis) {
      Impl.setDoNotOperateOnPerClassBasis(newDoNotOperateOnPerClassBasis);
      return this;
    }

    /// <summary>
    /// Sets whether if the word frequencies for a document (instance) should be
    /// normalized or not.
    /// </summary>    
    public StringToWordVector NormalizeDocLength (ENormalizeDocLength newType) {
      Impl.setNormalizeDocLength(new weka.core.SelectedTag((int) newType, weka.filters.unsupervised.attribute.StringToWordVector.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// If set then all the word tokens are converted to lower case before being
    /// added to the dictionary.
    /// </summary>    
    public StringToWordVector LowerCaseTokens (bool downCaseTokens) {
      Impl.setLowerCaseTokens(downCaseTokens);
      return this;
    }

    /// <summary>
    /// Ignores all the words that are on the stoplist, if set to true.
    /// </summary>    
    public StringToWordVector UseStoplist (bool useStoplist) {
      Impl.setUseStoplist(useStoplist);
      return this;
    }

    /// <summary>
    /// The stemming algorithm to use on the words.
    /// </summary>    
    public StringToWordVector Stemmer (weka.core.stemmers.Stemmer value) {
      Impl.setStemmer(value);
      return this;
    }

    /// <summary>
    /// The tokenizing algorithm to use on the strings.
    /// </summary>    
    public StringToWordVector Tokenizer (weka.core.tokenizers.Tokenizer value) {
      Impl.setTokenizer(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public StringToWordVector AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
    public enum ENormalizeDocLength {
      No_normalization = 0,
      Normalize_all_data = 1,
      Normalize_test_data_only = 2
    }

        
  }
}