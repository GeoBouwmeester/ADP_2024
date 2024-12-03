namespace ADP_2024.PriorityQueue;

public class PriorityQueue<T>
{
    private (T item, int Priority)[] _items;
    private const int DefaultCapacity = 4;
    private int _capacity;
    private int _size;
    private int _front;
    private int _rear;

    public PriorityQueue(int capacity = DefaultCapacity)
    {
        _capacity = capacity;
        _items = new (T item, int Priority)[_capacity];
        _front = 0;
        _rear = -1;
        _size = 0;
    }

    public bool IsEmpty => _size == 0;
    public int Count => _size;

    // Add method to insert an element with a priority
    public void Add(T item, int priority)
    {
        if (_size == _capacity - 1)
        {
            Resize();
        }

        // Add the new element at the rear
        _rear = (_rear + 1) % _capacity;
        _items[_rear] = (item, priority);
        _size++;

        Reorder();
    }

    private void Reorder()
    {
        // Index of the one just added
        int current = _rear;

        while (current != _front)
        {
            int prev = (current - 1 + _capacity) % _capacity;

            if (_items[current].Priority > _items[prev].Priority)
            {
                // Swap nodes
                (T item, int Priority) temp = _items[current];
                _items[current] = _items[prev];
                _items[prev] = temp;
                current = prev;
            }
            else
            {
                break;
            }
        }
    }

    private void Resize()
    {
        int newCapacity = _capacity * 2;

        var newArray = new (T Item, int Priority)[newCapacity];

        // Copy elements to the new array
        for (int i = 0; i < _size; i++)
        {
            newArray[i] = _items[(_front + i) % _capacity];
        }

        _items = newArray;
        _front = 0;
        _rear = _size;
        _capacity = newCapacity;
    }

    // Peek method to view the highest-priority item without removing it
    public T Peek()
    {
        if (_size == 0) throw new InvalidOperationException("The priorityQueue is empty.");

        return _items[_front].item;
    }

    // Poll method to remove and return the highest-priority item
    public T Poll()
    {
        if (_size == 0) throw new InvalidOperationException("The priorityQueue is empty.");
       
        // Get the highest-priority item (at the head)
        T result = _items[_front].item;

        // Move the head to the next position
        _front = (_front + 1) % _capacity;
        _size--;

        return result;
    }
}