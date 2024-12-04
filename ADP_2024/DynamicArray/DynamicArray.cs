namespace ADP_2024.DynamicArray;

public class DynamicArray<T> where T : IComparable<T>
{
    private T[] _items;
    private int _maxSize;
    private int _size;
    private const int DefaultCapacity = 4;
    private const int ResizeFactor = 2;

    public DynamicArray(int capacity = DefaultCapacity)
    {
        _maxSize = capacity;
        _items = new T[_maxSize];
        _size = 0;
    }

    public int Count => _size;
    private bool ArrayIsUnderutilized => _size > 0 && _size == _maxSize / 4;
    private bool IndexOutOfBounds(int index) => index < 0 || index >= _size;

    public void Add(T item)
    {
        if (_size == _maxSize) Grow();

        _items[_size] = item;

        _size++;
    }

    private void Grow()
    {
        _maxSize *= ResizeFactor;

        T[] newItems = new T[_maxSize];

        for (int i = 0; i < _size; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }

    public T Get(int index)
    {
        if (IndexOutOfBounds(index)) 
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        return _items[index];
    }

    public void Set(int index, T item)
    {
        if (IndexOutOfBounds(index)) 
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        _items[index] = item;
    }

    public void Remove(int index)
    {
        if (IndexOutOfBounds(index)) 
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        for (int i = index; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size - 1] = default!;

        _size--;

        if (ArrayIsUnderutilized) Shrink();
    }

    private void Shrink()
    {
        _maxSize /= ResizeFactor;

        T[] newItems = new T[_maxSize];

        for (int i = 0; i < _size; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            Remove(index);

            return true;
        }

        return false;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_items[i].CompareTo(item) == 0) return true;
        }

        return false;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_items[i].CompareTo(item) == 0) return i;
        }

        return -1;
    }
}
