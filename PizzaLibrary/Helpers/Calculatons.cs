namespace PizzaLibrary.Helpers;

public static class Calculatons
{
    public static double Surface(double diameter)
    {
        double radius = (diameter / 2);
        return  Math.PI * (radius*radius);
    }

    public static decimal PricePerSquareArea(decimal price, decimal surface)
    {
        decimal result = (surface < 1 || price < 0.01M) ? 0 : price / surface;
        return result;
    }
}
