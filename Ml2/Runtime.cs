using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ml2
{
  [Serializable] public partial class Runtime : IEnumerable<Ml2Instance>
  {                  
    private static int seed = 1;
    public static int GlobalRandomSeed { 
      get { return seed; } 
      set { seed = value;  rng = null; } 
    }

    private static Random rng;
    public static double Random { 
      get { 
        if (rng == null) rng = new Random(GlobalRandomSeed);
        return rng.NextDouble(); 
      } 
    }

    public IEnumerator<Ml2Instance> GetEnumerator() { return Impl.ToEnumerable().GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
    [IndexerName("GetInstance")] public Ml2Instance this[int index] { get { return Instance(index); } }
  }
}