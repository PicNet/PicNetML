// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersLazy
  {
    private readonly Runtime rt;    
    public ClassifiersLazy(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// K-nearest neighbours classifier. Can select appropriate value of K based
    /// on cross-validation. Can also do distance weighting.<br/><br/>For more
    /// information, see<br/><br/>D. Aha, D. Kibler (1991). Instance-based learning
    /// algorithms. Machine Learning. 6:37-66.<br/><br/>Options:<br/><br/>-I = 	Weight
    /// neighbours by the inverse of their distance<br/>	(use when k > 1)<br/>-F =
    /// 	Weight neighbours by 1 - their distance<br/>	(use when k > 1)<br/>-K
    /// &lt;number of neighbors&gt; = 	Number of nearest neighbours (k) used in
    /// classification.<br/>	(Default = 1)<br/>-E = 	Minimise mean squared error rather
    /// than mean absolute<br/>	error when using -X option with numeric
    /// prediction.<br/>-W &lt;window size&gt; = 	Maximum number of training instances
    /// maintained.<br/>	Training instances are dropped FIFO. (Default = no window)<br/>-X =
    /// 	Select the number of nearest neighbours between 1<br/>	and the k value
    /// specified using hold-one-out evaluation<br/>	on the training data (use when k
    /// > 1)<br/>-A = 	The nearest neighbour search algorithm to use (default:
    /// weka.core.neighboursearch.LinearNNSearch).<br/>
    /// </summary>
    public IBk IBk { get {
      return new IBk(rt); 
    } }

    /// <summary>
    /// K* is an instance-based classifier, that is the class of a test instance
    /// is based upon the class of those training instances similar to it, as
    /// determined by some similarity function. It differs from other instance-based
    /// learners in that it uses an entropy-based distance function.<br/><br/>For more
    /// information on K*, see<br/><br/>John G. Cleary, Leonard E. Trigg: K*: An
    /// Instance-based Learner Using an Entropic Distance Measure. In: 12th
    /// International Conference on Machine Learning, 108-114,
    /// 1995.<br/><br/>Options:<br/><br/>-B &lt;num&gt; = 	Manual blend setting (default 20%)<br/><br/>-E =
    /// 	Enable entropic auto-blend setting (symbolic class only)<br/><br/>-M
    /// &lt;char&gt; = 	Specify the missing value treatment mode (default a)<br/>	Valid
    /// options are: a(verage), d(elete), m(axdiff), n(ormal)<br/>
    /// </summary>
    public KStar KStar { get {
      return new KStar(rt); 
    } }

    /// <summary>
    /// Locally weighted learning. Uses an instance-based algorithm to assign
    /// instance weights which are then used by a specified
    /// WeightedInstancesHandler.<br/>Can do classification (e.g. using naive Bayes) or regression (e.g.
    /// using linear regression).<br/><br/>For more info, see<br/><br/>Eibe Frank, Mark
    /// Hall, Bernhard Pfahringer: Locally Weighted Naive Bayes. In: 19th
    /// Conference in Uncertainty in Artificial Intelligence, 249-256, 2003.<br/><br/>C.
    /// Atkeson, A. Moore, S. Schaal (1996). Locally weighted learning. AI
    /// Review..<br/><br/>Options:<br/><br/>-A = 	The nearest neighbour search algorithm to
    /// use (default: weka.core.neighboursearch.LinearNNSearch).<br/><br/>-K
    /// &lt;number of neighbours&gt; = 	Set the number of neighbours used to set the
    /// kernel bandwidth.<br/>	(default all)<br/>-U &lt;number of weighting method&gt; =
    /// 	Set the weighting kernel shape to use. 0=Linear,
    /// 1=Epanechnikov,<br/>	2=Tricube, 3=Inverse, 4=Gaussian.<br/>	(default 0 = Linear)<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console
    /// </summary>
    public LWL LWL { get {
      return new LWL(rt); 
    } }

    
  }
}