namespace ADP_2024.Models;

public class Pizza(string pizzaName, int numberOfSlices) : IComparable<Pizza>
{
    public string PizzaName => pizzaName;
    public int NumberOfSlices => numberOfSlices;

    public int CompareTo(Pizza? other)
    {
        return PizzaName == other?.PizzaName && NumberOfSlices == other?.NumberOfSlices ? 0 : NumberOfSlices > other?.NumberOfSlices ? 1 : -1;
    }
}