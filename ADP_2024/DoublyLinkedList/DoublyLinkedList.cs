using System.Collections;

namespace ADP_2024.DoublyLinkedList
{
	public class DoublyLinkedList<T> : IEnumerable<Node<T>>
	{
		private Node<T> head;
		private Node<T> tail;

		public int Length { get; private set; }

		public IEnumerator<Node<T>> GetEnumerator()
		{
			Node<T> current = head;
			while (current != null)
			{
				yield return current;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable GetEnumeratorReverse()
		{
			Node<T> current = tail;
			while (current != null)
			{
				yield return current;
				current = current.Previous;
			}
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

        public bool Contains(T value)
		{
			Node<T> current = head;
			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Data, value))
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
				if (EqualityComparer<T>.Default.Equals(current.Data, value))
				{
					return current;
				}

				current = current.Next;
			}

			return null;
		}

		public bool Remove(T value)
		{
			Node<T> current = head;
			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Data, value))
				{
					if (current.Next == null)
					{
						tail = current.Previous;
					}
					else
					{
						current.Next.Previous = current.Previous;
					}

					if (current.Previous == null)
					{
						head = current.Next;
					}
					else
					{
						current.Previous.Next = current.Next;
					}

					current = null;
					Length--;
					return true;
				}

				current = current.Next;
			}
			return false;
		}

    }
}
