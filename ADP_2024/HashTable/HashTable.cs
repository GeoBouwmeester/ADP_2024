namespace ADP_2024.HashTable
{
	public class HashTable<Key, Value>
	{
		private struct Bucket
		{
			public Key Key;
			public Value Value;
			public bool IsOccupied;
			public bool IsDeleted;
		}

		private Bucket[] buckets;
		private int _capacity;
		private int _count;

		private const double LoadFactor = 0.75;

		public HashTable(int initialCapacity = 16)
		{
			_capacity = initialCapacity;
			buckets = new Bucket[_capacity];
			_count = 0;
		}

		private int Hash(Key key)
		{
			return (key.GetHashCode() & 0x7FFFFFFF) % _capacity;
		}

		public void Insert(Key key, Value value)
		{
			if (_count >= _capacity * LoadFactor)
			{
				Resize();
			}

			int index = FindBucket(key);
			if (index == -1) // Bucket is empty or deleted
			{
				// Find an available slot for insertion
				for (int i = 0; i < _capacity; i++)
				{
					int newIndex = (Hash(key) + i) % _capacity;
					if (!buckets[newIndex].IsOccupied || buckets[newIndex].IsDeleted)
					{
						if (!buckets[newIndex].IsOccupied) _count++; 
						buckets[newIndex].Key = key;
						buckets[newIndex].Value = value;
						buckets[newIndex].IsOccupied = true;
						buckets[newIndex].IsDeleted = false;

						return;
					}
				}
			}
			else // Update the value if the key already exists
			{
				buckets[index].Value = value;
			}
		}

		public Value Get(Key key)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			int index = FindBucket(key);
			if (index != -1)
			{
				if (buckets[index].IsDeleted)
				{
					throw new KeyNotFoundException($"Key '{key}' not found.");
				}
				return buckets[index].Value;
			}

			throw new KeyNotFoundException($"Key '{key}' not found.");
		}

		public bool Delete(Key key)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			int index = FindBucket(key);
			if (index != -1)
			{
				buckets[index].IsDeleted = true;
				buckets[index].IsOccupied = false;
				_count--;
				return true;
			}

			return false;
		}

		public bool Update(Key key, Value newValue)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			int index = FindBucket(key);
			if (index != -1)
			{
				buckets[index].Value = newValue;
				return true;
			}

			return false; 
		}

		private void Resize()
		{
			int newCapacity = _capacity * 2;
			var newBuckets = new Bucket[newCapacity];
			var oldBuckets = buckets;

			buckets = newBuckets;
			_capacity = newCapacity;
			_count = 0;

			foreach (var bucket in oldBuckets)
			{
				if (bucket.IsOccupied && !bucket.IsDeleted)
				{
					Insert(bucket.Key, bucket.Value);
				}
			}
		}

		private int FindBucket(Key key)
		{
			int hash = Hash(key);
			for (int i = 0; i < _capacity; i++)
			{
				int index = (hash + i) % _capacity;

				if (!buckets[index].IsOccupied)
				{
					return -1; // Return -1 if bucket is empty
				}

				if (buckets[index].IsOccupied && !buckets[index].IsDeleted && buckets[index].Key.Equals(key))
				{
					return index; // Return index of the found bucket
				}
			}

			return -1; // Return -1 if the key was not found
		}

		public void Print()
		{
			for (int i = 0; i < _capacity; i++)
			{
				if (buckets[i].IsOccupied && !buckets[i].IsDeleted)
				{
					Console.WriteLine($"Index {i}: {buckets[i].Key} -> {buckets[i].Value}");
				}
				else
				{
					Console.WriteLine($"Index {i}: Empty");
				}
			}
		}

		public int Size()
		{
			return _count; 
		}
	}
}