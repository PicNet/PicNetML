using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Modify numeric attributes according to a given expression
  /// <br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily
  /// before the filter is<br/>	applied to the data.<br/>	(default: no)<br/>-E
  /// &lt;expression&gt; = 	Specify the expression to apply. Eg.
  /// pow(A,6)/(MEAN+MAX)<br/>	Supported operators are +, -, *, /, pow, log,<br/>	abs, cos, exp,
  /// sqrt, tan, sin, ceil, floor, rint, (, ), <br/>	MEAN, MAX, MIN, SD, COUNT,
  /// SUM, SUMSQUARED, ifelse. The 'A'<br/>	letter refers to the value of the
  /// attribute being processed.<br/>	Other attribute values (numeric only) can be
  /// accessed through<br/>	the variables A1, A2, A3, ...<br/>-R
  /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to ignore. First and last are
  /// valid<br/>	indexes. (default none)<br/>-V = 	Invert matching sense (i.e. only
  /// modify specified columns)
  /// </summary>
  public class MathExpression : BaseFilter<weka.filters.unsupervised.attribute.MathExpression>
  {
    public MathExpression(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.MathExpression()) {
      
    }

    /// <summary>
    /// Determines whether action is to select or unselect. If set to true, only
    /// the specified attributes will be modified; If set to false, specified
    /// attributes will not be modified.
    /// </summary>    
    public MathExpression InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Specify the expression to apply. The 'A' letterrefers to the value of the
    /// attribute being processed. MIN,MAX,MEAN,SDrefer respectively to minimum,
    /// maximum, mean andstandard deviation of the attribute being processed. Other
    /// attribute values (numeric only) can be accessed through the variables A1,
    /// A2, A3, ... 	Supported operators are +, -, *, /, pow, log,abs, cos, exp,
    /// sqrt, tan, sin, ceil, floor, rint, (, ),A,MEAN, MAX, MIN, SD, COUNT, SUM,
    /// SUMSQUARED, ifelse 	Eg. pow(A,6)/(MEAN+MAX)*ifelse(A<0,0,sqrt(A))+ifelse(![A>9
    /// && A<15])
    /// </summary>    
    public MathExpression Expression (string expr) {
      Impl.setExpression(expr);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MathExpression IgnoreRange (string rangeList) {
      Impl.setIgnoreRange(rangeList);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public MathExpression IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}