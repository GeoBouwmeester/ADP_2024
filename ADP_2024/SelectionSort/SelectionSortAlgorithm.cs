namespace ADP_2024.SelectionSort;

public class SelectionSortAlgorithm
{
    public static void SelectionSort<T>(T[] array) where T : IComparable<T>
    {
        int length = array.Length;
        
        for (int i = 0; i < length - 1; i++)
        {
            // Find the index of the minimum element in the unsorted part of the array
            int minIndex = i;
            
            for (int j = i + 1; j < length; j++)
            {
                if (array[j].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

           // Swap the found minimum element with the first element of the unsorted part
           Swap(ref array[minIndex], ref array[i]);
        }
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        var temp = a;

        a = b;

        b = temp;
    }
}
