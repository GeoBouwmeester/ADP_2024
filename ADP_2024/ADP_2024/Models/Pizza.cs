using System.Diagnostics.CodeAnalysis;

namespace ADP_2024.Models;

public class Pizza(string pizzaName, int numberOfSlices)
{
    public string PizzaName => pizzaName;
    public int NumberOfSlices => numberOfSlices;
}

public class PizzaComparer : IEqualityComparer<Pizza>
{
    public bool Equals(Pizza? x, Pizza? y)
    {
        return x?.PizzaName == y?.PizzaName && x?.NumberOfSlices == y?.NumberOfSlices;
    }

    public int GetHashCode([DisallowNull] Pizza obj)
    {
        return obj.PizzaName.GetHashCode() ^ obj.NumberOfSlices.GetHashCode();
    }
}