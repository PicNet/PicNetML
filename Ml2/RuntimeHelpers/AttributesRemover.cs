using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ml2.RuntimeHelpers
{
  public class AttributesRemover : IAttributesRemover
  {
    private readonly Runtime rt;

    public AttributesRemover(Runtime rt) {
      this.rt = rt;
    }

    public void KeepAttributes(params object[] attributes) {
      var keepers = GetAllIndexesIdentifiedByArgs(attributes);
      var deleters = Enumerable.Range(0, rt.NumAttributes).
          Except(keepers).
          Distinct().
          OrderByDescending(i => i).
          ToArray();
      Array.ForEach(deleters, rt.DeleteAttributeAt);
    }

    public void RemoveAttributes(params object[] attributes) {
      if (attributes == null || attributes.Length == 0) return;
      
      var deleters = GetAllIndexesIdentifiedByArgs(attributes);
      Array.ForEach(deleters, rt.DeleteAttributeAt);
    }

    private int[] GetAllIndexesIdentifiedByArgs(object[] attributes) {
      if (attributes.Length == 1 && attributes[0] is Array) 
        attributes = ((IEnumerable)attributes.First()).Cast<object>().ToArray(); 

      var indexes = attributes.Where(a => a is int).Cast<int>();
      var names = attributes.Where(a => a is string).Select(a => ((string) a).ToLower());
      var nameidxs = GetNameIndexes(names);
      return indexes.
        Concat(nameidxs).
          Distinct().
          OrderByDescending(i => i).
          ToArray();
    }

    private IEnumerable<int> GetNameIndexes(IEnumerable<string> names) {
      var fields = rt.EnumerateAttributes.Select(a => a.Name.ToLower()).ToArray();
      var idxs = names.Select(n => Array.IndexOf(fields, n)).ToArray();
      
      if (!idxs.All(idx => idx >= 0)) throw new ArgumentException("names");
      return idxs;
    }
  }
}