// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  public class SupervisedInstanceFilters
  {
    private readonly Runtime rt;    
    public SupervisedInstanceFilters(Runtime rt) { this.rt = rt; }   

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
    public Resample Resample() { return new Resample(rt); }

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
    public SpreadSubsample SpreadSubsample() { return new SpreadSubsample(rt); }

    /// <summary>
    /// This filter takes a dataset and outputs a specified fold for cross
    /// validation. If you do not want the folds to be stratified use the unsupervised
    /// version.<br/><br/>Options:<br/><br/>-V = 	Specifies if inverse of selection
    /// is to be output.<br/><br/>-N &lt;number of folds&gt; = 	Specifies number of
    /// folds dataset is split into. <br/>	(default 10)<br/><br/>-F &lt;fold&gt; =
    /// 	Specifies which fold is selected. (default 1)<br/><br/>-S &lt;seed&gt; =
    /// 	Specifies random number seed. (default 0, no randomizing)<br/>
    /// </summary>
    public StratifiedRemoveFolds StratifiedRemoveFolds() { return new StratifiedRemoveFolds(rt); }

    
  }
}