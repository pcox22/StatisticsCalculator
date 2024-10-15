using Microsoft.AspNetCore.Mvc;
using StatisticsCalculator.Models;

namespace StatisticsCalculator.Controllers;

public class StatisticsController : Controller
{
// Display the form
    // [HttpGet]
    // public IActionResult Index()
    // {
    //     return View();
    // }

    // Handle form submission and calculate mean
    public static double CalculateMean(List<double> valuesList)
    {
        int sumAccumulator = 0;
        if (valuesList.Count== 0)
        {
            //should throw an error
            throw new ArgumentException("valuesList parameter cannot be null or empty");
            Console.WriteLine("valuesList parameter cannot be null or empty");
        }

        foreach (int value in valuesList)
        {
            sumAccumulator = sumAccumulator + value;
        }

        // # Return the average (sum divided by the number of values we accumulated)
        return ((double)sumAccumulator / valuesList.Count);
    }
    
}