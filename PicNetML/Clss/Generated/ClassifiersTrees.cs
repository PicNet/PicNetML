// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersTrees
  {
    private readonly Runtime rt;    
    public ClassifiersTrees(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Class for building and using a decision stump. Usually used in
    /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
    /// or classification (based on entropy). Missing is treated as a separate
    /// value.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console
    /// </summary>
    public DecisionStump DecisionStump { get {
      return new DecisionStump(rt); 
    } }

    /// <summary>
    /// Class for generating a pruned or unpruned C4.5 decision tree. For more
    /// information, see<br/><br/>Ross Quinlan (1993). C4.5: Programs for Machine
    /// Learning. Morgan Kaufmann Publishers, San Mateo,
    /// CA.<br/><br/>Options:<br/><br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
    /// &lt;pruning confidence&gt; = 	Set confidence threshold for pruning.<br/>	(default
    /// 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
    /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
    /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B = 	Use
    /// binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L = 	Do not
    /// clean up after the tree has been built.<br/>-A = 	Laplace smoothing for
    /// predicted probabilities.<br/>-J = 	Do not use MDL correction for info gain on
    /// numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling
    /// (default 1).
    /// </summary>
    public J48 J48 { get {
      return new J48(rt); 
    } }

    /// <summary>
    /// Classifier for building 'logistic model trees', which are classification
    /// trees with logistic regression functions at the leaves. The algorithm can
    /// deal with binary and multi-class target variables, numeric and nominal
    /// attributes and missing values.<br/><br/>For more information see:
    /// <br/><br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model Trees. Machine
    /// Learning. 95(1-2):161-205.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall:
    /// Speeding up Logistic Model Tree Induction. In: 9th European Conference on
    /// Principles and Practice of Knowledge Discovery in Databases, 675-683,
    /// 2005.<br/><br/>Options:<br/><br/>-B = 	Binary splits (convert nominal attributes to
    /// binary ones)<br/>-R = 	Split on residuals instead of class values<br/>-C =
    /// 	Use cross-validation for boosting at all nodes (i.e., disable
    /// heuristic)<br/>-P = 	Use error on probabilities instead of misclassification error for
    /// stopping criterion of LogitBoost.<br/>-I &lt;numIterations&gt; = 	Set fixed
    /// number of iterations for LogitBoost (instead of using
    /// cross-validation)<br/>-M &lt;numInstances&gt; = 	Set minimum number of instances at which a node
    /// can be split (default 15)<br/>-W &lt;beta&gt; = 	Set beta for weight
    /// trimming for LogitBoost. Set to 0 (default) for no weight trimming.<br/>-A = 	The
    /// AIC is used to choose the best iteration.
    /// </summary>
    public LMT LMT { get {
      return new LMT(rt); 
    } }

    /// <summary>
    /// M5Base. Implements base routines for generating M5 Model trees and
    /// rules<br/>The original algorithm M5 was invented by R. Quinlan and Yong Wang made
    /// improvements.<br/><br/>For more information see:<br/><br/>Ross J. Quinlan:
    /// Learning with Continuous Classes. In: 5th Australian Joint Conference on
    /// Artificial Intelligence, Singapore, 343-348, 1992.<br/><br/>Y. Wang, I. H.
    /// Witten: Induction of model trees for predicting continuous classes. In:
    /// Poster papers of the 9th European Conference on Machine Learning,
    /// 1997.<br/><br/>Options:<br/><br/>-N = 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed
    /// predictions<br/>-R = 	Build regression tree/rule rather than a model
    /// tree/rule<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes
    /// in<br/>	the tree (for visualization purposes)
    /// </summary>
    public M5P M5P { get {
      return new M5P(rt); 
    } }

    /// <summary>
    /// Fast decision tree learner. Builds a decision/regression tree using
    /// information gain/variance and prunes it using reduced-error pruning (with
    /// backfitting). Only sorts values for numeric attributes once. Missing values are
    /// dealt with by splitting the corresponding instances into pieces (i.e. as in
    /// C4.5).<br/><br/>Options:<br/><br/>-M &lt;minimum number of instances&gt; =
    /// 	Set minimum number of instances per leaf (default 2).<br/>-V &lt;minimum
    /// variance for split&gt; = 	Set minimum numeric class variance
    /// proportion<br/>	of train variance for split (default 1e-3).<br/>-N &lt;number of folds&gt;
    /// = 	Number of folds for reduced error pruning (default 3).<br/>-S
    /// &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P = 	No
    /// pruning.<br/>-L = 	Maximum tree depth (default -1, no maximum)<br/>-I = 	Initial class
    /// value count (default 0)<br/>-R = 	Spread initial count over all class
    /// values (i.e. don't use 1 per value)
    /// </summary>
    public REPTree REPTree { get {
      return new REPTree(rt); 
    } }

    /// <summary>
    /// Class for constructing a forest of random trees.<br/><br/>For more
    /// information see: <br/><br/>Leo Breiman (2001). Random Forests. Machine Learning.
    /// 45(1):5-32.<br/><br/>Options:<br/><br/>-I &lt;number of trees&gt; = 	Number
    /// of trees to build.<br/>-K &lt;number of features&gt; = 	Number of features
    /// to consider (<1=int(logM+1)).<br/>-S = 	Seed for random number
    /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the trees,
    /// 0 for unlimited.<br/>	(default 0)<br/>-print = 	Print the individual trees
    /// in the output<br/>-num-slots &lt;num&gt; = 	Number of execution
    /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console
    /// </summary>
    public RandomForest RandomForest { get {
      return new RandomForest(rt); 
    } }

    /// <summary>
    /// Class for constructing a tree that considers K randomly chosen attributes
    /// at each node. Performs no pruning. Also has an option to allow estimation
    /// of class probabilities based on a hold-out set
    /// (backfitting).<br/><br/>Options:<br/><br/>-K &lt;number of attributes&gt; = 	Number of attributes to
    /// randomly investigate<br/>	(<0 = int(log_2(#attributes)+1)).<br/>-M
    /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>-S &lt;num&gt; = 	Seed for random number generator.<br/>	(default
    /// 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0 for
    /// unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for backfitting (default 0,
    /// no backfitting).<br/>-U = 	Allow unclassified instances.<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public RandomTree RandomTree { get {
      return new RandomTree(rt); 
    } }

    
  }
}