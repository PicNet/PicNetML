namespace PicNetML.RuntimeHelpers
{
  public interface IAttributesRemover {
    void KeepAttributes(params object[] attributes);
    void RemoveAttributes(params object[] attributes);
  }
}