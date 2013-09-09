using System;
using System.Collections.Generic;
using PicNetML.AttrSel.Evals;
using weka.attributeSelection;

namespace PicNetML.AttrSel.Algs
{
  public interface IBaseAttributeSelectionAlgorithm {
    Runtime Search(IBaseAttributeSelectionEvaluator<ASEvaluation> eval);
  }

  public class BaseAttributeSelectionAlgorithm<I> : IBaseAttributeSelectionAlgorithm where I : ASSearch {
    protected readonly Runtime rt;
    internal I Impl { get; private set; }
    
    public BaseAttributeSelectionAlgorithm(Runtime rt, I impl) { 
      this.rt = rt;
      Impl = impl; 

      InternalHelpers.SetSeedOnInstance(impl);
    }

    public Runtime Search(IBaseAttributeSelectionEvaluator<ASEvaluation> eval) {       
      return rt.Filters.UnsupervisedAttribute.Remove.
          AttributeIndicesArray(SearchIndexes(eval)).
          InvertSelection(true).RunFilter();
    }

    public int[] SearchIndexes(IBaseAttributeSelectionEvaluator<ASEvaluation> eval) { 
      var eimpl = eval.Impl;
      eimpl.buildEvaluator(rt.Impl);
      var indexes = new List<int>(Impl.search(eimpl, rt.Impl)); 
      var classidx = rt.ClassIndex;
      indexes.Add(classidx);
      Console.WriteLine("Keeping indexes: " + String.Join(", ", indexes));
      return indexes.ToArray();
    }
  }
}