namespace ADP_2024.DoublyLinkedList
{
	public class Node<T>
	{
		private T data;
		private Node<T> next;
		private Node<T> previous; 

		public T Data
		{
			get { return data; }
			set { data = value; }
		}

		public Node<T> Next
		{
			get { return next; }
			set { next = value; }
		}

		public Node<T> Previous
		{
			get { return previous; }
			set { previous = value; }
		}

		public Node(T data)
		{
			Data = data;
			Next = null;
			Previous = null;
		}

	}
}
