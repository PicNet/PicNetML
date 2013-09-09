using Ml2.Asstn;
using Ml2.AttrSel;
using Ml2.Clss;
using Ml2.Clstr;
using Ml2.Fltr;

namespace Ml2
{
  public partial class Runtime
  {                  
    public AttributeSelections AttributeSelections { get { return new AttributeSelections(this); } }
    public Clusterers Clusterers { get { return new Clusterers(this); } }
    public Filters Filters { get { return new Filters(this); } }
    public Associations Associations { get { return new Associations(this); } }
    public Classifiers Classifiers { get { return new Classifiers(this); } }       
 }
}