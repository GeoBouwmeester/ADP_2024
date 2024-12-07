namespace ADP_2024.Deque
{
	public class Deque<T>
	{
		private Node<T> head; 
		private Node<T> tail; 
		private int size;

		public Deque()
		{
			head = null; 
			tail = null; 
			size = 0; 
		}

		public void InsertLeft(T item)
		{
			Node<T> newNode = new Node<T>(item); 

			if (head == null) 
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				newNode.Next = head; 
				head.Previous = newNode; 
				head = newNode;
			}

			size++; 
		}

		public void InsertRight(T item)
		{
			Node<T> newNode = new Node<T>(item);

			if (tail == null) 
			{
				head = newNode; 
				tail = newNode;
			}
			else
			{
				newNode.Previous = tail; 
				tail.Next = newNode; 
				tail = newNode;
			}

			size++; 
		}

		public T DeleteLeft()
		{
			if (size == 0) 
			{
				throw new InvalidOperationException("Deque is empty");
			}

			T data = head.Data; 

			if (size == 1) 
			{
				head = null; 
				tail = null; 
			}
			else
			{
				head = head.Next; 
				head.Previous = null; 
			}

			size--;
			return data; 
		}

		public T DeleteRight()
		{
			if (size == 0) 
			{
				throw new InvalidOperationException("Deque is empty");
			}

			T data = tail.Data; 

			if (size == 1) 
			{
				head = null; 
				tail = null; 
			}
			else
			{
				tail = tail.Previous; 
				tail.Next = null; 
			}
			size--; 
			return data; 
		}

		public int Size()
		{
			return size; 
		}
	}
}