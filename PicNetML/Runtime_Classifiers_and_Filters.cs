using PicNetML.Asstn;
using PicNetML.AttrSel;
using PicNetML.Clss;
using PicNetML.Clstr;
using PicNetML.Fltr;

namespace PicNetML
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