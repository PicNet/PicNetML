using System.Collections.Generic;
using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a simple decision table majority
  /// classifier.<br/><br/>For more information see: <br/><br/>Ron Kohavi: The Power of
  /// Decision Tables. In: 8th European Conference on Machine Learning, 174-189,
  /// 1995.<br/><br/>Options:<br/><br/>-S &lt;search method specification&gt; = 	Full
  /// class name of search method, followed<br/>	by its options.<br/>	eg:
  /// "weka.attributeSelection.BestFirst -D 1"<br/>	(default
  /// weka.attributeSelection.BestFirst)<br/>-X &lt;number of folds&gt; = 	Use cross validation to evaluate
  /// features.<br/>	Use number of folds = 1 for leave one out CV.<br/>	(Default
  /// = leave one out CV)<br/>-E &lt;acc | rmse | mae | auc&gt; = 	Performance
  /// evaluation measure to use for selecting attributes.<br/>	(Default = accuracy
  /// for discrete class and rmse for numeric class)<br/>-I = 	Use nearest
  /// neighbour instead of global table majority.<br/>-R = 	Display decision table
  /// rules.<br/><br/><br/>Options specific to search method
  /// weka.attributeSelection.BestFirst: = <br/>-P &lt;start set&gt; = 	Specify a starting set of
  /// attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward | 1 = forward | 2 =
  /// bi-directional&gt; = 	Direction of search. (default = 1).<br/>-N &lt;num&gt; =
  /// 	Number of non-improving nodes to<br/>	consider before terminating
  /// search.<br/>-S &lt;num&gt; = 	Size of lookup cache for evaluated
  /// subsets.<br/>	Expressed as a multiple of the number of<br/>	attributes in the data set. (default
  /// = 1)
  /// </summary>
  public class DecisionTable : BaseClassifier<weka.classifiers.rules.DecisionTable>
  {
    public DecisionTable(Runtime rt) : base(rt, new weka.classifiers.rules.DecisionTable()) {
      
    }

    /// <summary>
    /// The measure used to evaluate the performance of attribute combinations
    /// used in the decision table.
    /// </summary>    
    public DecisionTable EvaluationMeasure (EEvaluationMeasure newMethod) {
      Impl.setEvaluationMeasure(new weka.core.SelectedTag((int) newMethod, weka.classifiers.rules.DecisionTable.TAGS_EVALUATION));
      return this;
    }

    /// <summary>
    /// The search method used to find good attribute combinations for the
    /// decision table.
    /// </summary>    
    public DecisionTable Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<weka.attributeSelection.ASSearch> search) {
      Impl.setSearch(search.Impl);
      return this;
    }

    /// <summary>
    /// Sets the number of folds for cross validation (1 = leave one out).
    /// </summary>    
    public DecisionTable CrossVal (int folds) {
      Impl.setCrossVal(folds);
      return this;
    }

    /// <summary>
    /// Sets whether IBk should be used instead of the majority class.
    /// </summary>    
    public DecisionTable UseIBk (bool ibk) {
      Impl.setUseIBk(ibk);
      return this;
    }

    /// <summary>
    /// Sets whether rules are to be printed.
    /// </summary>    
    public DecisionTable DisplayRules (bool rules) {
      Impl.setDisplayRules(rules);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionTable Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EEvaluationMeasure {
      Default__accuracy_discrete_class_RMSE_numeric_class = 1,
      Accuracy_discrete_class_only = 2,
      RMSE_of_the_class_probabilities_for_discrete_class = 3,
      MAE_of_the_class_probabilities_for_discrete_class = 4,
      AUC_area_under_the_ROC_curve___discrete_class_only = 5
    }

        
  }
}