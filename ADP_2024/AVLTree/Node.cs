namespace ADP_2024.AVL_Tree
{
	public class Node<T> where T : IComparable<T>
	{
		public T Key { get; set; }
		public int Height { get; set; }
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }

		public Node(T key)
		{
			Key = key;
			Height = 0;    
			Left = null;   
			Right = null;  
		}
	}
}
