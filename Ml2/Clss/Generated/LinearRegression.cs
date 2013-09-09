using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for using linear regression for prediction. Uses the Akaike
  /// criterion for model selection, and is able to deal with weighted
  /// instances.<br/><br/>Options:<br/><br/>-D = 	Produce debugging output.<br/>	(default no
  /// debugging output)<br/>-S &lt;number of selection method&gt; = 	Set the attribute
  /// selection method to use. 1 = None, 2 = Greedy.<br/>	(default 0 = M5'
  /// method)<br/>-C = 	Do not try to eliminate colinear attributes.<br/><br/>-R
  /// &lt;double&gt; = 	Set ridge parameter (default 1.0e-8).<br/><br/>-minimal =
  /// 	Conserve memory, don't keep dataset header and means/stdevs.<br/>	Model cannot
  /// be printed out if this option is enabled.	(default: keep data)
  /// </summary>
  public class LinearRegression : BaseClassifier<weka.classifiers.functions.LinearRegression>
  {
    public LinearRegression(Runtime rt) : base(rt, new weka.classifiers.functions.LinearRegression()) {
      
    }

    /// <summary>
    /// Set the method used to select attributes for use in the linear
    /// regression. Available methods are: no attribute selection, attribute selection using
    /// M5's method (step through the attributes removing the one with the smallest
    /// standardised coefficient until no improvement is observed in the estimate
    /// of the error given by the Akaike information criterion), and a greedy
    /// selection using the Akaike information metric.
    /// </summary>    
    public LinearRegression AttributeSelectionMethod (EAttributeSelectionMethod method) {
      Impl.setAttributeSelectionMethod(new weka.core.SelectedTag((int) method, weka.classifiers.functions.LinearRegression.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// The value of the Ridge parameter.
    /// </summary>    
    public LinearRegression Ridge (double newRidge) {
      Impl.setRidge(newRidge);
      return this;
    }

    /// <summary>
    /// Eliminate colinear attributes.
    /// </summary>    
    public LinearRegression EliminateColinearAttributes (bool newEliminateColinearAttributes) {
      Impl.setEliminateColinearAttributes(newEliminateColinearAttributes);
      return this;
    }

    /// <summary>
    /// If enabled, dataset header, means and stdevs get discarded to conserve
    /// memory; also, the model cannot be printed out.
    /// </summary>    
    public LinearRegression Minimal (bool value) {
      Impl.setMinimal(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LinearRegression Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EAttributeSelectionMethod {
      No_attribute_selection = 1,
      M5_method = 0,
      Greedy_method = 2
    }

        
  }
}