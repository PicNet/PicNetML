// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersBayesNet
  {
    private readonly Runtime rt;    
    public ClassifiersBayesNet(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// Builds a description of a Bayes Net classifier stored in XML BIF 0.3
    /// format.<br/><br/>For more details on XML BIF see:<br/><br/>Fabio Cozman, Marek
    /// Druzdzel, Daniel Garcia (1998). XML BIF version 0.3. URL
    /// http://www-2.cs.cmu.edu/~fgcozman/Research/InterchangeFormat/.<br/><br/>Options:<br/><br/>-D
    /// = 	Do not use ADTree data structure<br/><br/>-B &lt;BIF file&gt; = 	BIF
    /// file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
    /// </summary>
    public BIFReader BIFReader { get {
      return new BIFReader(rt); 
    } }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-B = 	Generate network (instead of
    /// instances)<br/><br/>-N &lt;integer&gt; = 	Nr of nodes<br/><br/>-A &lt;integer&gt; =
    /// 	Nr of arcs<br/><br/>-M &lt;integer&gt; = 	Nr of instances<br/><br/>-C
    /// &lt;integer&gt; = 	Cardinality of the variables<br/><br/>-S &lt;integer&gt; =
    /// 	Seed for random number generator<br/><br/>-F &lt;file&gt; = 	The BIF file to
    /// obtain the structure from.<br/>
    /// </summary>
    public BayesNetGenerator BayesNetGenerator { get {
      return new BayesNetGenerator(rt); 
    } }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
    /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
    /// </summary>
    public EditableBayesNet EditableBayesNet { get {
      return new EditableBayesNet(rt); 
    } }

    
  }
}