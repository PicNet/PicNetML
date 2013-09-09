using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// CfsSubsetEval :<br/><br/>Evaluates the worth of a subset of attributes by
  /// considering the individual predictive ability of each feature along with
  /// the degree of redundancy between them.<br/><br/>Subsets of features that are
  /// highly correlated with the class while having low intercorrelation are
  /// preferred.<br/><br/>For more information see:<br/><br/>M. A. Hall (1998).
  /// Correlation-based Feature Subset Selection for Machine Learning. Hamilton, New
  /// Zealand.<br/><br/>Options:<br/><br/>-M = 	Treat missing values as a
  /// separate value.<br/>-L = 	Don't include locally predictive attributes.
  /// </summary>
  public class CfsSubset : BaseAttributeSelectionEvaluator<weka.attributeSelection.CfsSubsetEval>
  {
    public CfsSubset(Runtime rt) : base(rt, new weka.attributeSelection.CfsSubsetEval()) {
      
    }
    
    /// <summary>
    /// Treat missing as a separate value. Otherwise, counts for missing values
    /// are distributed across other values in proportion to their frequency.
    /// </summary>    
    public CfsSubset MissingSeparate (bool b) {
      Impl.setMissingSeparate(b);
      return this;
    }

    /// <summary>
    /// Identify locally predictive attributes. Iteratively adds attributes with
    /// the highest correlation with the class as long as there is not already an
    /// attribute in the subset that has a higher correlation with the attribute in
    /// question
    /// </summary>    
    public CfsSubset LocallyPredictive (bool b) {
      Impl.setLocallyPredictive(b);
      return this;
    }

            
        
  }
}