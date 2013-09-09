// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class UnsupervisedInstanceFilters
  {
    private readonly Runtime rt;    
    public UnsupervisedInstanceFilters(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that converts all incoming instances into sparse
    /// format.<br/><br/>Options:<br/><br/>-M = 	Treat missing values as zero.<br/>-F =
    /// 	Add a dummy first value for nominal attributes.
    /// </summary>
    public NonSparseToSparse NonSparseToSparse() { return new NonSparseToSparse(rt); }

    /// <summary>
    /// Randomly shuffles the order of instances passed through it. The random
    /// number generator is reset with the seed value whenever a new set of instances
    /// is passed in.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specify the
    /// random number seed (default 42)
    /// </summary>
    public Randomize Randomize() { return new Randomize(rt); }

    /// <summary>
    /// This filter takes a dataset and outputs a specified fold for cross
    /// validation. If you want the folds to be stratified use the supervised
    /// version.<br/><br/>Options:<br/><br/>-V = 	Specifies if inverse of selection is to be
    /// output.<br/><br/>-N &lt;number of folds&gt; = 	Specifies number of folds
    /// dataset is split into. <br/>	(default 10)<br/><br/>-F &lt;fold&gt; =
    /// 	Specifies which fold is selected. (default 1)<br/><br/>-S &lt;seed&gt; = 	Specifies
    /// random number seed. (default 0, no randomizing)<br/>
    /// </summary>
    public RemoveFolds RemoveFolds() { return new RemoveFolds(rt); }

    /// <summary>
    /// Determines which values (frequent or infrequent ones) of an (nominal)
    /// attribute are retained and filters the instances accordingly. In case of
    /// values with the same frequency, they are kept in the way they appear in the
    /// original instances object. E.g. if you have the values "1,2,3,4" with the
    /// frequencies "10,5,5,3" and you chose to keep the 2 most common values, the
    /// values "1,2" would be returned, since the value "2" comes before "3", even
    /// though they have the same frequency.<br/><br/>Options:<br/><br/>-C &lt;num&gt; =
    /// 	Choose attribute to be used for selection.<br/>-N &lt;num&gt; = 	Number
    /// of values to retain for the sepcified attribute, <br/>	i.e. the ones with
    /// the most instances (default 2).<br/>-L = 	Instead of values with the most
    /// instances the ones with the <br/>	least are retained.<br/><br/>-H = 	When
    /// selecting on nominal attributes, removes header<br/>	references to excluded
    /// values.<br/>-V = 	Invert matching sense.
    /// </summary>
    public RemoveFrequentValues RemoveFrequentValues() { return new RemoveFrequentValues(rt); }

    /// <summary>
    /// A filter that removes instances which are incorrectly classified. Useful
    /// for removing outliers.<br/><br/>Options:<br/><br/>-W &lt;classifier
    /// specification&gt; = 	Full class name of classifier to use, followed<br/>	by scheme
    /// options. eg:<br/>		"weka.classifiers.bayes.NaiveBayes -D"<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/>-C &lt;class index&gt; = 	Attribute on
    /// which misclassifications are based.<br/>	If < 0 will use any current set class
    /// or default to the last attribute.<br/>-F &lt;number of folds&gt; = 	The
    /// number of folds to use for cross-validation cleansing.<br/>	(<2 = no
    /// cross-validation - default).<br/>-T &lt;threshold&gt; = 	Threshold for the max
    /// error when predicting numeric class.<br/>	(Value should be >= 0, default =
    /// 0.1).<br/>-I = 	The maximum number of cleansing iterations to perform.<br/>	(<1
    /// = until fully cleansed - default)<br/>-V = 	Invert the match so that
    /// correctly classified instances are discarded.<br/>
    /// </summary>
    public RemoveMisclassified RemoveMisclassified() { return new RemoveMisclassified(rt); }

    /// <summary>
    /// A filter that removes a given percentage of a
    /// dataset.<br/><br/>Options:<br/><br/>-P &lt;percentage&gt; = 	Specifies percentage of instances to
    /// select. (default 50)<br/><br/>-V = 	Specifies if inverse of selection is to be
    /// output.<br/>
    /// </summary>
    public RemovePercentage RemovePercentage() { return new RemovePercentage(rt); }

    /// <summary>
    /// A filter that removes a given range of instances of a
    /// dataset.<br/><br/>Options:<br/><br/>-R &lt;inst1,inst2-inst4,...&gt; = 	Specifies list of
    /// instances to select. First and last<br/>	are valid indexes.
    /// (required)<br/><br/>-V = 	Specifies if inverse of selection is to be output.<br/>
    /// </summary>
    public RemoveRange RemoveRange() { return new RemoveRange(rt); }

    /// <summary>
    /// Filters instances according to the value of an
    /// attribute.<br/><br/>Options:<br/><br/>-C &lt;num&gt; = 	Choose attribute to be used for
    /// selection.<br/>-S &lt;num&gt; = 	Numeric value to be used for selection on
    /// numeric<br/>	attribute.<br/>	Instances with values smaller than given value will<br/>	be
    /// selected. (default 0)<br/>-L &lt;index1,index2-index4,...&gt; = 	Range of
    /// label indices to be used for selection on<br/>	nominal
    /// attribute.<br/>	First and last are valid indexes. (default all values)<br/>-M = 	Missing values
    /// count as a match. This setting is<br/>	independent of the -V
    /// option.<br/>	(default missing values don't match)<br/>-V = 	Invert matching
    /// sense.<br/>-H = 	When selecting on nominal attributes, removes header<br/>	references
    /// to excluded values.<br/>-F = 	Do not apply the filter to instances that
    /// arrive after the first<br/>	(training) batch. The default is to apply the
    /// filter (i.e.<br/>	the filter may not return an instance if it matches the remove
    /// criteria)
    /// </summary>
    public RemoveWithValues RemoveWithValues() { return new RemoveWithValues(rt); }

    /// <summary>
    /// Produces a random subsample of a dataset using either sampling with
    /// replacement or without replacement. The original dataset must fit entirely in
    /// memory. The number of instances in the generated dataset may be specified.
    /// When used in batch mode, subsequent batches are NOT
    /// resampled.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specify the random number seed (default
    /// 1)<br/>-Z &lt;num&gt; = 	The size of the output dataset, as a percentage
    /// of<br/>	the input dataset (default 100)<br/>-no-replacement = 	Disables
    /// replacement of instances<br/>	(default: with replacement)<br/>-V = 	Inverts the
    /// selection - only available with '-no-replacement'.
    /// </summary>
    public Resample Resample() { return new Resample(rt); }

    /// <summary>
    /// Produces a random subsample of a dataset using the reservoir sampling
    /// Algorithm "R" by Vitter. The original data set does not have to fit into main
    /// memory, but the reservoir does. <br/><br/>Options:<br/><br/>-S &lt;num&gt;
    /// = 	Specify the random number seed (default 1)<br/>-Z &lt;num&gt; = 	The
    /// size of the output dataset - number of instances<br/>	(default 100)
    /// </summary>
    public ReservoirSample ReservoirSample() { return new ReservoirSample(rt); }

    /// <summary>
    /// An instance filter that converts all incoming sparse instances into
    /// non-sparse format.
    /// </summary>
    public SparseToNonSparse SparseToNonSparse() { return new SparseToNonSparse(rt); }

    /// <summary>
    /// Filters instances according to a user-specified
    /// expression.<br/><br/>Grammar:<br/><br/>boolexpr_list ::= boolexpr_list boolexpr_part |
    /// boolexpr_part;<br/><br/>boolexpr_part ::= boolexpr:e {: parser.setResult(e); :}
    /// ;<br/><br/>boolexpr ::= BOOLEAN <br/> | true<br/> | false<br/> | expr < expr<br/> |
    /// expr <= expr<br/> | expr > expr<br/> | expr >= expr<br/> | expr =
    /// expr<br/> | ( boolexpr )<br/> | not boolexpr<br/> | boolexpr and boolexpr<br/> |
    /// boolexpr or boolexpr<br/> | ATTRIBUTE is STRING<br/> ;<br/><br/>expr ::=
    /// NUMBER<br/> | ATTRIBUTE<br/> | ( expr )<br/> | opexpr<br/> | funcexpr<br/>
    /// ;<br/><br/>opexpr ::= expr + expr<br/> | expr - expr<br/> | expr * expr<br/> |
    /// expr / expr<br/> ;<br/><br/>funcexpr ::= abs ( expr )<br/> | sqrt ( expr
    /// )<br/> | log ( expr )<br/> | exp ( expr )<br/> | sin ( expr )<br/> | cos (
    /// expr )<br/> | tan ( expr )<br/> | rint ( expr )<br/> | floor ( expr )<br/> |
    /// pow ( expr for base , expr for exponent )<br/> | ceil ( expr )<br/>
    /// ;<br/><br/>Notes:<br/>- NUMBER<br/> any integer or floating point number <br/>
    /// (but not in scientific notation!)<br/>- STRING<br/> any string surrounded by
    /// single quotes; <br/> the string may not contain a single quote though.<br/>-
    /// ATTRIBUTE<br/> the following placeholders are recognized for <br/>
    /// attribute values:<br/> - CLASS for the class value in case a class attribute is
    /// set.<br/> - ATTxyz with xyz a number from 1 to # of attributes in the<br/>
    /// dataset, representing the value of indexed
    /// attribute.<br/><br/>Examples:<br/>- extracting only mammals and birds from the 'zoo' UCI dataset:<br/> (CLASS
    /// is 'mammal') or (CLASS is 'bird')<br/>- extracting only animals with at
    /// least 2 legs from the 'zoo' UCI dataset:<br/> (ATT14 >= 2)<br/>- extracting
    /// only instances with non-missing 'wage-increase-second-year'<br/> from the
    /// 'labor' UCI dataset:<br/> not
    /// ismissing(ATT3)<br/><br/><br/>Options:<br/><br/>-E &lt;expr&gt; = 	The expression to use for filtering<br/>	(default:
    /// true).<br/>-F = 	Apply the filter to instances that arrive after the
    /// first<br/>	(training) batch. The default is to not apply the filter (i.e.<br/>	always
    /// return the instance)
    /// </summary>
    public SubsetByExpression SubsetByExpression() { return new SubsetByExpression(rt); }

    
  }
}