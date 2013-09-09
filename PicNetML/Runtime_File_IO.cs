using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PicNetML.Arff;
using PicNetML.RuntimeHelpers.Xrff;
using weka.core.converters;

namespace PicNetML
{
  public partial class Runtime
  {                  
    public Runtime SaveToArffFile(string file)
    {
      if (File.Exists(file)) File.Delete(file);
      var saver = new ArffSaver();
      saver.setInstances(Impl);
      saver.setFile(new java.io.File(file));
      saver.writeBatch();
      return this;
    }

    public Runtime SaveToXrffFile(string file) { 
      if (File.Exists(file)) File.Delete(file);
      
      // IKVM Hacks: Required to load the corrrect assembly.
      new com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl();
      new com.sun.org.apache.xpath.@internal.jaxp.XPathFactoryImpl().newXPath();

      var saver = new EfficientXRFFSaver();
      saver.setCompressOutput(file.EndsWith(".gz"));
      saver.setInstances(Impl);
      saver.setFile(new java.io.File(file));
      saver.writeBatch();
      return this;
    }

    // weka.core.converters.CSVSaver throws exception
    public void SaveToCsvFile(string filename) {
      var headings = String.Join(",", EnumerateAttributes.Select(a => a.Name));
      var idxs = Enumerable.Range(0, NumAttributes);
      var lines = this.Select(i => String.Join(",", idxs.Select(i.StringValue))).ToList();
      lines.Insert(0, headings);
      File.WriteAllLines(filename, lines);
    }

    public static void SaveToCsv(IEnumerable<IGetValue> rows, string filename) {
      var rowsarr = rows.ToArray();
      var headings = GetObjectHeadings(rowsarr[0]);
      var header = String.Join(",", headings);
      var lines = rowsarr.Select(r => String.Join(",", headings.Select(r.GetValue))).ToList();
      lines.Insert(0, header);
      File.WriteAllLines(filename, lines);
    }

    private static List<string> GetObjectHeadings(object o) {
      var props = Helpers.GetProps(o.GetType()).Select(p => p.Name).ToList();
      if (o is ExtendableObjBase) 
        props = props.
          Concat(((ExtendableObjBase)o).Properties.Select(p => p.Name)).
          ToList();
      return props;
    }
  }
}