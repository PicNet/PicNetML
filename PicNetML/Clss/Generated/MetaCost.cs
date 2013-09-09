using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// This metaclassifier makes its base classifier cost-sensitive using the
  /// method specified in<br/><br/>Pedro Domingos: MetaCost: A general method for
  /// making classifiers cost-sensitive. In: Fifth International Conference on
  /// Knowledge Discovery and Data Mining, 155-164, 1999.<br/><br/>This classifier
  /// should produce similar results to one created by passing the base learner to
  /// Bagging, which is in turn passed to a CostSensitiveClassifier operating on
  /// minimum expected cost. The difference is that MetaCost produces a single
  /// cost-sensitive classifier of the base learner, giving the benefits of fast
  /// classification and interpretable output (if the base learner itself is
  /// interpretable). This implementation uses all bagging iterations when
  /// reclassifying training data (the MetaCost paper reports a marginal improvement when
  /// only those iterations containing each training instance are used in
  /// reclassifying that instance).<br/><br/>Options:<br/><br/>-I &lt;num&gt; = 	Number of
  /// bagging iterations.<br/>	(default 10)<br/>-C &lt;cost file name&gt; =
  /// 	File name of a cost matrix to use. If this is not supplied,<br/>	a cost matrix
  /// will be loaded on demand. The name of the<br/>	on-demand file is the
  /// relation name of the training data<br/>	plus ".cost", and the path to the
  /// on-demand file is<br/>	specified with the -N option.<br/>-N &lt;directory&gt; =
  /// 	Name of a directory to search for cost files when loading<br/>	costs on
  /// demand (default current directory).<br/>-cost-matrix &lt;matrix&gt; = 	The
  /// cost matrix in Matlab single line format.<br/>-P = 	Size of each bag, as a
  /// percentage of the<br/>	training set size. (default 100)<br/>-S &lt;num&gt; =
  /// 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in
  /// debug mode and<br/>	may output additional info to the console<br/>-W =
  /// 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR: =
  /// <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class MetaCost : BaseClassifier<weka.classifiers.meta.MetaCost>
  {
    public MetaCost(Runtime rt) : base(rt, new weka.classifiers.meta.MetaCost()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The number of bagging iterations.
    /// </summary>    
    public MetaCost NumIterations (int numIterations) {
      Impl.setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The size of each bag, as a percentage of the training set size.
    /// </summary>    
    public MetaCost BagSizePercent (int newBagSizePercent) {
      Impl.setBagSizePercent(newBagSizePercent);
      return this;
    }

    /// <summary>
    /// A misclassification cost matrix.
    /// </summary>    
    public MetaCost CostMatrix (double[,] newCostMatrix) {
      Impl.setCostMatrix(new CostMatrix(Runtime.NumClasses, newCostMatrix).Impl);
      return this;
    }

    /// <summary>
    /// Gets the source location method of the cost matrix. Will be one of
    /// MATRIX_ON_DEMAND or MATRIX_SUPPLIED.
    /// </summary>    
    public MetaCost CostMatrixSource (ECostMatrixSource newMethod) {
      Impl.setCostMatrixSource(new weka.core.SelectedTag((int) newMethod, weka.classifiers.meta.MetaCost.TAGS_MATRIX_SOURCE));
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MetaCost Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MetaCost Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum ECostMatrixSource {
      Load_cost_matrix_on_demand = 1,
      Use_explicit_cost_matrix = 2
    }

        
  }
}