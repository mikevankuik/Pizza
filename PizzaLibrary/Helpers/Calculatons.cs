namespace PizzaLibrary.Helpers;

public static class Calculatons
{
    public static double Surface(double radius)
    {
        double something = (radius / 2);
        return  Math.PI * (something*something);
    }

    public static decimal PricePerSquareArea(decimal price, decimal surface)
    {
        decimal result = (surface < 1 || price < 0.01M) ? 0 : price / surface;
        return result;
    }
}
