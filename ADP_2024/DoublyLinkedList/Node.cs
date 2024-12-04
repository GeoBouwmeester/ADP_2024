//DoublyLinkedList Node
//Data field with getter and setter
//Next field to point to the next node with a getter and setter
//Previous field to point to the previous field with a getter and setter
//Constructor sets data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

	}
}
