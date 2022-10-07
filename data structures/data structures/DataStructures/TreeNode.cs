namespace data_structures.DataStructures
{
    public class TreeNode<T>
    {
        public T? Data { get; set; }
        public TreeNode<T>? Parent { get; set; }
        public List<TreeNode<T>>? Children { get; set; }
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> Current = this;
            while(Current != null)
            {
                height++;
                Current = Current.Parent;
            }
            return height;
        }
    }

    public class Tree<T>
    {
        public TreeNode<T>? Root { get; set; }
    }
}
