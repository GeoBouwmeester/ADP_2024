namespace ADP_2024.Models;

public class Pizza(string pizzaName, int numberOfSlices) : IComparable<Pizza>
{
    public string PizzaName => pizzaName;
    public int NumberOfSlices => numberOfSlices;

    public int CompareTo(Pizza? other)
    {
        if (other == null) return 1;

        if (PizzaName == other.PizzaName)
        {
            return NumberOfSlices == other.NumberOfSlices
                ? 0
                : NumberOfSlices < other.NumberOfSlices
                ? -1
                : 1;
        }
        else
        {
            return PizzaName.CompareTo(other.PizzaName) > 0 ? 1 : -1;
        }
    }
}