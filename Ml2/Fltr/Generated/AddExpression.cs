using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that creates a new attribute by applying a
  /// mathematical expression to existing attributes. The expression can contain attribute
  /// references and numeric constants. Supported operators are :<br/>+, -, *, /,
  /// ^, log, abs, cos, exp, sqrt, floor, ceil, rint, tan, sin, (,
  /// )<br/>Attributes are specified by prefixing with 'a', eg. a7 is attribute number 7
  /// (starting from 1).<br/>Example expression :
  /// a1^2*a5/log(a7*4.0).<br/><br/>Options:<br/><br/>-E &lt;expression&gt; = 	Specify the expression to apply. Eg
  /// a1^2*a5/log(a7*4.0).<br/>	Supported opperators: ,+, -, *, /, ^, log, abs, cos,
  /// <br/>	exp, sqrt, floor, ceil, rint, tan, sin, (, )<br/>	(default:
  /// a1^2)<br/>-N &lt;name&gt; = 	Specify the name for the new attribute. (default is
  /// the expression provided with -E)<br/>-D = 	Debug. Names attribute with the
  /// postfix parse of the expression.
  /// </summary>
  public class AddExpression : BaseFilter<weka.filters.unsupervised.attribute.AddExpression>
  {
    public AddExpression(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.AddExpression()) {
      
    }

    /// <summary>
    /// Set the name of the new attribute.
    /// </summary>    
    public AddExpression Name (string name) {
      Impl.setName(name);
      return this;
    }

    /// <summary>
    /// Set the math expression to apply. Eg. a1^2*a5/log(a7*4.0)
    /// </summary>    
    public AddExpression Expression (string expr) {
      Impl.setExpression(expr);
      return this;
    }

    /// <summary>
    /// Set debug mode. If true then the new attribute will be named with the
    /// postfix parse of the supplied expression.
    /// </summary>    
    public AddExpression Debug (bool d) {
      Impl.setDebug(d);
      return this;
    }

        
        
  }
}