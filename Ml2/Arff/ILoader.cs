using System;
using System.Collections.Generic;

namespace Ml2.Arff
{
  internal interface ILoader<T> where T : new()
  {
    IEnumerable<T> Load(string file, Func<string, string> preprocessor = null);
    IEnumerable<T> LoadLines(IEnumerable<string> lines, Func<string, string> preprocessor = null);
  }
}