namespace ADP_2024.DoublyLinkedList;

public class DoublyLinkedList<T> where T : IComparable<T> 
{
	private Node<T>? head;
	private Node<T>? tail;

	public int Length { get; private set; }

	public DoublyLinkedList()
	{
		head = null;   
		tail = null;   
		Length = 0;    
	}

	public void Add(T data)
	{
		Node<T> newNode = new Node<T>(data);

		if (tail == null) 
		{
			head = newNode; 
		}
		else
		{
			newNode.Previous = tail; 
			tail.Next = newNode;
		}

		tail = newNode;

		Length++;
	}

	public T Get(int index)
	{
		if (index < 0 || index >= Length)
		{
			throw new IndexOutOfRangeException("Index is out of range");
		}

		Node<T> current = head;

		for (int i = 0; i < index; i++)
		{
			current = current.Next;
		}

		return current.Data;
	}

	public void Set(int index, T element)
	{
		if (index < 0 || index >= Length)
		{
			throw new IndexOutOfRangeException("Index is out of range");
		}

		Node<T> current = head;

		for (int i = 0; i < index; i++) 
		{
			current = current.Next; 
		}

		current.Data = element; 
	}

	public bool Remove(T value)
	{
		Node<T> current = head;

		while (current != null)
		{
			if (current.Data.CompareTo(value) == 0)
			{
				if (current.Previous == null)
				{
					head = current.Next;

					if (head != null)
					{
						head.Previous = null;
					}
				}
				else
				{
					current.Previous.Next = current.Next; 
				}

				if (current.Next == null)
				{
					tail = current.Previous;
				}
				else
				{
					current.Next.Previous = current.Previous;
				}

				Length--;
				
				return true;
			}

			current = current.Next; 
		}

		return false;
	}

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Length)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }

		Node<T> current;

        if (index < Length / 2)
		{
			current = head;

			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
		}
        else
        {
            current = tail;

            for (int i = Length - 1; i > index; i--)
            {
                current = current.Previous;
            }
        }

        if (current.Previous == null)
        {
            head = current.Next;

            if (head != null)
            {
                head.Previous = null;
            }
        }
        else
        {
            current.Previous.Next = current.Next;
        }

        if (current.Next == null)
        {
            tail = current.Previous;
        }
        else
        {
            current.Next.Previous = current.Previous;
        }

        Length--;
    }

    public bool Contains(T value)
	{
		Node<T> current = head;

		while (current != null)
		{
			if (current.Data.CompareTo(value) == 0)
			{
				return true; 
			}

			current = current.Next; 
		}

		return false; 
	}

	public Node<T> Find(T value)
	{
		Node<T> current = head;
		
		while (current != null)
		{
			if (current.Data.CompareTo(value) == 0)
			{
				return current; 
			}

			current = current.Next; 
		}

		return null;
	}

	public int IndexOf(T value)
	{
		int index = 0;

		Node<T> current = head;

		while (current != null)
		{
			if (current.Data.CompareTo(value) == 0)
			{
				return index; 
			}

			current = current.Next;

			index++;
		}

		return -1; 
	}
}

