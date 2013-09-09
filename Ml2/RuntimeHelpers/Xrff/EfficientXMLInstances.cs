using org.w3c.dom;
using weka.core;
using weka.core.xml;

namespace Ml2.RuntimeHelpers.Xrff
{
  public class EfficientXMLInstances : XMLInstances
  {
    protected override void addInstance(Element parent, Instance inst) {      
      var node = m_Document.createElement(TAG_INSTANCE);
      parent.appendChild(node);

      var sparse = inst is SparseInstance;
      if (sparse) { node.setAttribute(ATT_TYPE, VAL_SPARSE); }
      if (inst.weight() != 1.0) { node.setAttribute(ATT_WEIGHT, Utils.doubleToString(inst.weight(), m_Precision)); }
      for (var i = 0; i < inst.numValues(); i++) {
        var index = inst.index(i);

        var value = m_Document.createElement(TAG_VALUE);        
        if (inst.isMissing(index)) {
          if (sparse) continue;
          value.setAttribute(ATT_MISSING, VAL_YES);
        } else {
          if (inst.attribute(index).isRelationValued()) {
            var child = m_Document.createElement(TAG_INSTANCES);
            value.appendChild(child);
            for (var n = 0; n < inst.relationalValue(i).numInstances(); n++) {
              addInstance(child, inst.relationalValue(i).instance(n));
            }
          } else {
            value.appendChild(inst.attribute(index).type() == weka.core.Attribute.NUMERIC ? 
                                                                                            m_Document.createTextNode(Utils.doubleToString(inst.value(index), m_Precision)) : 
                                                                                                                                                                              m_Document.createTextNode(validContent(inst.stringValue(index))));
          }
        }
        node.appendChild(value);
        if (sparse) { value.setAttribute(ATT_INDEX, "" + (index + 1)); }
      }
    }
  }
}