using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A Classifier that uses backpropagation to classify instances.<br/>This
  /// network can be built by hand, created by an algorithm or both. The network
  /// can also be monitored and modified during training time. The nodes in this
  /// network are all sigmoid (except for when the class is numeric in which case
  /// the the output nodes become unthresholded linear
  /// units).<br/><br/>Options:<br/><br/>-L &lt;learning rate&gt; = 	Learning Rate for the backpropagation
  /// algorithm.<br/>	(Value should be between 0 - 1, Default = 0.3).<br/>-M
  /// &lt;momentum&gt; = 	Momentum Rate for the backpropagation algorithm.<br/>	(Value
  /// should be between 0 - 1, Default = 0.2).<br/>-N &lt;number of epochs&gt; =
  /// 	Number of epochs to train through.<br/>	(Default = 500).<br/>-V
  /// &lt;percentage size of validation set&gt; = 	Percentage size of validation set to
  /// use to terminate<br/>	training (if this is non zero it can pre-empt num of
  /// epochs.<br/>	(Value should be between 0 - 100, Default = 0).<br/>-S
  /// &lt;seed&gt; = 	The value used to seed the random number generator<br/>	(Value
  /// should be >= 0 and and a long, Default = 0).<br/>-E &lt;threshold for number of
  /// consequetive errors&gt; = 	The consequetive number of errors allowed for
  /// validation<br/>	testing before the netwrok terminates.<br/>	(Value should be
  /// > 0, Default = 20).<br/>-G = 	GUI will be opened.<br/>	(Use this to bring
  /// up a GUI).<br/>-A = 	Autocreation of the network connections will NOT be
  /// done.<br/>	(This will be ignored if -G is NOT set)<br/>-B = 	A NominalToBinary
  /// filter will NOT automatically be used.<br/>	(Set this to not use a
  /// NominalToBinary filter).<br/>-H &lt;comma seperated numbers for nodes on each
  /// layer&gt; = 	The hidden layers to be created for the network.<br/>	(Value
  /// should be a list of comma separated Natural <br/>	numbers or the letters 'a' =
  /// (attribs + classes) / 2, <br/>	'i' = attribs, 'o' = classes, 't' = attribs
  /// .+ classes)<br/>	for wildcard values, Default = a).<br/>-C = 	Normalizing a
  /// numeric class will NOT be done.<br/>	(Set this to not normalize the class
  /// if it's numeric).<br/>-I = 	Normalizing the attributes will NOT be
  /// done.<br/>	(Set this to not normalize the attributes).<br/>-R = 	Reseting the
  /// network will NOT be allowed.<br/>	(Set this to not allow the network to
  /// reset).<br/>-D = 	Learning rate decay will occur.<br/>	(Set this to cause the
  /// learning rate to decay).
  /// </summary>
  public class MultilayerPerceptron : BaseClassifier<weka.classifiers.functions.MultilayerPerceptron>
  {
    public MultilayerPerceptron(Runtime rt) : base(rt, new weka.classifiers.functions.MultilayerPerceptron()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The amount the weights are updated.
    /// </summary>    
    public MultilayerPerceptron LearningRate (double l) {
      Impl.setLearningRate(l);
      return this;
    }

    /// <summary>
    /// Momentum applied to the weights during updating.
    /// </summary>    
    public MultilayerPerceptron Momentum (double m) {
      Impl.setMomentum(m);
      return this;
    }

    /// <summary>
    /// Adds and connects up hidden layers in the network.
    /// </summary>    
    public MultilayerPerceptron AutoBuild (bool a) {
      Impl.setAutoBuild(a);
      return this;
    }

    /// <summary>
    /// This will allow the network to reset with a lower learning rate. If the
    /// network diverges from the answer this will automatically reset the network
    /// with a lower learning rate and begin training again. This option is only
    /// available if the gui is not set. Note that if the network diverges but isn't
    /// allowed to reset it will fail the training process and return an error
    /// message.
    /// </summary>    
    public MultilayerPerceptron Reset (bool r) {
      Impl.setReset(r);
      return this;
    }

    /// <summary>
    /// The number of epochs to train through. If the validation set is non-zero
    /// then it can terminate the network early
    /// </summary>    
    public MultilayerPerceptron TrainingTime (int n) {
      Impl.setTrainingTime(n);
      return this;
    }

    /// <summary>
    /// The percentage size of the validation set.(The training will continue
    /// until it is observed that the error on the validation set has been
    /// consistently getting worse, or if the training time is reached). If This is set to
    /// zero no validation set will be used and instead the network will train for the
    /// specified number of epochs.
    /// </summary>    
    public MultilayerPerceptron ValidationSetSize (int a) {
      Impl.setValidationSetSize(a);
      return this;
    }

    /// <summary>
    /// Used to terminate validation testing.The value here dictates how many
    /// times in a row the validation set error can get worse before training is
    /// terminated.
    /// </summary>    
    public MultilayerPerceptron ValidationThreshold (int t) {
      Impl.setValidationThreshold(t);
      return this;
    }

    /// <summary>
    /// This defines the hidden layers of the neural network. This is a list of
    /// positive whole numbers. 1 for each hidden layer. Comma seperated. To have no
    /// hidden layers put a single 0 here. This will only be used if autobuild is
    /// set. There are also wildcard values 'a' = (attribs + classes) / 2, 'i' =
    /// attribs, 'o' = classes , 't' = attribs + classes.
    /// </summary>    
    public MultilayerPerceptron HiddenLayers (string h) {
      Impl.setHiddenLayers(h);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MultilayerPerceptron GUI (bool a) {
      Impl.setGUI(a);
      return this;
    }

    /// <summary>
    /// This will preprocess the instances with the filter. This could help
    /// improve performance if there are nominal attributes in the data.
    /// </summary>    
    public MultilayerPerceptron NominalToBinaryFilter (bool f) {
      Impl.setNominalToBinaryFilter(f);
      return this;
    }

    /// <summary>
    /// This will normalize the class if it's numeric. This could help improve
    /// performance of the network, It normalizes the class to be between -1 and 1.
    /// Note that this is only internally, the output will be scaled back to the
    /// original range.
    /// </summary>    
    public MultilayerPerceptron NormalizeNumericClass (bool c) {
      Impl.setNormalizeNumericClass(c);
      return this;
    }

    /// <summary>
    /// This will normalize the attributes. This could help improve performance
    /// of the network. This is not reliant on the class being numeric. This will
    /// also normalize nominal attributes as well (after they have been run through
    /// the nominal to binary filter if that is in use) so that the nominal values
    /// are between -1 and 1
    /// </summary>    
    public MultilayerPerceptron NormalizeAttributes (bool a) {
      Impl.setNormalizeAttributes(a);
      return this;
    }

    /// <summary>
    /// This will cause the learning rate to decrease. This will divide the
    /// starting learning rate by the epoch number, to determine what the current
    /// learning rate should be. This may help to stop the network from diverging from
    /// the target output, as well as improve general performance. Note that the
    /// decaying learning rate will not be shown in the gui, only the original learning
    /// rate. If the learning rate is changed in the gui, this is treated as the
    /// starting learning rate.
    /// </summary>    
    public MultilayerPerceptron Decay (bool d) {
      Impl.setDecay(d);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultilayerPerceptron Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}