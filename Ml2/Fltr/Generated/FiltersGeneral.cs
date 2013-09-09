// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class FiltersGeneral
  {
    private readonly Runtime rt;    
    public FiltersGeneral(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that passes all instances through unmodified.
    /// Primarily for testing purposes.
    /// </summary>
    public AllFilter AllFilter { get {
      return new AllFilter(rt); 
    } }

    /// <summary>
    /// Applies several filters successively. In case all supplied filters are
    /// StreamableFilters, it will act as a streamable one,
    /// too.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F &lt;classname
    /// [options]&gt; = 	A filter to apply (can be specified multiple times).
    /// </summary>
    public MultiFilter MultiFilter { get {
      return new MultiFilter(rt); 
    } }

    
  }
}