using weka.associations;

namespace PicNetML.Asstn
{
  public class BaseAssociation<I> where I : AbstractAssociator
  {
    protected readonly Runtime rt;
    internal I Impl { get; private set; }

    public BaseAssociation(Runtime rt, I impl)
    {
      this.rt = rt;
      Impl = impl;

      InternalHelpers.SetSeedOnInstance(impl);
    }

    public string GetRules()
    {
      Impl.buildAssociations(rt.Impl);
      return Impl.ToString();
    }
  }
}