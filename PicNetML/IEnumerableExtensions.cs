using System;
using System.Collections.Generic;
using System.Linq;
using java.util;

namespace PicNetML
{
  public static class IEnumerableExtensions
  {
    public static T GetMajority<T>(this IEnumerable<T> data) {
      return data.GroupBy(i=>i).OrderByDescending(grp=>grp.Count())
        .Select(grp=>grp.Key).First();
    }

    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> data)
    {
      return data.OrderBy(d => Runtime.Random).ToList();
    }

    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> data, int size, int seed = 0)
    {
      var lst = data.ToList();
      if (size <= 0 || size > lst.Count) throw new ArgumentException("size");
      if (size == lst.Count) return lst;
      var odds = size / (double) lst.Count;
      var sample = new List<T>();
      var source = lst.ToList();
      var idx = 0;
      while (true)
      {
        if (Runtime.Random <= odds)
        {
          var modded = idx % source.Count;
          var val = source[modded];
          sample.Add(val);
          source.RemoveAt(modded);
          if (sample.Count == size) return sample;
        }
        idx++;
      }      
    }

    public static ArrayList ToArrayList<T>(this IEnumerable<T> source) 
    {
      var al = new ArrayList();
      foreach (var e in source) { al.add(e); }
      return al;
    }

    public static void ForEach2<T>(this IEnumerable<T> source, Action<T> action) 
    {
      foreach (var e in source) { action(e); }
    }

    public static void ForEach2<T>(this IEnumerable<T> source, Action<T, int> action) 
    {
      var idx = 0;
      foreach (var e in source) { action(e, idx++); }
    }

    public static IEnumerable<T> ToEnumerable<T>(this Enumeration source) 
    {
      var lst = new List<T>();
      while (source.hasMoreElements()) {
        lst.Add((T) source.nextElement());
      }
      return lst;
    }
  }
}