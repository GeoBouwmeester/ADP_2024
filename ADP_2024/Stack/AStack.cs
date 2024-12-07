namespace ADP_2024.Stack;

public class AStack<T>
{
    private T[] _items;
    private int _maxSize;
    private int _top;
    private const int DefaultCapacity = 4;
    private const int ResizeFactor = 2;

    public AStack(int capacity = DefaultCapacity)
    {
        _maxSize = capacity;
        _items = new T[capacity];
        _top = -1;
    }

    public int Size => _top + 1;
    public bool IsEmpty => _top == -1;
    public bool IsUnderutilized => _top > 0 && _top == _maxSize / 4;
    private bool IsFull => _top == _maxSize - 1;

    public bool Push(T item)
    {
        if (IsFull) { _maxSize *= ResizeFactor; Resize(); }

        _items[++_top] = item;

        return true;
    }

    private void Resize()
    {
        T[] newItems = new T[_maxSize];

        for (int i = 0; i <= _top; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }

    public T? Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("No item to pop.");

        var item = _items[_top--];

        if (IsUnderutilized) { _maxSize /= ResizeFactor; Resize(); }

        return item;
    }

    public T? TopValue()
    {
        if (IsEmpty) 
            throw new InvalidOperationException("Stack is empty.");

        return _items[_top];
    }
}

