using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace PicNetML.Arff
{
  internal class CsvLoader<T> : ILoader<T> where T : new()
  {
    public IEnumerable<T> Load(string file, Func<string, string> preprocessor = null) {      
      if(String.IsNullOrEmpty(file)) throw new ArgumentNullException("file");
      if(!File.Exists(file)) throw new ArgumentException("file");

      var lines = File.ReadAllLines(file);
      return LoadLines(lines, preprocessor);
    }

    public IEnumerable<T> LoadLines(IEnumerable<string> lines, Func<string, string> preprocessor = null)
    {
      var contents = String.Join("\n", preprocessor == null ? lines : lines.Select(preprocessor));
      using (var sr = new StringReader(contents)) { return ReadFileImpl(sr); }
    }

    private static T[] ReadFileImpl(TextReader tr)
    {
      var targets = Helpers.GetProps(typeof(T));
      var records = new List<T>();
      using (var csv = new CsvReader(tr, true))
      {
        var fieldCount = csv.FieldCount;
        while (csv.ReadNextRecord())
        {
          var record = new T();
          for (var i = 0; i < Math.Min(fieldCount, targets.Length); i++)
          {
            var field = targets[i];
            try { field.SetValue(record, CovertToType(csv[i], field.PropertyType)); }
            catch 
            {
              Console.WriteLine("Could not parse row " + csv.CurrentRecordIndex + 
                  " field: " + i + " = '" + csv[i] + "'");
              throw;
            }
          }
          records.Add(record);
        }
      }
      return records.ToArray();
    }

    private static object CovertToType(string val, Type type) {
      if (String.IsNullOrEmpty(val)) return null;
      type = ArffUtils.GetNonNullableType(type);
      if (type.IsEnum) return ConvertToEnum(val, type);
      return Convert.ChangeType(val, type);
    }

    private static object ConvertToEnum(string val, Type type) {
      int intv;
      if (Int32.TryParse(val, out intv)) { return Enum.ToObject(type, intv); }

      val = val.ToLower();
      var names = Enum.GetNames(type).Select(n => n.ToLower()).ToArray();
      var values = Enum.GetValues(type).Cast<object>().ToArray();
      
      foreach (var value in values) { if (value.ToString().ToLower() == val) return value; }
      for (int i = 0; i < names.Length; i++) { if (val == names[i]) return values[i]; }
      if (val.Length == 1)
      {
        char c = val[0];
        for (int i = 0; i < names.Length; i++) { if (c == names[i][0]) return values[i]; }
      }
      throw new ArgumentException(val + " could not be converted to " + type.Name);
    }    
  }
}