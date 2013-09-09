using weka.core.converters;

namespace Ml2.RuntimeHelpers.Xrff
{
  public class EfficientXRFFSaver : XRFFSaver
  {
    public override void resetOptions() {
      base.resetOptions();
      setFileExtension(getCompressOutput() ? XRFFLoader.FILE_EXTENSION_COMPRESSED : XRFFLoader.FILE_EXTENSION);

      try { m_XMLInstances = new EfficientXMLInstances(); } 
      catch { m_XMLInstances = null; }
    }
  }
}