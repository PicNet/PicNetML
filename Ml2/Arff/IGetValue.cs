namespace Ml2.Arff
{
  /// <summary>
  /// Reflection is very slow, this is a simple way of avoiding reflection costs.
  /// </summary>
  public interface IGetValue {
    object GetValue(string property);
  }
}