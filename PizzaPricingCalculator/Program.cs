using PizzaLibrary.Models;
using PizzaPricingCalculator.Helpers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool morePizza = true;
List<PizzaModel> pizzaList = new();
int i = 0;

// Welcome the user
Console.WriteLine("Welcome to the Pizza Price Calculator");

// Get configuration
var config = FileManagement.GetConfiguration("");
string metric = config.GetValue(0).ToString();
string currency = config.GetValue(1).ToString();
var pizzaFile = FileManagement.GetPizzaList("pizzalist.txt");
// Print out results
var pizzaQuestion = ConsoleQuestionair.PizzaDetails(morePizza, metric);
pizzaList.AddRange(pizzaFile);
pizzaList.AddRange(pizzaQuestion);
foreach (var pizza in pizzaList)
{
    i++;
    Console.WriteLine($"{i}: {pizza.Diameter} {metric} | {currency} {pizza.Price} | Pizza Surface Area {pizza.Surface} Square {metric} | Price Per Surface Area: {currency} {pizza.PPSA}");
}
