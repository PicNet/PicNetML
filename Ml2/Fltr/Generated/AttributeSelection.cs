using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A supervised attribute filter that can be used to select attributes. It
  /// is very flexible and allows various search and evaluation methods to be
  /// combined.<br/><br/>Options:<br/><br/>-S &lt;"Name of search class [search
  /// options]"&gt; = 	Sets search method for subset evaluators.<br/>	eg. -S
  /// "weka.attributeSelection.BestFirst -S 8"<br/>-E &lt;"Name of attribute/subset
  /// evaluation class [evaluator options]"&gt; = 	Sets attribute/subset
  /// evaluator.<br/>	eg. -E "weka.attributeSelection.CfsSubsetEval -L"<br/><br/>Options
  /// specific to evaluator weka.attributeSelection.CfsSubsetEval: = <br/>-M = 	Treat
  /// missing values as a separate value.<br/>-L = 	Don't include locally
  /// predictive attributes.<br/><br/>Options specific to search
  /// weka.attributeSelection.BestFirst: = <br/>-P &lt;start set&gt; = 	Specify a starting set of
  /// attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward | 1 = forward | 2 =
  /// bi-directional&gt; = 	Direction of search. (default = 1).<br/>-N &lt;num&gt; =
  /// 	Number of non-improving nodes to<br/>	consider before terminating
  /// search.<br/>-S &lt;num&gt; = 	Size of lookup cache for evaluated
  /// subsets.<br/>	Expressed as a multiple of the number of<br/>	attributes in the data set. (default
  /// = 1)
  /// </summary>
  public class AttributeSelection : BaseFilter<weka.filters.supervised.attribute.AttributeSelection>
  {
    public AttributeSelection(Runtime rt) : base(rt, new weka.filters.supervised.attribute.AttributeSelection()) {
      
    }

    /// <summary>
    /// Determines how attributes/attribute subsets are evaluated.
    /// </summary>    
    public AttributeSelection Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<weka.attributeSelection.ASEvaluation> evaluator) {
      Impl.setEvaluator(evaluator.Impl);
      return this;
    }

    /// <summary>
    /// Determines the search method.
    /// </summary>    
    public AttributeSelection Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<weka.attributeSelection.ASSearch> search) {
      Impl.setSearch(search.Impl);
      return this;
    }

        
        
  }
}