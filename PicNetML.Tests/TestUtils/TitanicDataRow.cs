using PicNetML.Arff;

namespace PicNetML.Tests.TestUtils {
  public class TitanicDataRow {
    [IgnoreFeature] public string passengerid { get; set; }
    [Nominal("0,1")] public string survived { get; set; }
    [Nominal("1,2,3")] public string pclass { get; set; }
    [IgnoreFeature] public string name { get; set; }
    [Nominal("male,female")] public string sex { get; set; }
    [IgnoreFeature] public double age { get; set; }
    [IgnoreFeature] public int sibsp { get; set; }
    [IgnoreFeature] public int parch { get; set; }
    [IgnoreFeature] public string ticket { get; set; }
    [IgnoreFeature] public string fare { get; set; }
    [IgnoreFeature] public string cabin { get; set; }
    [Nominal("C,Q,S")] public string embarked { get; set; }
  }

  public class TitanicDataRow2 {
    [IgnoreFeature] public string passengerid { get; set; }
    [Nominal("0,1")] public string survived { get; set; }
    [Nominal("1,2,3")] public string pclass { get; set; }
    public string name { get; set; }
    [Nominal("male,female")] public string sex { get; set; }
    public double age { get; set; }
    public int sibsp { get; set; }
    public int parch { get; set; }
    public string ticket { get; set; }
    public string fare { get; set; }
    public string cabin { get; set; }
    [Nominal("C,Q,S")] public string embarked { get; set; }
  }
}