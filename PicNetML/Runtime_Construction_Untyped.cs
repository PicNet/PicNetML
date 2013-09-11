using System;
using System.Collections.Generic;
using System.Linq;
using weka.core;

namespace PicNetML
{
  public partial class Runtime
  {    
    public static Runtime FromInstances(IEnumerable<PmlInstance> instances) {
      var all = instances.ToArray();
      if (!all.Any()) throw new ArgumentNullException("instances");
      var template = all.First();
      var impl = new Instances("frominstances", template.EnumerateAttributes.ToArrayList(), all.Length);
      Array.ForEach(all, i => impl.add(i.Impl));
      return new Runtime(impl);
    }
    
    public Runtime Clone() {
      return new Runtime(new Instances(Impl));
    }    
  }
}