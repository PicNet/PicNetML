using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Performs a principal components analysis and transformation of the
  /// data.<br/>Dimensionality reduction is accomplished by choosing enough
  /// eigenvectors to account for some percentage of the variance in the original data --
  /// default 0.95 (95%).<br/>Based on code of the attribute selection scheme
  /// 'PrincipalComponents' by Mark Hall and Gabi
  /// Schmidberger.<br/><br/>Options:<br/><br/>-C = 	Center (rather than standardize) the<br/>	data and compute PCA
  /// using the covariance (rather<br/>	 than the correlation) matrix.<br/>-R
  /// &lt;num&gt; = 	Retain enough PC attributes to account<br/>	for this proportion
  /// of variance in the original data.<br/>	(default: 0.95)<br/>-A &lt;num&gt; =
  /// 	Maximum number of attributes to include in <br/>	transformed attribute
  /// names.<br/>	(-1 = include all, default: 5)<br/>-M &lt;num&gt; = 	Maximum
  /// number of PC attributes to retain.<br/>	(-1 = include all, default: -1)
  /// </summary>
  public class PrincipalComponents : BaseFilter<weka.filters.unsupervised.attribute.PrincipalComponents>
  {
    public PrincipalComponents(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.PrincipalComponents()) {
      
    }

    /// <summary>
    /// Retain enough PC attributes to account for this proportion of variance.
    /// </summary>    
    public PrincipalComponents VarianceCovered (double value) {
      Impl.setVarianceCovered(value);
      return this;
    }

    /// <summary>
    /// The maximum number of attributes to include in transformed attribute
    /// names.
    /// </summary>    
    public PrincipalComponents MaximumAttributeNames (int value) {
      Impl.setMaximumAttributeNames(value);
      return this;
    }

    /// <summary>
    /// The maximum number of PC attributes to retain.
    /// </summary>    
    public PrincipalComponents MaximumAttributes (int value) {
      Impl.setMaximumAttributes(value);
      return this;
    }

    /// <summary>
    /// Center (rather than standardize) the data. PCA will be computed from the
    /// covariance (rather than correlation) matrix
    /// </summary>    
    public PrincipalComponents CenterData (bool center) {
      Impl.setCenterData(center);
      return this;
    }

        
        
  }
}