// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  public class FiltersSupervisedInstance
  {
    private readonly Runtime rt;    
    public FiltersSupervisedInstance(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Produces a random subsample of a dataset using either sampling with
    /// replacement or without replacement.<br/>The original dataset must fit entirely
    /// in memory. The number of instances in the generated dataset may be
    /// specified. The dataset must have a nominal class attribute. If not, use the
    /// unsupervised version. The filter can be made to maintain the class distribution in
    /// the subsample, or to bias the class distribution toward a uniform
    /// distribution. When used in batch mode (i.e. in the FilteredClassifier), subsequent
    /// batches are NOT resampled.<br/><br/>Options:<br/><br/>-S &lt;num&gt; =
    /// 	Specify the random number seed (default 1)<br/>-Z &lt;num&gt; = 	The size of
    /// the output dataset, as a percentage of<br/>	the input dataset (default
    /// 100)<br/>-B &lt;num&gt; = 	Bias factor towards uniform class distribution.<br/>	0
    /// = distribution in input data -- 1 = uniform distribution.<br/>	(default
    /// 0)<br/>-no-replacement = 	Disables replacement of instances<br/>	(default:
    /// with replacement)<br/>-V = 	Inverts the selection - only available with
    /// '-no-replacement'.
    /// </summary>
    public Resample Resample { get {
      return new Resample(rt); 
    } }

    /// <summary>
    /// Produces a random subsample of a dataset. The original dataset must fit
    /// entirely in memory. This filter allows you to specify the maximum "spread"
    /// between the rarest and most common class. For example, you may specify that
    /// there be at most a 2:1 difference in class frequencies. When used in batch
    /// mode, subsequent batches are NOT resampled.<br/><br/>Options:<br/><br/>-S
    /// &lt;num&gt; = 	Specify the random number seed (default 1)<br/>-M &lt;num&gt;
    /// = 	The maximum class distribution spread.<br/>	0 = no maximum spread, 1 =
    /// uniform distribution, 10 = allow at most<br/>	a 10:1 ratio between the
    /// classes (default 0)<br/>-W = 	Adjust weights so that total weight per class is
    /// maintained.<br/>	Individual instance weighting is not preserved. (default
    /// no<br/>	weights adjustment<br/>-X &lt;num&gt; = 	The maximum count for any
    /// class value (default 0 = unlimited).<br/>
    /// </summary>
    public SpreadSubsample SpreadSubsample { get {
      return new SpreadSubsample(rt); 
    } }

    /// <summary>
    /// This filter takes a dataset and outputs a specified fold for cross
    /// validation. If you do not want the folds to be stratified use the unsupervised
    /// version.<br/><br/>Options:<br/><br/>-V = 	Specifies if inverse of selection
    /// is to be output.<br/><br/>-N &lt;number of folds&gt; = 	Specifies number of
    /// folds dataset is split into. <br/>	(default 10)<br/><br/>-F &lt;fold&gt; =
    /// 	Specifies which fold is selected. (default 1)<br/><br/>-S &lt;seed&gt; =
    /// 	Specifies random number seed. (default 0, no randomizing)<br/>
    /// </summary>
    public StratifiedRemoveFolds StratifiedRemoveFolds { get {
      return new StratifiedRemoveFolds(rt); 
    } }

    /// <summary>
    /// Resamples a dataset by applying the Synthetic Minority Oversampling
    /// TEchnique (SMOTE). The original dataset must fit entirely in memory. The amount
    /// of SMOTE and number of nearest neighbors may be specified. For more
    /// information, see <br/><br/>Nitesh V. Chawla et. al. (2002). Synthetic Minority
    /// Over-sampling Technique. Journal of Artificial Intelligence Research.
    /// 16:321-357.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specifies the random
    /// number seed<br/>	(default 1)<br/>-P &lt;percentage&gt; = 	Specifies percentage
    /// of SMOTE instances to create.<br/>	(default 100.0)<br/><br/>-K
    /// &lt;nearest-neighbors&gt; = 	Specifies the number of nearest neighbors to
    /// use.<br/>	(default 5)<br/><br/>-C &lt;value-index&gt; = 	Specifies the index of the
    /// nominal class value to SMOTE<br/>	(default 0: auto-detect non-empty minority
    /// class))<br/>
    /// </summary>
    public SMOTE SMOTE { get {
      return new SMOTE(rt); 
    } }

    
  }
}