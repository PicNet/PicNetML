namespace PicNetML.Clss
{
  public class Classifiers
  {
    private readonly Runtime rt;

    public Classifiers(Runtime rt) { this.rt = rt; }

    public ClassifiersBayes Bayes { get { return new ClassifiersBayes(rt); } }
    public ClassifiersBayesNet BayesNet { get { return new ClassifiersBayesNet(rt); } }
    public ClassifiersFunctions Functions { get { return new ClassifiersFunctions(rt); } }
    public ClassifiersLazy Lazy { get { return new ClassifiersLazy(rt); } }
    public ClassifiersMeta Meta { get { return new ClassifiersMeta(rt); } }
    public ClassifiersMisc Misc { get { return new ClassifiersMisc(rt); } }
    public ClassifiersRules Rules { get { return new ClassifiersRules(rt); } }
    public ClassifiersTrees Trees { get { return new ClassifiersTrees(rt); } }
    public ClassifiersTreesLmt TreesLmt { get { return new ClassifiersTreesLmt(rt); } }
  }
}