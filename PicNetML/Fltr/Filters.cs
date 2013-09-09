namespace PicNetML.Fltr
{
  public class Filters
  {
    private readonly Runtime rt;
    public Filters(Runtime rt) { this.rt = rt; }

    public FiltersSupervisedAttribute SupervisedAttribute { get { return new FiltersSupervisedAttribute(rt); }}
    public FiltersSupervisedInstance SupervisedInstance { get { return new FiltersSupervisedInstance(rt); }}
    public FiltersUnsupervisedAttribute UnsupervisedAttribute { get { return new FiltersUnsupervisedAttribute(rt); }}
    public FiltersUnsupervisedInstance UnsupervisedInstance { get { return new FiltersUnsupervisedInstance(rt); }}
  }
}