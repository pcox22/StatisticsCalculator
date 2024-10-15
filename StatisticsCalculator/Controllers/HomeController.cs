using Microsoft.AspNetCore.Mvc;
using StatisticsCalculator.Models;
using System.Diagnostics;
using StatisticsCalculator;

namespace StatisticsCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Show the initial form when the page loads
        public IActionResult Index()
        {
            var model = new MeanCalculatorModel();
            return View(model);  // Pass an empty model to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // This method will be called when a form is submitted
        [HttpPost]
        public IActionResult Calculate(MeanCalculatorModel model, string operation)
        {
            if (!string.IsNullOrEmpty(model.Values))
            {
                // Parse the numbers from the input
                var numbers = ParseNumbers(model.Values);

                if (!numbers.Any())
                {
                    ModelState.AddModelError("", "Please enter valid numbers.");
                    return View("Index", model);
                }

                // Perform the selected operation
                switch (operation)
                {
                    case "mean":
                        model.Result = $"Mean: {StatisticsController.CalculateMean(numbers)}";
                        break;
                    case "sum":
                        model.Result = $"Sum: {CalculateSum(numbers)}";
                        break;
                    case "count":
                        model.Result = $"Count: {CalculateCount(numbers)}";
                        break;
                    default:
                        ModelState.AddModelError("", "Unknown operation.");
                        break;
                }
            }
            else
            {
                ModelState.AddModelError("", "Input cannot be empty.");
            }

            // Return the updated model with the result to the view
            return View("Index", model);
        }

        // Parse input values and convert them to a list of numbers
        private List<double> ParseNumbers(string values)
        {
            return values.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.TryParse(s, out double n) ? n : (double?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();
        }

        // Method to calculate the mean
        // private double CalculateMean(List<double> valuesList)
        // {
        //     int sumAccumulator = 0;
        //     if (valuesList.Count== 0)
        //     {
        //         //should throw an error
        //         throw new ArgumentException("valuesList parameter cannot be null or empty");
        //         Console.WriteLine("valuesList parameter cannot be null or empty");
        //     }
        //
        //     foreach (int value in valuesList)
        //     {
        //         sumAccumulator = sumAccumulator + value;
        //     }
        //
        //     // # Return the average (sum divided by the number of values we accumulated)
        //     return ((double)sumAccumulator / valuesList.Count);
        // }

        // Method to calculate the sum
        private double CalculateSum(List<double> numbers)
        {
            return numbers.Sum();
        }

        // Method to count the numbers
        private int CalculateCount(List<double> numbers)
        {
            return numbers.Count;
        }
    }
}
