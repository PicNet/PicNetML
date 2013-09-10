// ReSharper disable once CheckNamespace
namespace PicNetML.Clstr
{
  public class Clusterers
  {
    private readonly Runtime rt;    
    public Clusterers(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Class implementing the Cobweb and Classit clustering
    /// algorithms.<br/><br/>Note: the application of node operators (merging, splitting etc.) in terms
    /// of ordering and priority differs (and is somewhat ambiguous) between the
    /// original Cobweb and Classit papers. This algorithm always compares the best
    /// host, adding a new leaf, merging the two best hosts, and splitting the best
    /// host when considering where to place a new instance.<br/><br/>For more
    /// information see:<br/><br/>D. Fisher (1987). Knowledge acquisition via
    /// incremental conceptual clustering. Machine Learning. 2(2):139-172.<br/><br/>J. H.
    /// Gennari, P. Langley, D. Fisher (1990). Models of incremental concept
    /// formation. Artificial Intelligence. 40:11-61.<br/><br/>Options:<br/><br/>-A
    /// &lt;acuity&gt; = 	Acuity.<br/>	(default=1.0)<br/>-C &lt;cutoff&gt; =
    /// 	Cutoff.<br/>	(default=0.002)<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 42)
    /// </summary>
    public Cobweb Cobweb { get {
      return new Cobweb(rt); 
    }}

    /// <summary>
    /// Simple EM (expectation maximisation) class.<br/><br/>EM assigns a
    /// probability distribution to each instance which indicates the probability of it
    /// belonging to each of the clusters. EM can decide how many clusters to create
    /// by cross validation, or you may specify apriori how many clusters to
    /// generate.<br/><br/>The cross validation performed to determine the number of
    /// clusters is done in the following steps:<br/>1. the number of clusters is set
    /// to 1<br/>2. the training set is split randomly into 10 folds.<br/>3. EM is
    /// performed 10 times using the 10 folds the usual CV way.<br/>4. the
    /// loglikelihood is averaged over all 10 results.<br/>5. if loglikelihood has increased
    /// the number of clusters is increased by 1 and the program continues at step
    /// 2. <br/><br/>The number of folds is fixed to 10, as long as the number of
    /// instances in the training set is not smaller 10. If this is the case the
    /// number of folds is set equal to the number of
    /// instances.<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters. If omitted or -1 specified,
    /// then <br/>	cross validation is used to select the number of clusters.<br/>-X
    /// &lt;num&gt; = 	Number of folds to use when cross-validating to find the
    /// best number of clusters.<br/>-max &lt;num&gt; = 	Maximum number of clusters to
    /// consider during cross-validation. If omitted or -1 specified, then
    /// <br/>	there is no upper limit on the number of clusters.<br/>-ll-cv &lt;num&gt; =
    /// 	Minimum improvement in cross-validated log likelihood required<br/>	to
    /// consider increasing the number of clusters.<br/>	(default 1e-6)<br/>-I
    /// &lt;num&gt; = 	max iterations.<br/>	(default 100)<br/>-ll-iter &lt;num&gt; =
    /// 	Minimum improvement in log likelihood required<br/>	to perform another
    /// iteration of the E and M steps.<br/>	(default 1e-6)<br/>-V = 	verbose.<br/>-M
    /// &lt;num&gt; = 	minimum allowable standard deviation for normal
    /// density<br/>	computation<br/>	(default 1e-6)<br/>-O = 	Display model in old format (good
    /// when there are many clusters)<br/><br/>-num-slots &lt;num&gt; = 	Number of
    /// execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S &lt;num&gt; =
    /// 	Random number seed.<br/>	(default 100)
    /// </summary>
    public EM EM { get {
      return new EM(rt); 
    }}

    /// <summary>
    /// Cluster data using the FarthestFirst algorithm.<br/><br/>For more
    /// information see:<br/><br/>Hochbaum, Shmoys (1985). A best possible heuristic for
    /// the k-center problem. Mathematics of Operations Research.
    /// 10(2):180-184.<br/><br/>Sanjoy Dasgupta: Performance Guarantees for Hierarchical Clustering.
    /// In: 15th Annual Conference on Computational Learning Theory, 351-363,
    /// 2002.<br/><br/>Notes:<br/>- works as a fast simple approximate clusterer<br/>-
    /// modelled after SimpleKMeans, might be a useful initializer for
    /// it<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters. (default =
    /// 2).<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)
    /// </summary>
    public FarthestFirst FarthestFirst { get {
      return new FarthestFirst(rt); 
    }}

    /// <summary>
    /// Class for running an arbitrary clusterer on data that has been passed
    /// through an arbitrary filter. Like the clusterer, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their
    /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
    /// followed<br/>	by filter options.<br/>	eg:
    /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>(default: weka.filters.AllFilter)<br/>-W = 	Full
    /// name of base clusterer.<br/>	(default:
    /// weka.clusterers.SimpleKMeans)<br/><br/>Options specific to clusterer weka.clusterers.SimpleKMeans: = <br/>-N
    /// &lt;num&gt; = 	number of clusters.<br/>	(default 2).<br/>-P = 	Initialize using
    /// the k-means++ method.<br/><br/>-V = 	Display std. deviations for
    /// centroids.<br/><br/>-M = 	Don't replace missing values with mean/mode.<br/><br/>-A
    /// &lt;classname and options&gt; = 	Distance function to use.<br/>	(default:
    /// weka.core.EuclideanDistance)<br/>-I &lt;num&gt; = 	Maximum number of
    /// iterations.<br/><br/>-O = 	Preserve order of instances.<br/><br/>-fast = 	Enables
    /// faster distance calculations, using cut-off values.<br/>	Disables the
    /// calculation/output of squared errors/distances.<br/><br/>-num-slots &lt;num&gt; =
    /// 	Number of execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S
    /// &lt;num&gt; = 	Random number seed.<br/>	(default 10)
    /// </summary>
    public Filtered Filtered { get {
      return new Filtered(rt); 
    }}

    /// <summary>
    /// Hierarchical clustering class.<br/>Implements a number of classic
    /// agglomorative (i.e. bottom up) hierarchical clustering methodsbased on
    /// .<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-B = 	If set, distance is
    /// interpreted as branch length<br/>	otherwise it is node height.<br/>-N &lt;Nr Of
    /// Clusters&gt; = 	number of clusters<br/>-P = 	Flag to indicate the cluster
    /// should be printed in Newick format.<br/>-L
    /// [SINGLE|COMPLETE|AVERAGE|MEAN|CENTROID|WARD|ADJCOMLPETE|NEIGHBOR_JOINING] = Link type (Single, Complete,
    /// Average, Mean, Centroid, Ward, Adjusted complete, Neighbor joining)<br/>-A
    /// &lt;classname and options&gt; = 	Distance function to use.<br/>	(default:
    /// weka.core.EuclideanDistance)
    /// </summary>
    public Hierarchical Hierarchical { get {
      return new Hierarchical(rt); 
    }}

    /// <summary>
    /// Class for wrapping a Clusterer to make it return a distribution and
    /// density. Fits normal distributions and discrete distributions within each
    /// cluster produced by the wrapped clusterer. Supports the
    /// NumberOfClustersRequestable interface only if the wrapped Clusterer
    /// does.<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	minimum allowable standard deviation for normal density
    /// computation <br/>	(default 1e-6)<br/>-W &lt;clusterer name&gt; = 	Clusterer
    /// to wrap.<br/>	(default weka.clusterers.SimpleKMeans)<br/><br/>Options
    /// specific to clusterer weka.clusterers.SimpleKMeans: = <br/>-N &lt;num&gt; =
    /// 	number of clusters.<br/>	(default 2).<br/>-P = 	Initialize using the
    /// k-means++ method.<br/><br/>-V = 	Display std. deviations for centroids.<br/><br/>-M
    /// = 	Don't replace missing values with mean/mode.<br/><br/>-A &lt;classname
    /// and options&gt; = 	Distance function to use.<br/>	(default:
    /// weka.core.EuclideanDistance)<br/>-I &lt;num&gt; = 	Maximum number of
    /// iterations.<br/><br/>-O = 	Preserve order of instances.<br/><br/>-fast = 	Enables faster
    /// distance calculations, using cut-off values.<br/>	Disables the calculation/output
    /// of squared errors/distances.<br/><br/>-num-slots &lt;num&gt; = 	Number of
    /// execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S &lt;num&gt; =
    /// 	Random number seed.<br/>	(default 10)
    /// </summary>
    public MakeDensityBased MakeDensityBased { get {
      return new MakeDensityBased(rt); 
    }}

    /// <summary>
    /// Cluster data using the k means algorithm. Can use either the Euclidean
    /// distance (default) or the Manhattan distance. If the Manhattan distance is
    /// used, then centroids are computed as the component-wise median rather than
    /// mean. For more information see:<br/><br/>D. Arthur, S. Vassilvitskii:
    /// k-means++: the advantages of carefull seeding. In: Proceedings of the eighteenth
    /// annual ACM-SIAM symposium on Discrete algorithms, 1027-1035,
    /// 2007.<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters.<br/>	(default
    /// 2).<br/>-P = 	Initialize using the k-means++ method.<br/><br/>-V = 	Display std.
    /// deviations for centroids.<br/><br/>-M = 	Don't replace missing values with
    /// mean/mode.<br/><br/>-A &lt;classname and options&gt; = 	Distance function
    /// to use.<br/>	(default: weka.core.EuclideanDistance)<br/>-I &lt;num&gt; =
    /// 	Maximum number of iterations.<br/><br/>-O = 	Preserve order of
    /// instances.<br/><br/>-fast = 	Enables faster distance calculations, using cut-off
    /// values.<br/>	Disables the calculation/output of squared
    /// errors/distances.<br/><br/>-num-slots &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 -
    /// i.e. no parallelism)<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 10)
    /// </summary>
    public SimpleKMeans SimpleKMeans { get {
      return new SimpleKMeans(rt); 
    }}

    
  }
}