using System;
using System.Collections.Generic;

namespace PicNetML.Arff
{
  internal interface ILoader<T> where T : new()
  {
    IEnumerable<T> Load(string file, Func<string, string> preprocessor = null);
    IEnumerable<T> LoadLines(IEnumerable<string> lines, Func<string, string> preprocessor = null);
  }
}