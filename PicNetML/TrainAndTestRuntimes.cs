using System;

namespace PicNetML
{
  [Serializable] public class TrainAndTestRuntimes : Tuple<Runtime, Runtime>
  {
    public TrainAndTestRuntimes(Runtime training, Runtime testing) : base(training, testing) {}

    public Runtime Training { get { return Item1; } }
    public Runtime Testing { get { return Item2; } }
  }
}