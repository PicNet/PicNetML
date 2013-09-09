using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace PicNetML.AttrSel.Evals
{
  /// <summary>
  /// Performs latent semantic analysis and transformation of the data. Use in
  /// conjunction with a Ranker search. A low-rank approximation of the full data
  /// is found by either specifying the number of singular values to use or
  /// specifying a proportion of the singular values to
  /// cover.<br/><br/>Options:<br/><br/>-N = 	Normalize input data.<br/>-R = 	Rank approximation used in LSA.
  /// <br/>	May be actual number of LSA attributes <br/>	to include (if greater
  /// than 1) or a <br/>	proportion of total singular values to <br/>	account for
  /// (if between 0 and 1). <br/>	A value less than or equal to zero means
  /// <br/>	use all latent variables.(default = 0.95)<br/>-A = 	Maximum number of
  /// attributes to include<br/>	in transformed attribute names.<br/>	(-1 = include
  /// all)
  /// </summary>
  public class LatentSemanticAnalysis : BaseAttributeSelectionEvaluator<weka.attributeSelection.LatentSemanticAnalysis>
  {
    public LatentSemanticAnalysis(Runtime rt) : base(rt, new weka.attributeSelection.LatentSemanticAnalysis()) {
      
    }
    
    /// <summary>
    /// Matrix rank to use for data reduction. Can be a proportion to indicate
    /// desired coverage
    /// </summary>    
    public LatentSemanticAnalysis Rank (double newRank) {
      Impl.setRank(newRank);
      return this;
    }

    /// <summary>
    /// The maximum number of attributes to include in transformed attribute
    /// names.
    /// </summary>    
    public LatentSemanticAnalysis MaximumAttributeNames (int newMaxAttributes) {
      Impl.setMaximumAttributeNames(newMaxAttributes);
      return this;
    }

    /// <summary>
    /// Normalize input data.
    /// </summary>    
    public LatentSemanticAnalysis Normalize (bool newNormalize) {
      Impl.setNormalize(newNormalize);
      return this;
    }

            
        
  }
}