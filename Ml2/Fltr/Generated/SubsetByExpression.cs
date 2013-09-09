using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filters instances according to a user-specified
  /// expression.<br/><br/>Grammar:<br/><br/>boolexpr_list ::= boolexpr_list boolexpr_part |
  /// boolexpr_part;<br/><br/>boolexpr_part ::= boolexpr:e {: parser.setResult(e); :}
  /// ;<br/><br/>boolexpr ::= BOOLEAN <br/> | true<br/> | false<br/> | expr < expr<br/> |
  /// expr <= expr<br/> | expr > expr<br/> | expr >= expr<br/> | expr =
  /// expr<br/> | ( boolexpr )<br/> | not boolexpr<br/> | boolexpr and boolexpr<br/> |
  /// boolexpr or boolexpr<br/> | ATTRIBUTE is STRING<br/> ;<br/><br/>expr ::=
  /// NUMBER<br/> | ATTRIBUTE<br/> | ( expr )<br/> | opexpr<br/> | funcexpr<br/>
  /// ;<br/><br/>opexpr ::= expr + expr<br/> | expr - expr<br/> | expr * expr<br/> |
  /// expr / expr<br/> ;<br/><br/>funcexpr ::= abs ( expr )<br/> | sqrt ( expr
  /// )<br/> | log ( expr )<br/> | exp ( expr )<br/> | sin ( expr )<br/> | cos (
  /// expr )<br/> | tan ( expr )<br/> | rint ( expr )<br/> | floor ( expr )<br/> |
  /// pow ( expr for base , expr for exponent )<br/> | ceil ( expr )<br/>
  /// ;<br/><br/>Notes:<br/>- NUMBER<br/> any integer or floating point number <br/>
  /// (but not in scientific notation!)<br/>- STRING<br/> any string surrounded by
  /// single quotes; <br/> the string may not contain a single quote though.<br/>-
  /// ATTRIBUTE<br/> the following placeholders are recognized for <br/>
  /// attribute values:<br/> - CLASS for the class value in case a class attribute is
  /// set.<br/> - ATTxyz with xyz a number from 1 to # of attributes in the<br/>
  /// dataset, representing the value of indexed
  /// attribute.<br/><br/>Examples:<br/>- extracting only mammals and birds from the 'zoo' UCI dataset:<br/> (CLASS
  /// is 'mammal') or (CLASS is 'bird')<br/>- extracting only animals with at
  /// least 2 legs from the 'zoo' UCI dataset:<br/> (ATT14 >= 2)<br/>- extracting
  /// only instances with non-missing 'wage-increase-second-year'<br/> from the
  /// 'labor' UCI dataset:<br/> not
  /// ismissing(ATT3)<br/><br/><br/>Options:<br/><br/>-E &lt;expr&gt; = 	The expression to use for filtering<br/>	(default:
  /// true).<br/>-F = 	Apply the filter to instances that arrive after the
  /// first<br/>	(training) batch. The default is to not apply the filter (i.e.<br/>	always
  /// return the instance)
  /// </summary>
  public class SubsetByExpression : BaseFilter<weka.filters.unsupervised.instance.SubsetByExpression>
  {
    public SubsetByExpression(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.SubsetByExpression()) {
      
    }

    /// <summary>
    /// The expression to used for filtering the dataset.
    /// </summary>    
    public SubsetByExpression Expression (string value) {
      Impl.setExpression(value);
      return this;
    }

    /// <summary>
    /// Whether to apply the filtering process to instances that are input after
    /// the first (training) batch. The default is false so that, when used in a
    /// FilteredClassifier, test instances do not potentially get 'consumed' by the
    /// filter an a prediction is always made.
    /// </summary>    
    public SubsetByExpression FilterAfterFirstBatch (bool b) {
      Impl.setFilterAfterFirstBatch(b);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public SubsetByExpression Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}