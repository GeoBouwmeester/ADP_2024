namespace ADP_2024.HashTable
{
	public class HashTable<K, V> 
	{
		private class Entry 
		{ 
			public K Key { get; set; }
			public V Value { get; set; }
			public bool IsDeleted { get; set; }
			public Entry(K key, V value) 
			{
				Key = key;
				Value = value;
				IsDeleted = false;
			}
		}

		private Entry[] table;
		private int size;
		private int capacity;

		public HashTable(int capacity = 16) 
		{
			this.capacity = capacity;
			table = new Entry[capacity];
			size = 0;
		}

		private int Hash(K key)
		{
			int hash = key.GetHashCode() % capacity;
			return hash < 0 ? hash + capacity : hash; 
		}

		public void Insert(K key, V value) 
		{
			if (size >= capacity / 2) // Load factor > 0.5, resize the table
			{
				Resize();
			}

			int index = Hash(key);
			while (table[index] != null && !table[index].IsDeleted && !table[index].Key.Equals(key))
			{
				index = (index + 1) % capacity; // Linear probing
			}

			if (table[index] == null || table[index].IsDeleted)
			{
				size++;
			}

			table[index] = new Entry(key, value);
		}

		public V Get (K key) 
		{
			int index = Hash(key);
			int start = index; 

			while (table[index] != null)
			{
				if (!table[index].IsDeleted && table[index].Key.Equals(key))
				{
					return table[index].Value;
				}

				index = (index + 1) % capacity;
				if (index == start) break; 
			}

			throw new KeyNotFoundException("Key not found in hash table.");
		}
		public void Delete(K key)
		{
			int index = Hash(key);
			int start = index;

			while (table[index] != null)
			{
				if (!table[index].IsDeleted && table[index].Key.Equals(key))
				{
					table[index].IsDeleted = true;
					size--;
					return;
				}

				index = (index + 1) % capacity;
				if (index == start) break;
			}

			throw new KeyNotFoundException("Key not found in hash table.");
		}
		private void Resize()
		{
			int newCapacity = capacity * 2;
			Entry[] oldTable = table;
			table = new Entry[newCapacity];
			capacity = newCapacity;
			size = 0;

			foreach (var entry in oldTable)
			{
				if (entry != null && !entry.IsDeleted)
				{
					Insert(entry.Key, entry.Value);
				}
			}
		}

		public void Update(K key, V newValue)
		{
			int index = Hash(key);
			int start = index;

			while (table[index] != null)
			{
				if (!table[index].IsDeleted && table[index].Key.Equals(key))
				{
					table[index].Value = newValue;
					return;
				}
				index = (index + 1) % capacity;
				if (index == start) break; 
			}
			throw new KeyNotFoundException("Key not found in hash table.");
		}
		public int Size()
		{
			return size;
		}
		public bool isEmpty()
		{
			return Size() == 0;
		}
		public void Print()
		{
			for (int i = 0; i < capacity; i++)
			{
				if (table[i] != null && !table[i].IsDeleted)
				{
					Console.WriteLine($"Index {i}: Key = {table[i].Key}, Value = {table[i].Value}");
				}
			}
		}
	}
}
