using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This filter takes a dataset and outputs a specified fold for cross
  /// validation. If you do not want the folds to be stratified use the unsupervised
  /// version.<br/><br/>Options:<br/><br/>-V = 	Specifies if inverse of selection
  /// is to be output.<br/><br/>-N &lt;number of folds&gt; = 	Specifies number of
  /// folds dataset is split into. <br/>	(default 10)<br/><br/>-F &lt;fold&gt; =
  /// 	Specifies which fold is selected. (default 1)<br/><br/>-S &lt;seed&gt; =
  /// 	Specifies random number seed. (default 0, no randomizing)<br/>
  /// </summary>
  public class StratifiedRemoveFolds : BaseFilter<weka.filters.supervised.instance.StratifiedRemoveFolds>
  {
    public StratifiedRemoveFolds(Runtime rt) : base(rt, new weka.filters.supervised.instance.StratifiedRemoveFolds()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public StratifiedRemoveFolds InvertSelection (bool inverse) {
      Impl.setInvertSelection(inverse);
      return this;
    }

    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public StratifiedRemoveFolds NumFolds (int numFolds) {
      Impl.setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public StratifiedRemoveFolds Fold (int fold) {
      Impl.setFold(fold);
      return this;
    }

        
        
  }
}