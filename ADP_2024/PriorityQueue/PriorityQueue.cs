namespace ADP_2024.PriorityQueue;

public class PriorityQueue<T> where T : IComparable<T>
{
    private T[] _items;
    private int _capacity;
    private int _size;
    private int _front;
    private int _rear;
    private const int DefaultCapacity = 4;
    private const int ResizeFactor = 2;

    public PriorityQueue(int capacity = DefaultCapacity)
    {
        _capacity = capacity;
        _items = new T[_capacity];
        _front = 0;
        _rear = -1;
        _size = 0;
    }

    public bool IsEmpty => _size == 0;
    public int Count => _size;
    private bool IsUnderutilized => _size <= _capacity / 4 && _capacity > 4;
    private bool IsFull => _size == _capacity;

    public void Add(T item)
    {
        if (IsFull) Resize(_capacity * ResizeFactor);

        _rear = (_rear + 1) % _capacity;
        _items[_rear] = item;
        _size++;

        Reorder();
    }

    private void Reorder()
    {
        int currentIndex = _rear;

        while (currentIndex != _front)
        {
            int previousIndex = (currentIndex - 1 + _capacity) % _capacity;

            if (_items[currentIndex].CompareTo(_items[previousIndex]) > 0)
            {
                currentIndex = Swap(currentIndex, previousIndex);
            }
            else
            {
                break;
            }
        }
    }

    private int Swap(int currentIndex, int previousIndex)
    {
        T temp = _items[currentIndex];
        _items[currentIndex] = _items[previousIndex];
        _items[previousIndex] = temp;
        currentIndex = previousIndex;
        return currentIndex;
    }

    private void Resize(int newCapacity)
    {
        var newItems = new T[newCapacity];

        for (int i = 0; i < _size; i++)
        {
            newItems[i] = _items[(_front + i) % _capacity];
        }

        _items = newItems;
        _capacity = newCapacity;
        _front = 0;
        _rear = _size - 1;
    }

    public T Peek()
    {
        if (IsEmpty) 
            throw new InvalidOperationException("The priorityQueue is empty.");

        return _items[_front];
    }

    public T Poll()
    {
        if (IsEmpty)
            throw new InvalidOperationException("The priorityQueue is empty.");

        T result = _items[_front];

        _items[_front] = default;

        _front = (_front + 1) % _capacity;

        _size--;

        if (IsUnderutilized) Resize(_capacity / ResizeFactor);

        return result;
    }
}