using PizzaLibrary.Helpers;
using PizzaLibrary.Models;

namespace PizzaPricingCalculator.Helpers
{
    public static class FileManagement
    {
        public static string[] GetConfiguration(string? defaultPath)
        {
            if (string.IsNullOrEmpty(defaultPath))
            {
                defaultPath = @"config.ini";
            }

            if (File.Exists(defaultPath))
            {
                var result = File.ReadAllLines(defaultPath);
                return result;
            }
            else
            {
                string? metericType = Questionnaire.Question("Will you be using the metic or the imperial system? (M for Meteric I for Imperial)", "M");
                string metric = metericType == "I" ? "Inch" : "CM";
                Console.WriteLine($"{metric} will be used");

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
                Console.WriteLine($"{currency} will be used");

                string[] config = { metric, currency };
                File.WriteAllLines(defaultPath, config);

                string[] result = { metric, currency };
                return result;
            }
        }

        public static List<PizzaModel> GetPizzaList(string? defaultPath)
        {
            List<PizzaModel> result = new();
            if (File.Exists(defaultPath))
            {
                string getPizzaList = Questionnaire.Question("Would you like to add a pizza list file? (Y/N)", "N");
                getPizzaList = getPizzaList.ToUpper();
                if (getPizzaList == "Y")
                {
                    var lines = File.ReadAllLines(defaultPath).ToList();
                    foreach (var line in lines)
                    {
                        var record = line.Split(';');
                        _ = double.TryParse(record[0], out double diameter);
                        
                        _ = decimal.TryParse(Sanitation.ReplaceCommaWithDot(record[1]), out decimal price);

                        string surfaceCalculation = Calculatons.Surface(diameter).ToString();
                        _ = decimal.TryParse(surfaceCalculation, out decimal surface);
                        Calculatons.PricePerSquareArea(price, surface);
                        result.Add(
                            new PizzaModel()
                            {
                                Diameter = diameter
                                ,
                                Price = price
                                ,
                                Surface = surface
                                ,
                                PPSA = Calculatons.PricePerSquareArea(price, surface)

                            }); 
                    }
                }
            }
            return result;
        }
    }
}