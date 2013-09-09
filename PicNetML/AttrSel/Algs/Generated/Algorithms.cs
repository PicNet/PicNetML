using weka.core;

// ReSharper disable once CheckNamespace
namespace PicNetML.AttrSel.Algs
{
  public class Algorithms
  {
    private readonly Runtime rt;    
    public Algorithms(Runtime rt) { 
      this.rt = rt;
    }   

    /// <summary>
    /// BestFirst:<br/><br/>Searches the space of attribute subsets by greedy
    /// hillclimbing augmented with a backtracking facility. Setting the number of
    /// consecutive non-improving nodes allowed controls the level of backtracking
    /// done. Best first may start with the empty set of attributes and search
    /// forward, or start with the full set of attributes and search backward, or start at
    /// any point and search in both directions (by considering all possible
    /// single attribute additions and deletions at a given
    /// point).<br/><br/><br/>Options:<br/><br/>-P &lt;start set&gt; = 	Specify a starting set of
    /// attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward | 1 = forward | 2 =
    /// bi-directional&gt; = 	Direction of search. (default = 1).<br/>-N &lt;num&gt; = 	Number of
    /// non-improving nodes to<br/>	consider before terminating search.<br/>-S
    /// &lt;num&gt; = 	Size of lookup cache for evaluated subsets.<br/>	Expressed as a
    /// multiple of the number of<br/>	attributes in the data set. (default = 1)
    /// </summary>
    public BestFirst BestFirst { get { 
      return new BestFirst(rt); 
    } }

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
    public GreedyStepwise GreedyStepwise { get { 
      return new GreedyStepwise(rt); 
    } }

    /// <summary>
    /// Ranker : <br/><br/>Ranks attributes by their individual evaluations. Use
    /// in conjunction with attribute evaluators (ReliefF, GainRatio, Entropy
    /// etc).<br/><br/><br/>Options:<br/><br/>-P &lt;start set&gt; = 	Specify a starting
    /// set of attributes.<br/>	Eg. 1,3,5-7.<br/>	Any starting attributes
    /// specified are<br/>	ignored during the ranking.<br/>-T &lt;threshold&gt; = 	Specify
    /// a theshold by which attributes<br/>	may be discarded from the
    /// ranking.<br/>-N &lt;num to select&gt; = 	Specify number of attributes to select
    /// </summary>
    public Ranker Ranker { get { 
      return new Ranker(rt); 
    } }

    
  }
}