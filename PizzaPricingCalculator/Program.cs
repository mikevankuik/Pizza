using PizzaPricingCalculator.Models;
using PizzaPricingCalculator.Helpers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool morePizza = true;
List<PizzaModel> pizzaList = new();

// Welcome the user
Console.WriteLine("Welcome to the Pizza Price Calculator");
// Set Inches or CM
string? metericType = Questionnaire.Question("Will you be using the metic or the imperial system? (M for Meteric I for Imperial)","M");
string metric = metericType == "I" ? "Inch" : "CM";
Console.WriteLine($"{ metric } will be used");

// Set Euro, Dollar or Pound
string? currencyType = Questionnaire.Question("What currency do you use ? (E for Euro, D for Dollar P for Pound)", "E");

string currency = string.Empty;
switch (currencyType)
{
    case "E": currency = "€"; break;
    case "D": currency = "$"; break;
    case "P": currency = "£"; break;
    default: currency = "€"; break;
}
Console.WriteLine($"{ currency } will be used");

// Ask for to enter the size of the pizza and the price
// Ask if there is another pizza until the user says no
// Then calculate for each pizza the price per sqare cm / inch 
int i = 0;
while (morePizza == true)
{
    i++;
    string? pizzaSize = Questionnaire.Question($"How big is the pizza? (diameter in { metric })", "1");
    pizzaSize = Sanitation.ReplaceDotWithComma(pizzaSize);
    _ = double.TryParse(pizzaSize, out double sizeResult);

    string? pizzaPrice = Questionnaire.Question("What does it cost?","1");
    pizzaPrice = Sanitation.ReplaceDotWithComma(pizzaPrice);
    _ = decimal.TryParse(pizzaPrice, out decimal priceResult);

    double pizzaSurface = Calculatons.Surface(sizeResult);
    decimal surfaceResult = (decimal)pizzaSurface;

    pizzaList.Add(new PizzaModel() { Number = i, Diameter = sizeResult, Price = priceResult, Surface = surfaceResult, PPSA = Calculatons.PricePerSquareArea(priceResult, surfaceResult) });
    string morePizzaQuestion = Questionnaire.Question("Would you like to add another pizza to compare? (Y/N)", "Y");
    morePizza = morePizzaQuestion == "N" || morePizzaQuestion == "n" ? false : true;
}

foreach (var pizza in pizzaList)
{
    Console.WriteLine($"{ pizza.Number }: { pizza.Diameter } { metric } | {currency} { pizza.Price } | Pizza Surface Area { pizza.Surface } Square { metric } | Price Per Surface Area: { currency } { pizza.PPSA }");
}