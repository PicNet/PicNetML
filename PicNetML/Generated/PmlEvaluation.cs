using System.Collections;
using System.Collections.Generic;
using weka.core;
using PicNetML.Clss;
using weka.classifiers;

// ReSharper disable once CheckNamespace
namespace PicNetML
{
  public partial class PmlEvaluation 
  {
    public PmlEvaluation(Evaluation impl) { Impl = impl; }

    public Evaluation Impl { get; private set; }

    public double[] EvaluateModel(IBaseClassifier<Classifier> classifier, Runtime data, object[] forPredictionsPrinting) { return Impl.evaluateModel(classifier.Impl, data.Impl, forPredictionsPrinting); }
    public double ErrorRate { get { return Impl.errorRate(); } }
    public double RootMeanSquaredError { get { return Impl.rootMeanSquaredError(); } }
    public double MeanAbsoluteError { get { return Impl.meanAbsoluteError(); } }
    public double WeightedFMeasure { get { return Impl.weightedFMeasure(); } }
    public double FMeasure(int classIndex) { return Impl.fMeasure(classIndex); }
    public double WeightedAreaUnderROC { get { return Impl.weightedAreaUnderROC(); } }
    public double AreaUnderROC(int classIndex) { return Impl.areaUnderROC(classIndex); }
    public double WeightedAreaUnderPRC { get { return Impl.weightedAreaUnderPRC(); } }
    public double AreaUnderPRC(int classIndex) { return Impl.areaUnderPRC(classIndex); }
    public static string EvaluateModel(IBaseClassifier<Classifier> classifier, string[] options) { return Evaluation.evaluateModel(classifier.Impl, options); }
    public static string EvaluateModel(string classifierString, string[] options) { return Evaluation.evaluateModel(classifierString, options); }
    public Runtime GetHeader { get { return new Runtime(Impl.getHeader()); } }
    public void SetDiscardPredictions(bool value) { Impl.setDiscardPredictions(value); }
    public bool GetDiscardPredictions { get { return Impl.getDiscardPredictions(); } }
    public double[][] ConfusionMatrix { get { return Impl.confusionMatrix(); } }
    public double EvaluateModelOnceAndRecordPrediction(IBaseClassifier<Classifier> classifier, PmlInstance instance) { return Impl.evaluateModelOnceAndRecordPrediction(classifier.Impl, instance.Impl); }
    public double EvaluateModelOnce(IBaseClassifier<Classifier> classifier, PmlInstance instance) { return Impl.evaluateModelOnce(classifier.Impl, instance.Impl); }
    public double EvaluateModelOnce(double[] dist, PmlInstance instance) { return Impl.evaluateModelOnce(dist, instance.Impl); }
    public double EvaluateModelOnceAndRecordPrediction(double[] dist, PmlInstance instance) { return Impl.evaluateModelOnceAndRecordPrediction(dist, instance.Impl); }
    public void EvaluateModelOnce(double prediction, PmlInstance instance) { Impl.evaluateModelOnce(prediction, instance.Impl); }
    public double NumInstances { get { return Impl.numInstances(); } }
    public double CoverageOfTestCasesByPredictedRegions { get { return Impl.coverageOfTestCasesByPredictedRegions(); } }
    public double SizeOfPredictedRegions { get { return Impl.sizeOfPredictedRegions(); } }
    public double Incorrect { get { return Impl.incorrect(); } }
    public double PctIncorrect { get { return Impl.pctIncorrect(); } }
    public double TotalCost { get { return Impl.totalCost(); } }
    public double AvgCost { get { return Impl.avgCost(); } }
    public double Correct { get { return Impl.correct(); } }
    public double PctCorrect { get { return Impl.pctCorrect(); } }
    public double Unclassified { get { return Impl.unclassified(); } }
    public double PctUnclassified { get { return Impl.pctUnclassified(); } }
    public double Kappa { get { return Impl.kappa(); } }
    public string GetRevision { get { return Impl.getRevision(); } }
    public double CorrelationCoefficient { get { return Impl.correlationCoefficient(); } }
    public double MeanPriorAbsoluteError { get { return Impl.meanPriorAbsoluteError(); } }
    public double RelativeAbsoluteError { get { return Impl.relativeAbsoluteError(); } }
    public double RootMeanPriorSquaredError { get { return Impl.rootMeanPriorSquaredError(); } }
    public double RootRelativeSquaredError { get { return Impl.rootRelativeSquaredError(); } }
    public double PriorEntropy { get { return Impl.priorEntropy(); } }
    public double KBInformation { get { return Impl.KBInformation(); } }
    public double KBMeanInformation { get { return Impl.KBMeanInformation(); } }
    public double KBRelativeInformation { get { return Impl.KBRelativeInformation(); } }
    public double SFPriorEntropy { get { return Impl.SFPriorEntropy(); } }
    public double SFMeanPriorEntropy { get { return Impl.SFMeanPriorEntropy(); } }
    public double SFSchemeEntropy { get { return Impl.SFSchemeEntropy(); } }
    public double SFMeanSchemeEntropy { get { return Impl.SFMeanSchemeEntropy(); } }
    public double SFEntropyGain { get { return Impl.SFEntropyGain(); } }
    public double SFMeanEntropyGain { get { return Impl.SFMeanEntropyGain(); } }
    public string ToCumulativeMarginDistributionString { get { return Impl.toCumulativeMarginDistributionString(); } }
    public string ToSummaryString() { return Impl.toSummaryString(); }
    public string ToSummaryString(bool printComplexityStatistics) { return Impl.toSummaryString(printComplexityStatistics); }
    public string ToSummaryString(string title, bool printComplexityStatistics) { return Impl.toSummaryString(title, printComplexityStatistics); }
    public string ToMatrixString() { return Impl.toMatrixString(); }
    public string ToMatrixString(string title) { return Impl.toMatrixString(title); }
    public string ToClassDetailsString() { return Impl.toClassDetailsString(); }
    public string ToClassDetailsString(string title) { return Impl.toClassDetailsString(title); }
    public double NumTruePositives(int classIndex) { return Impl.numTruePositives(classIndex); }
    public double TruePositiveRate(int classIndex) { return Impl.truePositiveRate(classIndex); }
    public double WeightedTruePositiveRate { get { return Impl.weightedTruePositiveRate(); } }
    public double NumTrueNegatives(int classIndex) { return Impl.numTrueNegatives(classIndex); }
    public double TrueNegativeRate(int classIndex) { return Impl.trueNegativeRate(classIndex); }
    public double WeightedTrueNegativeRate { get { return Impl.weightedTrueNegativeRate(); } }
    public double NumFalsePositives(int classIndex) { return Impl.numFalsePositives(classIndex); }
    public double FalsePositiveRate(int classIndex) { return Impl.falsePositiveRate(classIndex); }
    public double WeightedFalsePositiveRate { get { return Impl.weightedFalsePositiveRate(); } }
    public double NumFalseNegatives(int classIndex) { return Impl.numFalseNegatives(classIndex); }
    public double FalseNegativeRate(int classIndex) { return Impl.falseNegativeRate(classIndex); }
    public double WeightedFalseNegativeRate { get { return Impl.weightedFalseNegativeRate(); } }
    public double MatthewsCorrelationCoefficient(int classIndex) { return Impl.matthewsCorrelationCoefficient(classIndex); }
    public double WeightedMatthewsCorrelation { get { return Impl.weightedMatthewsCorrelation(); } }
    public double Recall(int classIndex) { return Impl.recall(classIndex); }
    public double WeightedRecall { get { return Impl.weightedRecall(); } }
    public double Precision(int classIndex) { return Impl.precision(classIndex); }
    public double WeightedPrecision { get { return Impl.weightedPrecision(); } }
    public double UnweightedMacroFmeasure { get { return Impl.unweightedMacroFmeasure(); } }
    public double UnweightedMicroFmeasure { get { return Impl.unweightedMicroFmeasure(); } }
    public void SetPriors(Runtime train) { Impl.setPriors(train.Impl); }
    public double[] GetClassPriors { get { return Impl.getClassPriors(); } }
    public void UpdatePriors(PmlInstance instance) { Impl.updatePriors(instance.Impl); }
    public void UseNoPriors() { Impl.useNoPriors(); }
    

        
  }
}
