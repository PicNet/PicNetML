using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Reduces the dimensionality of the data by projecting it onto a lower
  /// dimensional subspace using a random matrix with columns of unit length (i.e. It
  /// will reduce the number of attributes in the data while preserving much of
  /// its variation like PCA, but at a much less computational cost).<br/>It
  /// first applies the NominalToBinary filter to convert all attributes to numeric
  /// before reducing the dimension. It preserves the class
  /// attribute.<br/><br/>For more information, see:<br/><br/>Dmitriy Fradkin, David Madigan:
  /// Experiments with random projections for machine learning. In: KDD '03: Proceedings
  /// of the ninth ACM SIGKDD international conference on Knowledge discovery and
  /// data mining, New York, NY, USA, 517-522, 003.<br/><br/>Options:<br/><br/>-N
  /// &lt;number&gt; = 	The number of dimensions (attributes) the data should be
  /// reduced to<br/>	(default 10; exclusive of the class attribute, if it is
  /// set).<br/>-D [SPARSE1|SPARSE2|GAUSSIAN] = 	The distribution to use for
  /// calculating the random matrix.<br/>	Sparse1 is:<br/>	 sqrt(3)*{-1 with prob(1/6),
  /// 0 with prob(2/3), +1 with prob(1/6)}<br/>	Sparse2 is:<br/>	 {-1 with
  /// prob(1/2), +1 with prob(1/2)}<br/><br/>-P &lt;percent&gt; = 	The percentage of
  /// dimensions (attributes) the data should<br/>	be reduced to (exclusive of the
  /// class attribute, if it is set). This -N<br/>	option is ignored if this
  /// option is present or is greater<br/>	than zero.<br/>-M = 	Replace missing
  /// values using the ReplaceMissingValues filter<br/>-R &lt;num&gt; = 	The random
  /// seed for the random number generator used for<br/>	calculating the random
  /// matrix (default 42).
  /// </summary>
  public class RandomProjection : BaseFilter<weka.filters.unsupervised.attribute.RandomProjection>
  {
    public RandomProjection(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RandomProjection()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The percentage of dimensions (attributes) the data should be reduced to
    /// (inclusive of the class attribute). This NumberOfAttributes option is
    /// ignored if this option is present or is greater than zero.
    /// </summary>    
    public RandomProjection Percent (double newPercent) {
      Impl.setPercent(newPercent);
      return this;
    }

    /// <summary>
    /// The number of dimensions (attributes) the data should be reduced to.
    /// </summary>    
    public RandomProjection NumberOfAttributes (int newAttNum) {
      Impl.setNumberOfAttributes(newAttNum);
      return this;
    }

    /// <summary>
    /// The distribution to use for calculating the random matrix. Sparse1 is:
    /// sqrt(3) * { -1 with prob(1/6), 0 with prob(2/3), +1 with prob(1/6) } Sparse2
    /// is: { -1 with prob(1/2), +1 with prob(1/2) }
    /// </summary>    
    public RandomProjection Distribution (EDistribution newDstr) {
      Impl.setDistribution(new weka.core.SelectedTag((int) newDstr, weka.filters.unsupervised.attribute.RandomProjection.TAGS_DSTRS_TYPE));
      return this;
    }

    /// <summary>
    /// If set the filter uses
    /// weka.filters.unsupervised.attribute.ReplaceMissingValues to replace the missing values
    /// </summary>    
    public RandomProjection ReplaceMissingValues (bool t) {
      Impl.setReplaceMissingValues(t);
      return this;
    }

        
    public enum EDistribution {
      Sparseone = 1,
      Sparse2 = 2,
      Gaussian = 3
    }

        
  }
}