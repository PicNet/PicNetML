using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace PicNetML.AttrSel.Algs
{
  /// <summary>
  /// Ranker : <br/><br/>Ranks attributes by their individual evaluations. Use
  /// in conjunction with attribute evaluators (ReliefF, GainRatio, Entropy
  /// etc).<br/><br/><br/>Options:<br/><br/>-P &lt;start set&gt; = 	Specify a starting
  /// set of attributes.<br/>	Eg. 1,3,5-7.<br/>	Any starting attributes
  /// specified are<br/>	ignored during the ranking.<br/>-T &lt;threshold&gt; = 	Specify
  /// a theshold by which attributes<br/>	may be discarded from the
  /// ranking.<br/>-N &lt;num to select&gt; = 	Specify number of attributes to select
  /// </summary>
  public class Ranker : BaseAttributeSelectionAlgorithm<weka.attributeSelection.Ranker>
  {
    public Ranker(Runtime rt) : base(rt, new weka.attributeSelection.Ranker()) {
      
    }

    /// <summary>
    /// Specify a set of attributes to ignore. When generating the ranking,
    /// Ranker will not evaluate the attributes in this list. This is specified as a
    /// comma seperated list off attribute indexes starting at 1. It can include
    /// ranges. Eg. 1,2,5-9,17.
    /// </summary>    
    public Ranker StartSet (string startSet) {
      Impl.setStartSet(startSet);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use either this option or numToSelect to
    /// reduce the attribute set.
    /// </summary>    
    public Ranker Threshold (double threshold) {
      Impl.setThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>    
    public Ranker NumToSelect (int n) {
      Impl.setNumToSelect(n);
      return this;
    }

    /// <summary>
    /// A constant option. Ranker is only capable of generating attribute
    /// rankings.
    /// </summary>    
    public Ranker GenerateRanking (bool doRank) {
      Impl.setGenerateRanking(doRank);
      return this;
    }

        
        
  }
}