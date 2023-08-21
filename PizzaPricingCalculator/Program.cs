using PizzaPricingCalculator.Helpers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool morePizza = true;

// Welcome the user
Console.WriteLine("Welcome to the Pizza Price Calculator");

// Get configuration
var config = FileManagement.GetConfiguration("");
string metric = config.GetValue(0).ToString();
string currency = config.GetValue(1).ToString();

// Print out results
ConsoleQuestionair.PizzaDetails(morePizza, metric, currency);