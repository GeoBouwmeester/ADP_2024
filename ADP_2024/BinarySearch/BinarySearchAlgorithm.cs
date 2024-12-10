namespace ADP_2024.BinarySearch;

public class BinarySearchAlgorithm
{
    public static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Check if target is at mid
            if (array[mid] == target)
            {
                return mid;
            }

            // If target is greater, ignore left half
            if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                // If target is smaller, ignore right half
                right = mid - 1;
            }
        }

        // Target not found
        return -1;
    }
}