namespace ADP_2024.SortingAlgorithms
{ 
	public class QuickSort
	{
		public void QuicksortAlgorithm<T>(T[] array, int left, int right) where T : IComparable<T>
		{
			if (left >= right)
				return;

			int i = left;
			int j = right;

			// Determine the pivot using the median of three
			int mid = left + (right - left) / 2;
			T pivot = MedianOfThree(array, left, mid, right);

			while (i <= j)
			{
				while (array[i].CompareTo(pivot) < 0)
					i++;

				while (array[j].CompareTo(pivot) > 0)
					j--;

				if (i <= j)
				{
					Swap(array, i, j);
					i++;
					j--;
				}
			}

			if (left < j)
				QuicksortAlgorithm(array, left, j);

			if (i < right)
				QuicksortAlgorithm(array, i, right);
		}

		public T MedianOfThree<T>(T[] array, int left, int mid, int right) where T : IComparable<T>
		{
			T a = array[left];
			T b = array[mid];
			T c = array[right];

			// Compare and find the median value
			if ((a.CompareTo(b) > 0) ^ (a.CompareTo(c) > 0))
				return a; // a is the median
			else if ((b.CompareTo(a) > 0) ^ (b.CompareTo(c) > 0))
				return b; // b is the median
			else
				return c; // c is the median
		}

		public void Swap<T>(T[] array, int i, int j)
		{
			T temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}