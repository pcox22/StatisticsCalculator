namespace LogicModule;

public class LinearRegression
{
    public static double ComputeForY(double x, double m, double b)
    {
        return b + (m * x);
    }
    public static double ComputeForYLinearRegression(List<double> valuesList)
    {
        return LogicModule.LinearRegression.ComputeForY(valuesList[0], valuesList[1], valuesList[2]);
    }

    public static double ComputeSum(List<double> z)
    {
        double ySum = 0;
        foreach (var num in z)
        {
            ySum += num;
        }

        return ySum;
    }
    
    public static double ComputeSquaredSum(List<double> z)
    {
        double xSquared = 0;
        foreach (var num in z)
        {
            xSquared += (num * num);
        }

        return xSquared;
    }

    
    public static double ComputeSquaredSum(List<double> x, List<double> y)
    {
        double squared = 0;
        for (int i = 0; i < x.Count; i++)
        {
            squared += (x[i] * y[i]);
        }

        return squared;
    }
    
    public static double ComputeSlope(int size, double xSum, double ySum, double xySum, double xSquared)
    {
        return (((size * xySum) - (xSum * ySum)) / ((size * xSquared) - (xSum * xSum)));
    }

    public static double ComputeIntercept(int size, double slope, double xSum, double ySum)
    {
        return ((ySum - (slope * xSum)) / size);
    }

    public static string ComputeLinearEquation(List<double> x, List<double> y)
    {
        //find the slope
        double xSum = ComputeSum(x);
        double ySum = ComputeSum(y);

        double xSquared = ComputeSquaredSum(x);

        double xySum = ComputeSquaredSum(x, y);
        

        int size = x.Count;

        double slope = ComputeSlope(size, xSum, ySum, xySum, xSquared);
        double intercept = ComputeIntercept(size, slope, xSum, ySum);
        return "y = " + slope + "x" + " + " + intercept;
    }
}