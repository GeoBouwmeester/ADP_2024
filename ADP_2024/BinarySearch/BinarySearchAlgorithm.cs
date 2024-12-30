namespace ADP_2024.BinarySearch;

public class BinarySearchAlgorithm
{
    public static int BinarySearch<T>(T[] array, T target) where T : IComparable<T>
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid].CompareTo(target) == 0)
            {
                return mid;
            }

            if (array[mid].CompareTo(target) < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}