namespace ADP_2024.Stack;

public class AStack<T>
{
    private T[] _items;
    private const int DefaultCapacity = 10;
    private int _maxSize;
    private int _top;

    public AStack(int capacity = DefaultCapacity)
    {
        _maxSize = capacity;
        _items = new T[capacity];
        _top = -1;
    }

    public bool Push(T item)
    {
        // If the array is full, double the capacity
        if (_top == _maxSize - 1)
        {
            _maxSize *= 2;

            T[] newItems = new T[_maxSize];

            // Copy existing elements to the new array
            for (int i = 0; i < _top; i++)
            {
                newItems[i] = _items[i];
            }

            // Replace old array with new array
            _items = newItems;
        }

        _items[++_top] = item;

        return true;
    }

    public T? Pop()
    {
        if (_top == -1) throw new InvalidOperationException("No item to pop.");

        var item = _items[_top--];

        // If the array is underutilized (25% or less), shrink it
        if (_top > 0 && _top == _maxSize / 4)
        {
            // Resize to half current size
            _maxSize /= 2;

            T[] newItems = new T[_maxSize];

            // Copy existing elements to the new array
            for (int i = 0; i < _top; i++)
            {
                newItems[i] = _items[i];
            }

            // Replace old array with new array
            _items = newItems;
        }

        return item;
    }

    public T? TopValue()
    {
        if (_top == -1) throw new InvalidOperationException("Stack is empty.");

        return _items[_top];
    }

    public int Size()
    {
        return _top + 1;
    }
}

