using PizzaLibrary.Helpers;
using PizzaLibrary.Models;

namespace PizzaPricingCalculator.Helpers;

public static class ConsoleQuestionair
{
    public static void PizzaDetails(bool morePizza, string metric, string currency)
    {
        List<PizzaModel> pizzaList = new();
        // Ask for to enter the size of the pizza and the price
        // Ask if there is another pizza until the user says no
        // Then calculate for each pizza the price per sqare cm / inch 
        int i = 0;
        while (morePizza == true)
        {
            i++;
            string? pizzaSize = Questionnaire.Question($"How big is the pizza? (diameter in {metric})", "1");
            pizzaSize = Sanitation.ReplaceDotWithComma(pizzaSize);
            _ = double.TryParse(pizzaSize, out double sizeResult);

            string? pizzaPrice = Questionnaire.Question("What does it cost?", "1");
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
            Console.WriteLine($"{pizza.Number}: {pizza.Diameter} {metric} | {currency} {pizza.Price} | Pizza Surface Area {pizza.Surface} Square {metric} | Price Per Surface Area: {currency} {pizza.PPSA}");
        }
    }
}
