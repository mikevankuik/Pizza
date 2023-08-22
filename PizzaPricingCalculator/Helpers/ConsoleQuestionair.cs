using PizzaLibrary.Helpers;
using PizzaLibrary.Models;

namespace PizzaPricingCalculator.Helpers;

public static class ConsoleQuestionair
{
    public static List<PizzaModel> PizzaDetails(bool morePizza, string metric)
    {
        List<PizzaModel> pizzaList = new();
        // Ask for to enter the size of the pizza and the price
        // Ask if there is another pizza until the user says no
        // Then calculate for each pizza the price per sqare cm / inch 

        while (morePizza == true)
        {
            string morePizzaQuestion = Questionnaire.Question("Would you like to add another pizza to compare? (Y/N)", "Y");
            morePizza = morePizzaQuestion == "N" || morePizzaQuestion == "n" ? false : true;
            if (morePizza == false) 
            { 
                return pizzaList;
            }
            string? pizzaSize = Questionnaire.Question($"How big is the pizza? (diameter in {metric})", "1");
            pizzaSize = Sanitation.ReplaceDotWithComma(pizzaSize);
            _ = double.TryParse(pizzaSize, out double sizeResult);

            string? pizzaPrice = Questionnaire.Question("What does it cost?", "1");
            pizzaPrice = Sanitation.ReplaceCommaWithDot(pizzaPrice);
            _ = decimal.TryParse(pizzaPrice, out decimal priceResult);

            double pizzaSurface = Calculatons.Surface(sizeResult);
            decimal surfaceResult = (decimal)pizzaSurface;

            pizzaList.Add(new PizzaModel() { Diameter = sizeResult, Price = priceResult, Surface = surfaceResult, PPSA = Calculatons.PricePerSquareArea(priceResult, surfaceResult) });
        }
        return pizzaList;
    }
}
