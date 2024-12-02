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
}