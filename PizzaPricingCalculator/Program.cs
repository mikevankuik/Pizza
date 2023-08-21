using PizzaLibrary.Helpers;
using PizzaPricingCalculator.Helpers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool morePizza = true;
//List<PizzaModel> pizzaList = new();

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
ConsoleQuestionair.PizzaDetails(morePizza, metric, currency);