using System;
using NUnit.Framework;

namespace PicNetML.Tests {
  [TestFixture] public class HelpersTests {
    [Test] public void test_range_with_positive_step_functions() {
      var actual = Helpers.Range(0.1m, 0.3m, 0.1m);
      CollectionAssert.AreEqual(new [] {0.1m, 0.2m, 0.3m}, actual, "Actual: " + String.Join(", ", actual));
    }

    [Test] public void test_range_with_negative_step_functions() {
      var actual = Helpers.Range(0.3m, 0.1m, -0.1m);
      CollectionAssert.AreEqual(new [] {0.3m, 0.2m, 0.1m}, actual, "Actual: " + String.Join(", ", actual));
    }

    [Test] public void test_range_arg_valudation() {
      Assert.Throws(typeof(ArgumentOutOfRangeException), () => Helpers.Range(0.3m, 0.1m, 0.1m));
      Assert.Throws(typeof(ArgumentOutOfRangeException), () => Helpers.Range(0.3m, 0.3m, 0.1m));
      Assert.Throws(typeof(ArgumentOutOfRangeException), () => Helpers.Range(0.1m, 0.3m, -0.1m));
      Assert.Throws(typeof(ArgumentOutOfRangeException), () => Helpers.Range(0.3m, 0.3m, -0.1m));
    }
  }
}