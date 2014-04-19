using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PicNetML
{
  [Serializable] public partial class Runtime : IEnumerable<PmlInstance>
  {
    private static long start = DateTime.Now.Ticks;
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

    public IEnumerator<PmlInstance> GetEnumerator() { return Impl.ToEnumerable().GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
    [IndexerName("GetInstance")] public PmlInstance this[int index] { get { return Instance(index); } }

    public static void Debug(string message, params object[] args)
    {
      Console.WriteLine("[{0}] {1}", 
          ((DateTime.Now.Ticks - start) / TimeSpan.TicksPerSecond) + " s", 
          String.Format(message, args));
    }
  }
}