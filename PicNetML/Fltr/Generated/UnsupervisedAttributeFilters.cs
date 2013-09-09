// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  public class UnsupervisedAttributeFilters
  {
    private readonly Runtime rt;    
    public UnsupervisedAttributeFilters(Runtime rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that adds a new attribute to the dataset. The new
    /// attribute will contain all missing values.<br/><br/>Options:<br/><br/>-T
    /// &lt;NUM|NOM|STR|DAT&gt; = 	The type of attribute to create:<br/>	NUM = Numeric
    /// attribute<br/>	NOM = Nominal attribute<br/>	STR = String attribute<br/>	DAT =
    /// Date attribute<br/>	(default: NUM)<br/>-C &lt;index&gt; = 	Specify where
    /// to insert the column. First and last<br/>	are valid indexes.(default:
    /// last)<br/>-N &lt;name&gt; = 	Name of the new attribute.<br/>	(default:
    /// 'Unnamed')<br/>-L &lt;label1,label2,...&gt; = 	Create nominal attribute with given
    /// labels<br/>	(default: numeric attribute)<br/>-F &lt;format&gt; = 	The format
    /// of the date values (see ISO-8601)<br/>	(default: yyyy-MM-dd'T'HH:mm:ss)
    /// </summary>
    public Add Add() { return new Add(rt); }

    /// <summary>
    /// A filter that adds a new nominal attribute representing the cluster
    /// assigned to each instance by the specified clustering algorithm.<br/>Either the
    /// clustering algorithm gets built with the first batch of data or one
    /// specifies are serialized clusterer model file to use
    /// instead.<br/><br/>Options:<br/><br/>-W &lt;clusterer specification&gt; = 	Full class name of clusterer
    /// to use, followed<br/>	by scheme options.
    /// eg:<br/>		"weka.clusterers.SimpleKMeans -N 3"<br/>	(default: weka.clusterers.SimpleKMeans)<br/>-serialized
    /// &lt;file&gt; = 	Instead of building a clusterer on the data, one can also
    /// provide<br/>	a serialized model and use that for adding the clusters.<br/>-I
    /// &lt;att1,att2-att4,...&gt; = 	The range of attributes the clusterer should
    /// ignore.<br/>
    /// </summary>
    public AddCluster AddCluster() { return new AddCluster(rt); }

    /// <summary>
    /// An instance filter that creates a new attribute by applying a
    /// mathematical expression to existing attributes. The expression can contain attribute
    /// references and numeric constants. Supported operators are :<br/>+, -, *, /,
    /// ^, log, abs, cos, exp, sqrt, floor, ceil, rint, tan, sin, (,
    /// )<br/>Attributes are specified by prefixing with 'a', eg. a7 is attribute number 7
    /// (starting from 1).<br/>Example expression :
    /// a1^2*a5/log(a7*4.0).<br/><br/>Options:<br/><br/>-E &lt;expression&gt; = 	Specify the expression to apply. Eg
    /// a1^2*a5/log(a7*4.0).<br/>	Supported opperators: ,+, -, *, /, ^, log, abs, cos,
    /// <br/>	exp, sqrt, floor, ceil, rint, tan, sin, (, )<br/>	(default:
    /// a1^2)<br/>-N &lt;name&gt; = 	Specify the name for the new attribute. (default is
    /// the expression provided with -E)<br/>-D = 	Debug. Names attribute with the
    /// postfix parse of the expression.
    /// </summary>
    public AddExpression AddExpression() { return new AddExpression(rt); }

    /// <summary>
    /// An instance filter that adds an ID attribute to the dataset. The new
    /// attribute contains a unique ID for each instance.<br/>Note: The ID is not reset
    /// for the second batch of files (using -b and -r and
    /// -s).<br/><br/>Options:<br/><br/>-C &lt;index&gt; = 	Specify where to insert the ID. First and
    /// last<br/>	are valid indexes.(default first)<br/>-N &lt;name&gt; = 	Name of the
    /// new attribute.<br/>	(default = 'ID')
    /// </summary>
    public AddID AddID() { return new AddID(rt); }

    /// <summary>
    /// An instance filter that changes a percentage of a given attributes
    /// values. The attribute must be nominal. Missing value can be treated as value
    /// itself.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Index of the attribute to
    /// be changed <br/>	(default last attribute)<br/>-M = 	Treat missing values as
    /// an extra value <br/><br/>-P &lt;num&gt; = 	Specify the percentage of noise
    /// introduced <br/>	to the data (default 10)<br/>-S &lt;num&gt; = 	Specify
    /// the random number seed (default 1)
    /// </summary>
    public AddNoise AddNoise() { return new AddNoise(rt); }

    /// <summary>
    /// A filter that adds new attributes with user specified type and constant
    /// value. Numeric, nominal, string and date attributes can be created.
    /// Attribute name, and value can be set with environment variables. Date attributes
    /// can also specify a formatting string by which to parse the supplied date
    /// value. Alternatively, a current time stamp can be specified by supplying the
    /// special string "now" as the value for a date
    /// attribute.<br/><br/>Options:<br/><br/>-A &lt;name:type:value&gt; = 	New field specification
    /// (name@type@value).<br/>	 Environment variables may be used for any/all parts of
    /// the<br/>	specification. Type can be one of (numeric, nominal, string or
    /// date).<br/>	The value for date be a specific date string or the special
    /// string<br/>	"now" to indicate the current date-time. A specific date format<br/>	string for
    /// parsing specific date values can be specified by suffixing<br/>	the type
    /// specification - e.g. "myTime@date:MM-dd-yyyy@08-23-2009".This option may be
    /// specified multiple times
    /// </summary>
    public AddUserFields AddUserFields() { return new AddUserFields(rt); }

    /// <summary>
    /// Adds the labels from the given list to an attribute if they are missing.
    /// The labels can also be sorted in an ascending manner. If no labels are
    /// provided then only the (optional) sorting
    /// applies.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index<br/>	(default last).<br/>-L
    /// &lt;label1,label2,...&gt; = 	Comma-separated list of labels to
    /// add.<br/>	(default: none)<br/>-S = 	Turns on the sorting of the labels.
    /// </summary>
    public AddValues AddValues() { return new AddValues(rt); }

    /// <summary>
    /// Centers all numeric attributes in the given dataset to have zero mean
    /// (apart from the class attribute, if
    /// set).<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
    /// is<br/>	applied to the data.<br/>	(default: no)
    /// </summary>
    public Center Center() { return new Center(rt); }

    /// <summary>
    /// Changes the date format used by a date attribute. This is most useful for
    /// converting to a format with less precision, for example, from an absolute
    /// date to day of year, etc. This changes the format string, and changes the
    /// date values to those that would be parsed by the new
    /// format.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index (default
    /// last).<br/>-F &lt;value index&gt; = 	Sets the output date format string (default
    /// corresponds to ISO-8601).
    /// </summary>
    public ChangeDateFormat ChangeDateFormat() { return new ChangeDateFormat(rt); }

    /// <summary>
    /// Filter that can set and unset the class
    /// index.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-C
    /// &lt;num|first|last|0&gt; = 	The index of the class attribute. Index starts with 1,
    /// 'first'<br/>	and 'last' are accepted, '0' unsets the class index.<br/>	(default: last)
    /// </summary>
    public ClassAssigner ClassAssigner() { return new ClassAssigner(rt); }

    /// <summary>
    /// A filter that uses a density-based clusterer to generate cluster
    /// membership values; filtered instances are composed of these values plus the class
    /// attribute (if set in the input data). If a (nominal) class attribute is set,
    /// the clusterer is run separately for each class. The class attribute (if
    /// set) and any user-specified attributes are ignored during the clustering
    /// operation<br/><br/>Options:<br/><br/>-W &lt;clusterer name&gt; = 	Full name of
    /// clusterer to use. eg:<br/>		weka.clusterers.EM<br/>	Additional options
    /// after the '--'.<br/>	(default: weka.clusterers.EM)<br/>-I
    /// &lt;att1,att2-att4,...&gt; = 	The range of attributes the clusterer should ignore.<br/>	(the
    /// class attribute is automatically ignored)
    /// </summary>
    public ClusterMembership ClusterMembership() { return new ClusterMembership(rt); }

    /// <summary>
    /// An instance filter that copies a range of attributes in the dataset. This
    /// is used in conjunction with other filters that overwrite attribute values
    /// during the course of their operation -- this filter allows the original
    /// attributes to be kept as well as the new
    /// attributes.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of columns to copy.
    /// First and last are valid<br/>	indexes. (default none)<br/>-V = 	Invert
    /// matching sense (i.e. copy all non-specified columns)
    /// </summary>
    public Copy Copy() { return new Copy(rt); }

    /// <summary>
    /// An instance filter that discretizes a range of numeric attributes in the
    /// dataset into nominal attributes. Discretization is by simple binning. Skips
    /// the class attribute if
    /// set.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
    /// is<br/>	applied to the data.<br/>	(default: no)<br/>-B &lt;num&gt; = 	Specifies the
    /// (maximum) number of bins to divide numeric attributes into.<br/>	(default =
    /// 10)<br/>-M &lt;num&gt; = 	Specifies the desired weight of instances per bin
    /// for<br/>	equal-frequency binning. If this is set to a positive<br/>	number
    /// then the -B option will be ignored.<br/>	(default = -1)<br/>-F = 	Use
    /// equal-frequency instead of equal-width discretization.<br/>-O = 	Optimize number
    /// of bins using leave-one-out estimate<br/>	of estimated entropy (for
    /// equal-width discretization).<br/>	If this is set then the -B option will be
    /// ignored.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to
    /// Discretize. First and last are valid indexes.<br/>	(default: first-last)<br/>-V =
    /// 	Invert matching sense of column indexes.<br/>-D = 	Output binary
    /// attributes for discretized attributes.<br/>-Y = 	Use bin numbers rather than ranges
    /// for discretized attributes.
    /// </summary>
    public Discretize Discretize() { return new Discretize(rt); }

    /// <summary>
    /// This instance filter takes a range of N numeric attributes and replaces
    /// them with N-1 numeric attributes, the values of which are the difference
    /// between consecutive attribute values from the original instance. eg:
    /// <br/><br/>Original attribute values<br/><br/> 0.1, 0.2, 0.3, 0.1, 0.3<br/><br/>New
    /// attribute values<br/><br/> 0.1, 0.1, -0.2, 0.2<br/><br/>The range of
    /// attributes used is taken in numeric order. That is, a range spec of 7-11,3-5 will
    /// use the attribute ordering 3,4,5,7,8,9,10,11 for the differences, NOT
    /// 7,8,9,10,11,3,4,5.<br/><br/>Options:<br/><br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to take the differences between.<br/>	First
    /// and last are valid indexes.<br/>	(default none)
    /// </summary>
    public FirstOrder FirstOrder() { return new FirstOrder(rt); }

    /// <summary>
    /// A filter for detecting outliers and extreme values based on interquartile
    /// ranges. The filter skips the class attribute.<br/><br/>Outliers:<br/> Q3 +
    /// OF*IQR < x <= Q3 + EVF*IQR<br/> or<br/> Q1 - EVF*IQR <= x < Q1 -
    /// OF*IQR<br/><br/>Extreme values:<br/> x > Q3 + EVF*IQR<br/> or<br/> x < Q1 -
    /// EVF*IQR<br/><br/>Key:<br/> Q1 = 25% quartile<br/> Q3 = 75% quartile<br/> IQR =
    /// Interquartile Range, difference between Q1 and Q3<br/> OF = Outlier Factor<br/>
    /// EVF = Extreme Value Factor<br/><br/>Options:<br/><br/>-D = 	Turns on
    /// output of debugging information.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies
    /// list of columns to base outlier/extreme value detection<br/>	on. If an
    /// instance is considered in at least one of those<br/>	attributes an
    /// outlier/extreme value, it is tagged accordingly.<br/> 'first' and 'last' are valid
    /// indexes.<br/>	(default none)<br/>-O &lt;num&gt; = 	The factor for outlier
    /// detection.<br/>	(default: 3)<br/>-E &lt;num&gt; = 	The factor for extreme values
    /// detection.<br/>	(default: 2*Outlier Factor)<br/>-E-as-O = 	Tags extreme
    /// values also as outliers.<br/>	(default: off)<br/>-P = 	Generates
    /// Outlier/ExtremeValue pair for each numeric attribute in<br/>	the range, not just a
    /// single indicator pair for all the attributes.<br/>	(default: off)<br/>-M =
    /// 	Generates an additional attribute 'Offset' per Outlier/ExtremeValue<br/>	pair
    /// that contains the multiplier that the value is off the median.<br/>	 value
    /// = median + 'multiplier' * IQR<br/>Note: implicitely sets '-P'.	(default:
    /// off)
    /// </summary>
    public InterquartileRange InterquartileRange() { return new InterquartileRange(rt); }

    /// <summary>
    /// Converts the given set of predictor variables into a kernel matrix. The
    /// class value remains unchangedm, as long as the preprocessing filter doesn't
    /// change it.<br/>By default, the data is preprocessed with the Center filter,
    /// but the user can choose any filter (NB: one must be careful that the
    /// filter does not alter the class attribute unintentionally). With
    /// weka.filters.AllFilter the preprocessing gets disabled.<br/><br/>For more information
    /// regarding preprocessing the data, see:<br/><br/>K.P. Bennett, M.J. Embrechts:
    /// An Optimization Perspective on Kernel Partial Least Squares Regression. In:
    /// Advances in Learning Theory: Methods, Models and Applications, 227-249,
    /// 2003.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
    /// information.<br/>-no-checks = 	Turns off all checks - use with caution!<br/>	Turning
    /// them off assumes that data is purely numeric, doesn't<br/>	contain any
    /// missing values, and has a nominal class. Turning them<br/>	off also means that
    /// no header information will be stored if the<br/>	machine is linear.
    /// Finally, it also assumes that no instance has<br/>	a weight equal to
    /// 0.<br/>	(default: checks on)<br/>-F &lt;filename&gt; = 	The file to initialize the
    /// filter with (optional).<br/>-C &lt;num&gt; = 	The class index for the file to
    /// initialize with,<br/>	First and last are valid (optional, default:
    /// last).<br/>-K &lt;classname and parameters&gt; = 	The Kernel to use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/>-kernel-factor =
    /// 	Defines a factor for the kernel.<br/>		- RBFKernel: a factor for
    /// gamma<br/>			Standardize: 1/(2*N)<br/>			Normalize..: 6/N<br/>	Available parameters
    /// are:<br/>		N for # of instances, A for # of attributes<br/>	(default:
    /// 1)<br/>-P &lt;classname and parameters&gt; = 	The Filter used for preprocessing
    /// (use weka.filters.AllFilter<br/>	to disable preprocessing).<br/>	(default:
    /// weka.filters.unsupervised.attribute.Center)<br/><br/>Options specific to
    /// kernel weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D =
    /// 	Enables debugging output (if available) to be printed.<br/>	(default:
    /// off)<br/>-no-checks = 	Turns off all checks - use with caution!<br/>	(default: checks
    /// on)<br/>-C &lt;num&gt; = 	The size of the cache (a prime number), 0 for
    /// full cache and <br/>	-1 to turn it off.<br/>	(default: 250007)<br/>-E
    /// &lt;num&gt; = 	The Exponent to use.<br/>	(default: 1.0)<br/>-L = 	Use lower-order
    /// terms.<br/>	(default: no)<br/><br/>Options specific to preprocessing filter
    /// weka.filters.unsupervised.attribute.Center: = <br/>-unset-class-temporarily
    /// = 	Unsets the class index temporarily before the filter is<br/>	applied to
    /// the data.<br/>	(default: no)
    /// </summary>
    public KernelFilter KernelFilter() { return new KernelFilter(rt); }

    /// <summary>
    /// A filter that creates a new dataset with a boolean attribute replacing a
    /// nominal attribute. In the new dataset, a value of 1 is assigned to an
    /// instance that exhibits a particular range of attribute values, a 0 to an
    /// instance that doesn't. The boolean attribute is coded as numeric by
    /// default.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index.<br/>-V
    /// &lt;index1,index2-index4,...&gt; = 	Specify the list of values to indicate.
    /// First and last are<br/>	valid indexes (default last)<br/>-N &lt;index&gt; =
    /// 	Set if new boolean attribute nominal.
    /// </summary>
    public MakeIndicator MakeIndicator() { return new MakeIndicator(rt); }

    /// <summary>
    /// Modify numeric attributes according to a given expression
    /// <br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily
    /// before the filter is<br/>	applied to the data.<br/>	(default: no)<br/>-E
    /// &lt;expression&gt; = 	Specify the expression to apply. Eg.
    /// pow(A,6)/(MEAN+MAX)<br/>	Supported operators are +, -, *, /, pow, log,<br/>	abs, cos, exp,
    /// sqrt, tan, sin, ceil, floor, rint, (, ), <br/>	MEAN, MAX, MIN, SD, COUNT,
    /// SUM, SUMSQUARED, ifelse. The 'A'<br/>	letter refers to the value of the
    /// attribute being processed.<br/>	Other attribute values (numeric only) can be
    /// accessed through<br/>	the variables A1, A2, A3, ...<br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to ignore. First and last are
    /// valid<br/>	indexes. (default none)<br/>-V = 	Invert matching sense (i.e. only
    /// modify specified columns)
    /// </summary>
    public MathExpression MathExpression() { return new MathExpression(rt); }

    /// <summary>
    /// Merges many values of a nominal attribute into one
    /// value.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index<br/>	(default:
    /// last)<br/>-L &lt;label&gt; = 	Sets the label of the newly merged
    /// classes<br/>	(default: 'merged')<br/>-R &lt;range&gt; = 	Sets the merge range. 'first and
    /// 'last' are accepted as well.'<br/>	E.g.: first-5,7,9,20-last<br/>	(default:
    /// 1,2)
    /// </summary>
    public MergeManyValues MergeManyValues() { return new MergeManyValues(rt); }

    /// <summary>
    /// Merges two values of a nominal attribute into one
    /// value.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index (default
    /// last).<br/>-F &lt;value index&gt; = 	Sets the first value's index (default
    /// first).<br/>-S &lt;value index&gt; = 	Sets the second value's index (default last).
    /// </summary>
    public MergeTwoValues MergeTwoValues() { return new MergeTwoValues(rt); }

    /// <summary>
    /// Converts all nominal attributes into binary numeric attributes. An
    /// attribute with k values is transformed into k binary attributes if the class is
    /// nominal (using the one-attribute-per-value approach). Binary attributes are
    /// left binary, if option '-A' is not given.If the class is numeric, you might
    /// want to use the supervised version of this
    /// filter.<br/><br/>Options:<br/><br/>-N = 	Sets if binary attributes are to be coded as nominal ones.<br/>-A
    /// = 	For each nominal value a new attribute is created, <br/>	not only if
    /// there are more than 2 values.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies
    /// list of columns to act on. First and last are <br/>	valid
    /// indexes.<br/>	(default: first-last)<br/>-V = 	Invert matching sense of column indexes.
    /// </summary>
    public NominalToBinary NominalToBinary() { return new NominalToBinary(rt); }

    /// <summary>
    /// Converts a nominal attribute (that is, a set number of values) to string
    /// (that is, an unspecified number of values).<br/><br/>Options:<br/><br/>-C
    /// &lt;col&gt; = 	Sets the range of attributes to convert (default last).
    /// </summary>
    public NominalToString NominalToString() { return new NominalToString(rt); }

    /// <summary>
    /// Normalizes all numeric values in the given dataset (apart from the class
    /// attribute, if set). The resulting values are by default in [0,1] for the
    /// data used to compute the normalization intervals. But with the scale and
    /// translation parameters one can change that, e.g., with scale = 2.0 and
    /// translation = -1.0 you get values in the range
    /// [-1,+1].<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the
    /// filter is<br/>	applied to the data.<br/>	(default: no)<br/>-S &lt;num&gt; =
    /// 	The scaling factor for the output range.<br/>	(default: 1.0)<br/>-T
    /// &lt;num&gt; = 	The translation of the output range.<br/>	(default: 0.0)
    /// </summary>
    public Normalize Normalize() { return new Normalize(rt); }

    /// <summary>
    /// A filter that 'cleanses' the numeric data from values that are too small,
    /// too big or very close to a certain value (e.g., 0) and sets these values
    /// to a pre-defined default.<br/><br/>Options:<br/><br/>-D = 	Turns on output
    /// of debugging information.<br/>-min &lt;double&gt; = 	The minimum threshold.
    /// (default -Double.MAX_VALUE)<br/>-min-default &lt;double&gt; = 	The
    /// replacement for values smaller than the minimum threshold.<br/>	(default
    /// -Double.MAX_VALUE)<br/>-max &lt;double&gt; = 	The maximum threshold. (default
    /// Double.MAX_VALUE)<br/>-max-default &lt;double&gt; = 	The replacement for values
    /// larger than the maximum threshold.<br/>	(default
    /// Double.MAX_VALUE)<br/>-closeto &lt;double&gt; = 	The number values are checked for closeness. (default
    /// 0)<br/>-closeto-default &lt;double&gt; = 	The replacement for values that
    /// are close to '-closeto'.<br/>	(default 0)<br/>-closeto-tolerance
    /// &lt;double&gt; = 	The tolerance below which numbers are considered being close to
    /// <br/>	to each other. (default 1E-6)<br/>-decimals &lt;int&gt; = 	The number of
    /// decimals to round to, -1 means no rounding at all.<br/>	(default -1)<br/>-R
    /// &lt;col1,col2,...&gt; = 	The list of columns to cleanse, e.g., first-last
    /// or first-3,5-last.<br/>	(default first-last)<br/>-V = 	Inverts the matching
    /// sense.<br/>-include-class = 	Whether to include the class in the
    /// cleansing.<br/>	The class column will always be skipped, if this flag is
    /// not<br/>	present. (default no)
    /// </summary>
    public NumericCleaner NumericCleaner() { return new NumericCleaner(rt); }

    /// <summary>
    /// Converts all numeric attributes into binary attributes (apart from the
    /// class attribute, if set): if the value of the numeric attribute is exactly
    /// zero, the value of the new attribute will be zero. If the value of the
    /// numeric attribute is missing, the value of the new attribute will be missing.
    /// Otherwise, the value of the new attribute will be one. The new attributes will
    /// be nominal.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets
    /// the class index temporarily before the filter is<br/>	applied to the
    /// data.<br/>	(default: no)
    /// </summary>
    public NumericToBinary NumericToBinary() { return new NumericToBinary(rt); }

    /// <summary>
    /// A filter for turning numeric attributes into nominal ones. Unlike
    /// discretization, it just takes all numeric values and adds them to the list of
    /// nominal values of that attribute. Useful after CSV imports, to enforce certain
    /// attributes to become nominal, e.g., the class attribute, containing values
    /// from 1 to 5.<br/><br/>Options:<br/><br/>-R &lt;col1,col2-col4,...&gt; =
    /// 	Specifies list of columns to Discretize. First and last are valid
    /// indexes.<br/>	(default: first-last)<br/>-V = 	Invert matching sense of column indexes.
    /// </summary>
    public NumericToNominal NumericToNominal() { return new NumericToNominal(rt); }

    /// <summary>
    /// Transforms numeric attributes using a given transformation
    /// method.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of
    /// columns to transform. First and last are<br/>	valid indexes (default
    /// none). Non-numeric columns are <br/>	skipped.<br/>-V = 	Invert matching
    /// sense.<br/>-C &lt;string&gt; = 	Sets the class containing transformation
    /// method.<br/>	(default java.lang.Math)<br/>-M &lt;string&gt; = 	Sets the method.
    /// (default abs)
    /// </summary>
    public NumericTransform NumericTransform() { return new NumericTransform(rt); }

    /// <summary>
    /// A simple instance filter that renames the relation, all attribute names
    /// and all nominal (and string) attribute values. For exchanging sensitive
    /// datasets. Currently doesn't like string or relational attributes.
    /// </summary>
    public Obfuscate Obfuscate() { return new Obfuscate(rt); }

    /// <summary>
    /// Discretizes numeric attributes using equal frequency binning, where the
    /// number of bins is equal to the square root of the number of non-missing
    /// values.<br/><br/>For more information, see:<br/><br/>Ying Yang, Geoffrey I.
    /// Webb: Proportional k-Interval Discretization for Naive-Bayes Classifiers. In:
    /// 12th European Conference on Machine Learning, 564-575,
    /// 2001.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily
    /// before the filter is<br/>	applied to the data.<br/>	(default: no)<br/>-R
    /// &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to Discretize. First
    /// and last are valid indexes.<br/>	(default: first-last)<br/>-V = 	Invert
    /// matching sense of column indexes.<br/>-D = 	Output binary attributes for
    /// discretized attributes.
    /// </summary>
    public PKIDiscretize PKIDiscretize() { return new PKIDiscretize(rt); }

    /// <summary>
    /// A filter that uses a PartitionGenerator to generate partition membership
    /// values; filtered instances are composed of these values plus the class
    /// attribute (if set in the input data) and rendered as sparse
    /// instances.<br/><br/>Options:<br/><br/>-W &lt;name of partition generator&gt; = 	Full name of
    /// partition generator to use,
    /// e.g.:<br/>		weka.classifiers.trees.J48<br/>	Additional options after the '--'.<br/>	(default: weka.classifiers.trees.J48)
    /// </summary>
    public PartitionMembership PartitionMembership() { return new PartitionMembership(rt); }

    /// <summary>
    /// A filter that applies filters on subsets of attributes and assembles the
    /// output into a new dataset. Attributes that are not covered by any of the
    /// ranges can be either retained or removed from the
    /// output.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F
    /// &lt;classname [options]&gt; = 	A filter to apply (can be specified multiple
    /// times).<br/>-R &lt;range&gt; = 	An attribute range (can be specified multiple
    /// times).<br/>	For each filter a range must be supplied. 'first' and 'last'<br/>	are
    /// valid indices. 'inv(...)' around the range denotes an<br/>	inverted
    /// range.<br/>-U = 	Flag for leaving unused attributes out of the output, by
    /// default<br/>	these are included in the filter output.
    /// </summary>
    public PartitionedMultiFilter PartitionedMultiFilter() { return new PartitionedMultiFilter(rt); }

    /// <summary>
    /// Performs a principal components analysis and transformation of the
    /// data.<br/>Dimensionality reduction is accomplished by choosing enough
    /// eigenvectors to account for some percentage of the variance in the original data --
    /// default 0.95 (95%).<br/>Based on code of the attribute selection scheme
    /// 'PrincipalComponents' by Mark Hall and Gabi
    /// Schmidberger.<br/><br/>Options:<br/><br/>-C = 	Center (rather than standardize) the<br/>	data and compute PCA
    /// using the covariance (rather<br/>	 than the correlation) matrix.<br/>-R
    /// &lt;num&gt; = 	Retain enough PC attributes to account<br/>	for this proportion
    /// of variance in the original data.<br/>	(default: 0.95)<br/>-A &lt;num&gt; =
    /// 	Maximum number of attributes to include in <br/>	transformed attribute
    /// names.<br/>	(-1 = include all, default: 5)<br/>-M &lt;num&gt; = 	Maximum
    /// number of PC attributes to retain.<br/>	(-1 = include all, default: -1)
    /// </summary>
    public PrincipalComponents PrincipalComponents() { return new PrincipalComponents(rt); }

    /// <summary>
    /// Reduces the dimensionality of the data by projecting it onto a lower
    /// dimensional subspace using a random matrix with columns of unit length (i.e. It
    /// will reduce the number of attributes in the data while preserving much of
    /// its variation like PCA, but at a much less computational cost).<br/>It
    /// first applies the NominalToBinary filter to convert all attributes to numeric
    /// before reducing the dimension. It preserves the class
    /// attribute.<br/><br/>For more information, see:<br/><br/>Dmitriy Fradkin, David Madigan:
    /// Experiments with random projections for machine learning. In: KDD '03: Proceedings
    /// of the ninth ACM SIGKDD international conference on Knowledge discovery and
    /// data mining, New York, NY, USA, 517-522, 003.<br/><br/>Options:<br/><br/>-N
    /// &lt;number&gt; = 	The number of dimensions (attributes) the data should be
    /// reduced to<br/>	(default 10; exclusive of the class attribute, if it is
    /// set).<br/>-D [SPARSE1|SPARSE2|GAUSSIAN] = 	The distribution to use for
    /// calculating the random matrix.<br/>	Sparse1 is:<br/>	 sqrt(3)*{-1 with prob(1/6),
    /// 0 with prob(2/3), +1 with prob(1/6)}<br/>	Sparse2 is:<br/>	 {-1 with
    /// prob(1/2), +1 with prob(1/2)}<br/><br/>-P &lt;percent&gt; = 	The percentage of
    /// dimensions (attributes) the data should<br/>	be reduced to (exclusive of the
    /// class attribute, if it is set). This -N<br/>	option is ignored if this
    /// option is present or is greater<br/>	than zero.<br/>-M = 	Replace missing
    /// values using the ReplaceMissingValues filter<br/>-R &lt;num&gt; = 	The random
    /// seed for the random number generator used for<br/>	calculating the random
    /// matrix (default 42).
    /// </summary>
    public RandomProjection RandomProjection() { return new RandomProjection(rt); }

    /// <summary>
    /// Chooses a random subset of attributes, either an absolute number or a
    /// percentage. The class is always included in the output (as the last
    /// attribute).<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
    /// information.<br/>-N &lt;double&gt; = 	The number of attributes to randomly
    /// select.<br/>	If < 1 then percentage, >= 1 absolute number.<br/>	(default: 0.5)<br/>-S
    /// &lt;int&gt; = 	The seed value.<br/>	(default: 1)
    /// </summary>
    public RandomSubset RandomSubset() { return new RandomSubset(rt); }

    /// <summary>
    /// A filter that removes a range of attributes from the dataset. Will
    /// re-order the remaining attributes if invert matching sense is turned on and the
    /// attribute column indices are not specified in ascending
    /// order.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of
    /// columns to delete. First and last are valid<br/>	indexes. (default none)<br/>-V =
    /// 	Invert matching sense (i.e. only keep specified columns)
    /// </summary>
    public Remove Remove() { return new Remove(rt); }

    /// <summary>
    /// Removes attributes based on a regular expression matched against their
    /// names.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
    /// information.<br/>-E &lt;regular expression&gt; = 	The regular expression to match
    /// the attribute names against.<br/>	(default: ^.*id$)<br/>-V = 	Flag for
    /// inverting the matching sense. If set, attributes are kept<br/>	instead of
    /// deleted.<br/>	(default: off)
    /// </summary>
    public RemoveByName RemoveByName() { return new RemoveByName(rt); }

    /// <summary>
    /// Removes attributes of a given type.<br/><br/>Options:<br/><br/>-T
    /// &lt;nominal|numeric|string|date|relational&gt; = 	Attribute type to delete. Valid
    /// options are "nominal", <br/>	"numeric", "string", "date" and
    /// "relational".<br/>	(default "string")<br/>-V = 	Invert matching sense (i.e. only keep
    /// specified columns)
    /// </summary>
    public RemoveType RemoveType() { return new RemoveType(rt); }

    /// <summary>
    /// This filter removes attributes that do not vary at all or that vary too
    /// much. All constant attributes are deleted automatically, along with any that
    /// exceed the maximum percentage of variance parameter. The maximum variance
    /// test is only applied to nominal attributes.<br/><br/>Options:<br/><br/>-M
    /// &lt;max variance %&gt; = 	Maximum variance percentage allowed (default 99)
    /// </summary>
    public RemoveUseless RemoveUseless() { return new RemoveUseless(rt); }

    /// <summary>
    /// This filter is used for renaming attribute names.<br/>Regular expressions
    /// can be used in the matching and replacing.<br/>See Javadoc of
    /// java.util.regex.Pattern class for more
    /// information:<br/>http://java.sun.com/javase/6/docs/api/java/util/regex/Pattern.html<br/><br/>Options:<br/><br/>-find
    /// &lt;regexp&gt; = 	The regular expression that the attribute names must
    /// match.<br/>	(default: ([\s\S]+))<br/>-replace &lt;string&gt; = 	The string to replace
    /// the regular expression of matching attributes with.<br/>	Cannot be used in
    /// conjunction with '-remove'.<br/>	(default: $0)<br/>-remove = 	In case the
    /// matching string needs to be removed instead of replaced.<br/>	Cannot be
    /// used in conjunction with '-replace <string>'.<br/>	(default: off)<br/>-all =
    /// 	Replaces all occurrences instead of just the first.<br/>	(default: only
    /// first occurrence)<br/>-R &lt;range&gt; = 	The attribute range to work
    /// on.<br/>This is a comma separated list of attribute indices, with "first" and
    /// "last" valid values.<br/>	Specify an inclusive range with "-".<br/>	E.g:
    /// "first-3,5,6-10,last".<br/>	(default: first-last)<br/>-V = 	Inverts the attribute
    /// selection range.<br/>	(default: off)
    /// </summary>
    public RenameAttribute RenameAttribute() { return new RenameAttribute(rt); }

    /// <summary>
    /// A filter that generates output with a new order of the attributes. Useful
    /// if one wants to move an attribute to the end to use it as class attribute
    /// (e.g. with using "-R 2-last,1").<br/>But it's not only possible to change
    /// the order of all the attributes, but also to leave out attributes. E.g. if
    /// you have 10 attributes, you can generate the following output order:
    /// 1,3,5,7,9,10 or 10,1-5.<br/>You can also duplicate attributes, e.g. for further
    /// processing later on: e.g. 1,1,1,4,4,4,2,2,2 where the second and the third
    /// column of each attribute are processed differently and the first one, i.e.
    /// the original one is kept.<br/>One can simply inverse the order of the
    /// attributes via 'last-first'.<br/>After appyling the filter, the index of the class
    /// attribute is the last attribute.<br/><br/>Options:<br/><br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to copy. First and last
    /// are valid<br/>	indexes. (default first-last)
    /// </summary>
    public Reorder Reorder() { return new Reorder(rt); }

    /// <summary>
    /// Replaces all missing values for nominal and numeric attributes in a
    /// dataset with the modes and means from the training
    /// data.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before
    /// the filter is<br/>	applied to the data.<br/>	(default: no)
    /// </summary>
    public ReplaceMissingValues ReplaceMissingValues() { return new ReplaceMissingValues(rt); }

    /// <summary>
    /// Replaces all missing values for nominal, string, numeric and date
    /// attributes in the dataset with user-supplied constant
    /// values.<br/><br/>Options:<br/><br/>-A &lt;index1,index2-index4,... | att-name1,att-name2,...&gt; =
    /// 	Specify list of attributes to replace missing values for <br/>	(as weka range
    /// list of indices or a comma separated list of attribute
    /// names).<br/>	(default: consider all attributes)<br/>-N = 	Specify the replacement constant for
    /// nominal/string attributes<br/>-R = 	Specify the replacement constant for
    /// numeric attributes<br/>	(default: 0)<br/>-D = 	Specify the replacement
    /// constant for date attributes<br/>-F = 	Specify the date format for parsing the
    /// replacement date constant<br/>	(default:
    /// yyyy-MM-dd'T'HH:mm:ss)<br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
    /// is<br/>	applied to the data.<br/>	(default: no)
    /// </summary>
    public ReplaceMissingWithUserConstant ReplaceMissingWithUserConstant() { return new ReplaceMissingWithUserConstant(rt); }

    /// <summary>
    /// A simple filter for sorting the labels of nominal
    /// attributes.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of string attributes to
    /// convert to words.<br/>	(default: select all relational attributes)<br/>-V =
    /// 	Inverts the matching sense of the selection.<br/>-S &lt;CASE|NON-CASE&gt; =
    /// 	Determines the type of sorting:<br/>	CASE = Case-sensitive<br/>	NON-CASE =
    /// Case-insensitive<br/>	(default: CASE)
    /// </summary>
    public SortLabels SortLabels() { return new SortLabels(rt); }

    /// <summary>
    /// Standardizes all numeric attributes in the given dataset to have zero
    /// mean and unit variance (apart from the class attribute, if
    /// set).<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index
    /// temporarily before the filter is<br/>	applied to the data.<br/>	(default: no)
    /// </summary>
    public Standardize Standardize() { return new Standardize(rt); }

    /// <summary>
    /// Converts a range of string attributes (unspecified number of values) to
    /// nominal (set number of values). You should ensure that all string values
    /// that will appear are represented in the first batch of the
    /// data.<br/><br/>Options:<br/><br/>-R &lt;col&gt; = 	Sets the range of attribute indices
    /// (default last).<br/>-V &lt;col&gt; = 	Invert the range specified by -R.
    /// </summary>
    public StringToNominal StringToNominal() { return new StringToNominal(rt); }

    /// <summary>
    /// Converts String attributes into a set of attributes representing word
    /// occurrence (depending on the tokenizer) information from the text contained in
    /// the strings. The set of words (attributes) is determined by the first
    /// batch filtered (typically training data).<br/><br/>Options:<br/><br/>-C =
    /// 	Output word counts rather than boolean word presence.<br/><br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of string attributes to convert to
    /// words (as weka Range).<br/>	(default: select all string attributes)<br/>-V =
    /// 	Invert matching sense of column indexes.<br/>-P &lt;attribute name
    /// prefix&gt; = 	Specify a prefix for the created attribute names.<br/>	(default:
    /// "")<br/>-W &lt;number of words to keep&gt; = 	Specify approximate number of word
    /// fields to create.<br/>	Surplus words will be discarded..<br/>	(default:
    /// 1000)<br/>-prune-rate &lt;rate as a percentage of dataset&gt; = 	Specify the
    /// rate (e.g., every 10% of the input dataset) at which to periodically prune
    /// the dictionary.<br/>	-W prunes after creating a full dictionary. You may
    /// not have enough memory for this approach.<br/>	(default: no periodic
    /// pruning)<br/>-T = 	Transform the word frequencies into log(1+fij)<br/>	where fij is
    /// the frequency of word i in jth document(instance).<br/><br/>-I =
    /// 	Transform each word frequency into:<br/>	fij*log(num of Documents/num of documents
    /// containing word i)<br/>	 where fij if frequency of word i in jth
    /// document(instance)<br/>-N = 	Whether to 0=not normalize/1=normalize all
    /// data/2=normalize test data only<br/>	to average length of training documents (default
    /// 0=don't normalize).<br/>-L = 	Convert all tokens to lowercase before adding
    /// to the dictionary.<br/>-S = 	Ignore words that are in the
    /// stoplist.<br/>-stemmer &lt;spec&gt; = 	The stemmering algorihtm (classname plus parameters)
    /// to use.<br/>-M &lt;int&gt; = 	The minimum term frequency (default =
    /// 1).<br/>-O = 	If this is set, the maximum number of words and the <br/>	minimum
    /// term frequency is not enforced on a per-class <br/>	basis but based on the
    /// documents in all the classes <br/>	(even if a class attribute is
    /// set).<br/>-stopwords &lt;file&gt; = 	A file containing stopwords to override the default
    /// ones.<br/>	Using this option automatically sets the flag ('-S') to use
    /// the<br/>	stoplist if the file exists.<br/>	Format: one stopword per line,
    /// lines starting with '#'<br/>	are interpreted as comments and
    /// ignored.<br/>-tokenizer &lt;spec&gt; = 	The tokenizing algorihtm (classname plus parameters)
    /// to use.<br/>	(default: weka.core.tokenizers.WordTokenizer)
    /// </summary>
    public StringToWordVector StringToWordVector() { return new StringToWordVector(rt); }

    /// <summary>
    /// Swaps two values of a nominal attribute.<br/><br/>Options:<br/><br/>-C
    /// &lt;col&gt; = 	Sets the attribute index (default last).<br/>-F &lt;value
    /// index&gt; = 	Sets the first value's index (default first).<br/>-S &lt;value
    /// index&gt; = 	Sets the second value's index (default last).
    /// </summary>
    public SwapValues SwapValues() { return new SwapValues(rt); }

    /// <summary>
    /// An instance filter that assumes instances form time-series data and
    /// replaces attribute values in the current instance with the difference between
    /// the current value and the equivalent attribute attribute value of some
    /// previous (or future) instance. For instances where the time-shifted value is
    /// unknown either the instance may be dropped, or missing values used. Skips the
    /// class attribute if it is set.<br/><br/>Options:<br/><br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to translate in time. First
    /// and<br/>	last are valid indexes. (default none)<br/>-V = 	Invert matching
    /// sense (i.e. calculate for all non-specified columns)<br/>-I &lt;num&gt; = 	The
    /// number of instances forward to translate values<br/>	between. A negative
    /// number indicates taking values from<br/>	a past instance. (default -1)<br/>-M
    /// = 	For instances at the beginning or end of the dataset where<br/>	the
    /// translated values are not known, remove those instances<br/>	(default is to
    /// use missing values).
    /// </summary>
    public TimeSeriesDelta TimeSeriesDelta() { return new TimeSeriesDelta(rt); }

    /// <summary>
    /// An instance filter that assumes instances form time-series data and
    /// replaces attribute values in the current instance with the equivalent attribute
    /// values of some previous (or future) instance. For instances where the
    /// desired value is unknown either the instance may be dropped, or missing values
    /// used. Skips the class attribute if it is set.<br/><br/>Options:<br/><br/>-R
    /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to translate in
    /// time. First and<br/>	last are valid indexes. (default none)<br/>-V =
    /// 	Invert matching sense (i.e. calculate for all non-specified columns)<br/>-I
    /// &lt;num&gt; = 	The number of instances forward to translate
    /// values<br/>	between. A negative number indicates taking values from<br/>	a past instance.
    /// (default -1)<br/>-M = 	For instances at the beginning or end of the dataset
    /// where<br/>	the translated values are not known, remove those
    /// instances<br/>	(default is to use missing values).
    /// </summary>
    public TimeSeriesTranslate TimeSeriesTranslate() { return new TimeSeriesTranslate(rt); }

    
  }
}