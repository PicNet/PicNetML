using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// This filter is used for renaming attribute names.<br/>Regular expressions
  /// can be used in the matching and replacing.<br/>See Javadoc of
  /// java.util.regex.Pattern class for more
  /// information:<br/>http://java.sun.com/javase/6/docs/api/java/util/regex/Pattern.html<br/><br/>Options:<br/><br/>-find
  /// &lt;regexp&gt; = 	The regular expression that the attribute names must
  /// match.<br/>	(default: ([\s\S]+))<br/>-replace &lt;string&gt; = 	The string to replace
  /// the regular expression of matching attributes with.<br/>	Cannot be used in
  /// conjunction with '-remove'.<br/>	(default: $0)<br/>-remove = 	In case the
  /// matching string needs to be removed instead of replaced.<br/>	Cannot be
  /// used in conjunction with '-replace <string>'.<br/>	(default: off)<br/>-all =
  /// 	Replaces all occurrences instead of just the first.<br/>	(default: only
  /// first occurrence)<br/>-R &lt;range&gt; = 	The attribute range to work
  /// on.<br/>This is a comma separated list of attribute indices, with "first" and
  /// "last" valid values.<br/>	Specify an inclusive range with "-".<br/>	E.g:
  /// "first-3,5,6-10,last".<br/>	(default: first-last)<br/>-V = 	Inverts the attribute
  /// selection range.<br/>	(default: off)
  /// </summary>
  public class RenameAttribute : BaseFilter<weka.filters.unsupervised.attribute.RenameAttribute>
  {
    public RenameAttribute(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RenameAttribute()) {
      
    }

    /// <summary>
    /// The regular expression that the attribute names must match.
    /// </summary>    
    public RenameAttribute Find (string value) {
      Impl.setFind(value);
      return this;
    }

    /// <summary>
    /// The regular expression to use for replacing the matching attribute names
    /// with.
    /// </summary>    
    public RenameAttribute Replace (string value) {
      Impl.setReplace(value);
      return this;
    }

    /// <summary>
    /// If set to true, then all occurrences of the match will be replaced;
    /// otherwise only the first.
    /// </summary>    
    public RenameAttribute ReplaceAll (bool value) {
      Impl.setReplaceAll(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; specify an
    /// inclusive range with "-"; eg: "first-3,5,6-10,last".
    /// </summary>    
    public RenameAttribute AttributeIndices (string value) {
      Impl.setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// If set to true, the selection will be inverted; eg: the attribute indices
    /// '2-4' then mean everything apart from '2-4'.
    /// </summary>    
    public RenameAttribute InvertSelection (bool value) {
      Impl.setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RenameAttribute Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}