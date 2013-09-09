using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// GreedyStepwise :<br/><br/>Performs a greedy forward or backward search
  /// through the space of attribute subsets. May start with no/all attributes or
  /// from an arbitrary point in the space. Stops when the addition/deletion of
  /// any remaining attributes results in a decrease in evaluation. Can also
  /// produce a ranked list of attributes by traversing the space from one side to the
  /// other and recording the order that attributes are
  /// selected.<br/><br/><br/>Options:<br/><br/>-C = 	Use conservative forward search<br/>-B = 	Use a
  /// backward search instead of a<br/>	forward one.<br/>-P &lt;start set&gt; =
  /// 	Specify a starting set of attributes.<br/>	Eg. 1,3,5-7.<br/>-R = 	Produce a
  /// ranked list of attributes.<br/>-T &lt;threshold&gt; = 	Specify a theshold by
  /// which attributes<br/>	may be discarded from the ranking.<br/>	Use in
  /// conjuction with -R<br/>-N &lt;num to select&gt; = 	Specify number of attributes to
  /// select
  /// </summary>
  public class GreedyStepwise : BaseAttributeSelectionAlgorithm<weka.attributeSelection.GreedyStepwise>
  {
    public GreedyStepwise(Runtime rt) : base(rt, new weka.attributeSelection.GreedyStepwise()) {
      
    }

    /// <summary>
    /// Set to true if a ranked list is required.
    /// </summary>    
    public GreedyStepwise GenerateRanking (bool doRank) {
      Impl.setGenerateRanking(doRank);
      return this;
    }

    /// <summary>
    /// Search backwards rather than forwards.
    /// </summary>    
    public GreedyStepwise SearchBackwards (bool back) {
      Impl.setSearchBackwards(back);
      return this;
    }

    /// <summary>
    /// If true (and forward search is selected) then attributes will continue to
    /// be added to the best subset as long as merit does not degrade.
    /// </summary>    
    public GreedyStepwise ConservativeForwardSelection (bool c) {
      Impl.setConservativeForwardSelection(c);
      return this;
    }

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>    
    public GreedyStepwise StartSet (string startSet) {
      Impl.setStartSet(startSet);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use in conjunction with generateRanking
    /// </summary>    
    public GreedyStepwise Threshold (double threshold) {
      Impl.setThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>    
    public GreedyStepwise NumToSelect (int n) {
      Impl.setNumToSelect(n);
      return this;
    }

        
        
  }
}