namespace ADP_2024.QuickSort;

	public static class QuickSortAlgorithm<T> where T : IComparable<T>
	{
		public static void Quicksort(T[] array, int left, int right)
		{
			if (left >= right)
				return;

			int i = left;
			int j = right;
			
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
				Quicksort(array, left, j);
			if (i < right)
				Quicksort(array, i, right);
		}

		private static T MedianOfThree(T[] array, int left, int mid, int right)
		{
			T a = array[left];
			T b = array[mid];
			T c = array[right];

			
			if ((a.CompareTo(b) > 0) ^ (a.CompareTo(c) > 0))
				return a;
			else if ((b.CompareTo(a) > 0) ^ (b.CompareTo(c) > 0))
				return b;
			else
				return c;
		}

		private static void Swap(T[] array, int i, int j)
		{
			T temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
