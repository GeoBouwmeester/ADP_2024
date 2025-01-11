namespace ADP_2024.AVL_Tree
{
	public class AvlTree<T> where T : IComparable<T>
	{
		private Node<T> _root;

		public Node<T> Find(T key)
		{
			Node<T> current = _root;

			while (current != null)
			{
				if (current.Key.CompareTo(key) == 0)
				{
					break;
				}

				current = current.Key.CompareTo(key) < 0 ? current.Right : current.Left;
			}
			return current;
		}

		public void Insert(T key)
		{
			_root = Insert(_root, key);
		}

		public void Remove(T key)
		{
			_root = Remove(_root, key);
		}

		public Node<T> GetRoot()
		{
			return _root;
		}

		public int Height()
		{
			return _root == null ? -1 : _root.Height;
		}

		private Node<T> Insert(Node<T> root, T key)
		{
			if (root == null)
			{
				return new Node<T>(key);
			}
			else if (root.Key.CompareTo(key) > 0)
			{
				root.Left = Insert(root.Left, key);
			}
			else if (root.Key.CompareTo(key) < 0)
			{
				root.Right = Insert(root.Right, key);
			}
			else
			{
				throw new InvalidOperationException("Duplicate Key!");
			}
			return Rebalance(root);
		}

		private Node<T> Remove(Node<T> node, T key)
		{
			if (node == null)
			{
				return node;
			}
			else if (node.Key.CompareTo(key) > 0)
			{
				node.Left = Remove(node.Left, key);
			}
			else if (node.Key.CompareTo(key) < 0)
			{
				node.Right = Remove(node.Right, key);
			}
			else
			{
				if (node.Left == null || node.Right == null)
				{
					node = (node.Left == null) ? node.Right : node.Left;
				}
				else
				{
					Node<T> mostLeftChild = MostLeftChild(node.Right);
					node.Key = mostLeftChild.Key;
					node.Right = Remove(node.Right, node.Key);
				}
			}
			if (node != null)
			{
				node = Rebalance(node);
			}
			return node;
		}

		private Node<T> MostLeftChild(Node<T> node)
		{
			Node<T> current = node;
			while (current.Left != null)
			{
				current = current.Left;
			}
			return current;
		}

		private Node<T> Rebalance(Node<T> z)
		{
			UpdateHeight(z);
			int balance = GetBalance(z);

			if (balance > 1)
			{
				if (Height(z.Right.Right) > Height(z.Right.Left))
				{
					z = RotateLeft(z);
				}
				else
				{
					z.Right = RotateRight(z.Right);
					z = RotateLeft(z);
				}
			}
			else if (balance < -1)
			{
				if (Height(z.Left.Left) > Height(z.Left.Right))
				{
					z = RotateRight(z);
				}
				else
				{
					z.Left = RotateLeft(z.Left);
					z = RotateRight(z);
				}
			}
			return z;
		}

		private Node<T> RotateRight(Node<T> y)
		{
			Node<T> x = y.Left;
			Node<T> z = x.Right;
			x.Right = y;
			y.Left = z;
			UpdateHeight(y);
			UpdateHeight(x);
			return x;
		}

		private Node<T> RotateLeft(Node<T> y)
		{
			Node<T> x = y.Right;
			Node<T> z = x.Left;
			x.Left = y;
			y.Right = z;
			UpdateHeight(y);
			UpdateHeight(x);
			return x;
		}

		private void UpdateHeight(Node<T> node)
		{
			node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
		}

		private int Height(Node<T> node)
		{
			return node == null ? -1 : node.Height;
		}

		public int GetBalance(Node<T> node)
		{
			return (node == null) ? 0 : Height(node.Right) - Height(node.Left);
		}

		public int GetTreeSize(Node<T> node)
		{
			if (node == null)
				return 0;
			return 1 + GetTreeSize(node.Left) + GetTreeSize(node.Right);
		}

		public T FindMin()
		{
			if (_root == null) throw new InvalidOperationException("The tree is empty.");
			return MostLeftChild(_root).Key;
		}

		public T FindMax()
		{
			if (_root == null) throw new InvalidOperationException("The tree is empty.");
			Node<T> current = _root;
			while (current.Right != null)
			{
				current = current.Right;
			}
			return current.Key;
		}








		public bool IsBalanced()
		{
			bool CheckBalance(Node<T> node)
			{
				if (node == null)
					return true;

				int balance = GetBalance(node);

				if (balance < -1 || balance > 1)
					return false;

				return CheckBalance(node.Left) && CheckBalance(node.Right);
			}

			return CheckBalance(_root);
		}

		public void PrintTreeStructure()
		{
			PrintTreeRecursive(_root, " ", new List<string>(), null);
		}

		private void PrintTreeRecursive(Node<T> currentNode, string delimiter, List<string> indentation, bool? isLeftChild)
		{
			if (currentNode != null)
			{
				indentation.Add(delimiter);

				var (leftDelimiter, rightDelimiter) = GetDelimitersForChild(isLeftChild);

				PrintTreeRecursive(currentNode.Right, leftDelimiter, indentation, false);
				PrintIndentedNode(currentNode.Key, indentation);
				PrintTreeRecursive(currentNode.Left, rightDelimiter, indentation, true);

				indentation.RemoveAt(indentation.Count - 1);
			}
		}

		private (string, string) GetDelimitersForChild(bool? isLeftChild)
		{
			string leftDelimiter = " ";
			string rightDelimiter = "|";
			return isLeftChild == true ? (rightDelimiter, leftDelimiter) : isLeftChild == false ? (leftDelimiter, rightDelimiter) : (leftDelimiter, leftDelimiter);
		}

		private void PrintIndentedNode(T value, List<string> indentation, int indentWidth = 6)
		{
			if (indentation.Count == 0)
			{
				Console.WriteLine(value);
			}
			else
			{
				foreach (var indent in indentation)
				{
					Console.Write(indent + new string(' ', indentWidth - 1));
				}
				Console.WriteLine("|-> " + value);
			}
		}
	}
}
