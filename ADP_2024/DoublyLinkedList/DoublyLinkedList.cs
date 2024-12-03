using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
