namespace PizzaPricingCalculator.Helpers;

public static class Questionnaire
{
    // Take in the question as a string
    // Return the answer as a string
    public static string Question(string question,string? defaultAnswer)
    {
        string? result = "";
        bool quit = string.IsNullOrEmpty(question) ? false:true;

        while (quit)
        {
            Console.WriteLine(question);
            result = Console.ReadLine();
            if (string.IsNullOrEmpty(result))
            {
                result = defaultAnswer;
            }
            return result;
        }
        return result;
    }
}
