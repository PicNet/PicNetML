using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A simple instance filter that renames the relation, all attribute names
  /// and all nominal (and string) attribute values. For exchanging sensitive
  /// datasets. Currently doesn't like string or relational attributes.
  /// </summary>
  public class Obfuscate : BaseFilter<weka.filters.unsupervised.attribute.Obfuscate>
  {
    public Obfuscate(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Obfuscate()) {
      
    }

        
        
  }
}