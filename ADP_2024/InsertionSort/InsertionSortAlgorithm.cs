namespace ADP_2024.InsertionSort;

public class InsertionSortAlgorithm
{
    public static void InsertionSort<T>(T[] array) where T : IComparable<T>
    {
        for (int i = 1; i < array.Length; i++)
        {
            var toBeInserted = array[i];

            int j = i;

            while (j > 0 && toBeInserted.CompareTo(array[j - 1]) < 0)
            {
                array[j] = array[j - 1];

                j--;
            }

            array[j] = toBeInserted;
        }
    }
}