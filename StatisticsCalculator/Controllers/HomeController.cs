using Microsoft.AspNetCore.Mvc;
using StatisticsCalculator.Models;
using System.Diagnostics;
using LogicModule;

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

        // [HttpPost]
        // public IActionResult Clear(MeanCalculatorModel model)
        // {
        //     
        // }
        // This method will be called when a form is submitted
        [HttpPost]
        public IActionResult Calculate(MeanCalculatorModel model, string operation)
        {
            if (!string.IsNullOrEmpty(model.Values))
            {
                // Parse the numbers from the input
                var numbers1 = ParseNumbers(model.Values);
                List<double> numbers2 = ParseNumbersOneLine(model.Values);

                // if (!(numbers1.Any() || numbers1.Any()))
                // {
                //     ModelState.AddModelError("", "Please enter valid numbers.");
                //     return View("Index", model);
                // }

                // if (numbers2.Count < 3 )
                // {
                //     ModelState.AddModelError("", "Please enter only 3 numbers on one line.");
                //     return View("Index", model);
                // }

                // Perform the selected operation
                switch (operation)
                {
                    case "ssd":
                        model.Result =
                            $"Sample Standard Deviation:\n{LogicModule.Statistics.ComputeSampleStandardDeviation(numbers1)}";
                        break;
                    case "psd":
                        model.Result =
                            $"Population Standard Deviation:\n{LogicModule.Statistics.ComputePopulationStandardDeviation(numbers1)}";
                        break;
                    case "mean":
                        model.Label = $"Mean:";
                        model.Result = $"{LogicModule.Statistics.CalculateMean(numbers1)}";
                        break;
                    case "zScore":
                        model.Result = 
                            $"Z Score:\n{LogicModule.Statistics.ComputeZScore(numbers2)}";
                        break;
                    case "getY":
                        model.Result = 
                            $"Value of Y:\n{LogicModule.LinearRegression.ComputeForYLinearRegression(numbers2)}";
                        break;
                    // case "clear":
                    //     model.Result = $"Hi";
                    //     break;
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
            List<double> test = values.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.TryParse(s, out double n) ? n : (double?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();
            Console.WriteLine(test[0]);
            return values.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.TryParse(s, out double n) ? n : (double?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();
        }
        private List<double> ParseNumbersOneLine(string values)
        {
            return values.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.TryParse(s, out double n) ? n : (double?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();
        }



    }
}

//The right way to do it (from how he explains it) is to basically make the logicModule, integrate it
// with your web ui and then finally use playwright to help you write the tests

//I set up the web ui so now I am implememnting and connecting the logic to the UI and then after make the test
// for it
