using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// ReliefFAttributeEval :<br/><br/>Evaluates the worth of an attribute by
  /// repeatedly sampling an instance and considering the value of the given
  /// attribute for the nearest instance of the same and different class. Can operate
  /// on both discrete and continuous class data.<br/><br/>For more information
  /// see:<br/><br/>Kenji Kira, Larry A. Rendell: A Practical Approach to Feature
  /// Selection. In: Ninth International Workshop on Machine Learning, 249-256,
  /// 1992.<br/><br/>Igor Kononenko: Estimating Attributes: Analysis and Extensions
  /// of RELIEF. In: European Conference on Machine Learning, 171-182,
  /// 1994.<br/><br/>Marko Robnik-Sikonja, Igor Kononenko: An adaptation of Relief for
  /// attribute estimation in regression. In: Fourteenth International Conference on
  /// Machine Learning, 296-304, 1997.<br/><br/>Options:<br/><br/>-M &lt;num
  /// instances&gt; = 	Specify the number of instances to<br/>	sample when
  /// estimating attributes.<br/>	If not specified, then all instances<br/>	will be
  /// used.<br/>-D &lt;seed&gt; = 	Seed for randomly sampling instances.<br/>	(Default
  /// = 1)<br/>-K &lt;number of neighbours&gt; = 	Number of nearest neighbours
  /// (k) used<br/>	to estimate attribute relevances<br/>	(Default = 10).<br/>-W =
  /// 	Weight nearest neighbours by distance<br/>-A &lt;num&gt; = 	Specify sigma
  /// value (used in an exp<br/>	function to control how quickly<br/>	weights for
  /// more distant instances<br/>	decrease. Use in conjunction with
  /// -W.<br/>	Sensible value=1/5 to 1/10 of the<br/>	number of nearest
  /// neighbours.<br/>	(Default = 2)
  /// </summary>
  public class ReliefFAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.ReliefFAttributeEval>
  {
    public ReliefFAttribute(Runtime rt) : base(rt, new weka.attributeSelection.ReliefFAttributeEval()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }
    
    /// <summary>
    /// Weight nearest neighbours by their distance.
    /// </summary>    
    public ReliefFAttribute WeightByDistance (bool b) {
      Impl.setWeightByDistance(b);
      return this;
    }

    /// <summary>
    /// Number of instances to sample. Default (-1) indicates that all instances
    /// will be used for attribute estimation.
    /// </summary>    
    public ReliefFAttribute SampleSize (int s) {
      Impl.setSampleSize(s);
      return this;
    }

    /// <summary>
    /// Number of nearest neighbours for attribute estimation.
    /// </summary>    
    public ReliefFAttribute NumNeighbours (int n) {
      Impl.setNumNeighbours(n);
      return this;
    }

    /// <summary>
    /// Set influence of nearest neighbours. Used in an exp function to control
    /// how quickly weights decrease for more distant instances. Use in conjunction
    /// with weightByDistance. Sensible values = 1/5 to 1/10 the number of nearest
    /// neighbours.
    /// </summary>    
    public ReliefFAttribute Sigma (int s) {
      Impl.setSigma(s);
      return this;
    }

            
        
  }
}