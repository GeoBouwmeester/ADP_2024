namespace ADP_2024.SortingAlgorithms
{
	public class ParallelMergeSort<T> where T : IComparable<T>
	{
		private readonly int _threshold;

		public ParallelMergeSort(int threshold = 5000)
		{
			_threshold = threshold;
		}

		public void Sort(T[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array));
			}

			var temp = new T[array.Length];
			ParallelMergeSortAlgorithm(array, 0, array.Length - 1, temp);
		}

		private void ParallelMergeSortAlgorithm(T[] array, int left, int right, T[] temp)
		{
			if (left < right)
			{
				int mid = (left + right) / 2;

				if (right - left < _threshold)
				{
					// Merge Sort for small arrays
					MergeSort(array, left, mid, temp);
					MergeSort(array, mid + 1, right, temp);
				}
				else
				{
					// Parallel for large arrays
					Parallel.Invoke(
						() => ParallelMergeSortAlgorithm(array, left, mid, temp),
						() => ParallelMergeSortAlgorithm(array, mid + 1, right, temp)
					);
				}

				Merge(array, left, mid, right, temp);
			}
		}

		private void MergeSort(T[] array, int left, int right, T[] temp)
		{
			if (left < right)
			{
				int mid = (left + right) / 2;
				MergeSort(array, left, mid, temp);
				MergeSort(array, mid + 1, right, temp);
				Merge(array, left, mid, right, temp);
			}
		}

		private void Merge(T[] array, int left, int mid, int right, T[] temp)
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
			//while (i <= mid || j <= right)
			//{
			//	temp[k++] = (i <= mid) ? array[i++] : array[j++];
			//}

			while (i <= mid)
				temp[k++] = array[i++];

			while (j <= right)
				temp[k++] = array[j++];

			for (i = left; i <= right; i++)
				array[i] = temp[i];
		}
	}
}
