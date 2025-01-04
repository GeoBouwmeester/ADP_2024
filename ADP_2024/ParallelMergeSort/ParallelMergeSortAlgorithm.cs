namespace ADP_2024.ParallelMergeSort;

	public static class ParallelMergeSortAlgorithm<T> where T : IComparable<T>
	{
		private static int threshold = 5000;

		public static void SetThreshold(int newThreshold)
		{
			threshold = newThreshold;
		}

		public static void Sort(T[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array));
			}
			var temp = new T[array.Length];
			ParallelMergeSort(array, 0, array.Length - 1, temp);
		}

		private static void ParallelMergeSort(T[] array, int left, int right, T[] temp)
		{
			if (left < right)
			{
				int mid = (left + right) / 2;
				if (right - left < threshold)
				{
					// Merge Sort for small arrays
					MergeSort(array, left, mid, temp);
					MergeSort(array, mid + 1, right, temp);
				}
				else
				{
					// Parallel for large arrays
					Parallel.Invoke(
						() => ParallelMergeSort(array, left, mid, temp),
						() => ParallelMergeSort(array, mid + 1, right, temp)
					);
				}
				Merge(array, left, mid, right, temp);
			}
		}

		private static void MergeSort(T[] array, int left, int right, T[] temp)
		{
			if (left < right)
			{
				int mid = (left + right) / 2;
				MergeSort(array, left, mid, temp);
				MergeSort(array, mid + 1, right, temp);
				Merge(array, left, mid, right, temp);
			}
		}

		private static void Merge(T[] array, int left, int mid, int right, T[] temp)
		{
			int i = left;
			int j = mid + 1;
			int k = left;

			while (i <= mid && j <= right)
			{
				if (array[i].CompareTo(array[j]) <= 0)
					temp[k++] = array[i++];
				else
					temp[k++] = array[j++];
			}

		while (i <= mid)
				temp[k++] = array[i++];
			while (j <= right)
				temp[k++] = array[j++];

			for (i = left; i <= right; i++)
				array[i] = temp[i];
	}
}
