namespace ADP_2024.DynamicArray;

public class DynamicArray<T> where T : IComparable<T>
{
    private T[] _items;
    private const int DefaultCapacity = 4;
    private int _maxSize;
    private int _size;

    public DynamicArray(int capacity = DefaultCapacity)
    {
        _maxSize = capacity;
        _items = new T[_maxSize];
        _size = 0;
    }

    public int Count => _size;

    public void Add(T item)
    {
        // If the array is full, double the capacity
        if (_size == _maxSize)
        {
            _maxSize *= 2;

            T[] newItems = new T[_maxSize];

            // Copy existing elements to the new array
            for (int i = 0; i < _size; i++)
            {
                newItems[i] = _items[i];
            }

            // Replace old array with new array
            _items = newItems;
        }

        _items[_size] = item;

        _size++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));

        return _items[index];
    }

    public void Set(int index, T item)
    {
        if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));

        _items[index] = item;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        // Shift all elements
        for (int i = index; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        // Nullify last element
        _items[_size - 1] = default!;

        // Decrement size
        _size--;

        // If the array is underutilized (25% or less), shrink it
        if (_size > 0 && _size == _maxSize / 4)
        {
            // Resize to half current size
            _maxSize /= 2;

            T[] newItems = new T[_maxSize];

            // Copy existing elements to the new array
            for (int i = 0; i < _size; i++)
            {
                newItems[i] = _items[i];
            }

            // Replace old array with new array
            _items = newItems;
        }
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            // Reuse the `Remove` method
            Remove(index);

            // Successfully removed the element
            return true;
        }

        // Element not found
        return false;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            var x = _items[i];

            if (x.CompareTo(item) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }

        return -1;
    }
}
