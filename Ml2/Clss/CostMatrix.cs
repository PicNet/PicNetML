namespace Ml2.Clss
{
  public class CostMatrix 
  {
    public weka.classifiers.CostMatrix Impl { get; private set; }

    public CostMatrix(int numclasses, double[,] matrix) {
      Impl = new weka.classifiers.CostMatrix(numclasses);      
      for (int r = 0; r < matrix.GetLength(0); r++) 
        for (int c = 0; c < matrix.GetLength(1); c++) { Impl.setElement(r, c, matrix[r, c]); }            
    }
  }
}