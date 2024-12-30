namespace ADP_2024.SelectionSort;

public class SelectionSortAlgorithm
{
    public static void SelectionSort<T>(T[] array) where T : IComparable<T>
    {
        int length = array.Length;
        
        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;
            
            for (int j = i + 1; j < length; j++)
            {
                if (array[j].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            T temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }
}
