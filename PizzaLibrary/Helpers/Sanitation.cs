﻿namespace PizzaLibrary.Helpers;

public static class Sanitation
{
    public static string ReplaceDotWithComma(string input)
    {
        return input.Replace(".", ",");
    }
    public static string ReplaceCommaWithDot(string input)
    {
        return input.Replace(",", ".");
    }
}
