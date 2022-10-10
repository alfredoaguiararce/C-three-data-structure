using System.Text.Json.Serialization;

namespace data_structures.DataStructures
{
    public class TreeNode<T>
    {
        public TreeNode()
        {
            this.Data = default;
            this.Parent = null;
            this.Id = null;
            this.Children = new List<TreeNode<T>>();
        }
        public T? Data { get; set; }
        public decimal? Id { get; set; }
        [JsonIgnore]
        public TreeNode<T>? Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public int GetHeight()
        {
            int height = 0;

            if (this.Data is null)
            {
                return height;
            }

            height++;

            if (!this.Children.Any())
            {
                return height;
            }

            TreeNode<T>? Current = this;
            while(Current != null)
            {
                height++;
                Current = Current.Parent;
            }
            return height;
        }
        public void AddChildren(TreeNode<T> child, decimal? Id = null)
        {
            child.Id = child.Id is not null? child.Id : Id;
            this.Children.Add(child);
        }
        public void AddChildren(T child, decimal? Id = null)
        {
            TreeNode<T> item = new TreeNode<T>();
            item.Data = child;
            item.Parent = this;
            item.Id = Id;
            this.Children.Add(item);
        }
        public TreeNode<T> GetChild(int index)
        {
            CheckIfChildrenIsEmpty();
            return this.Children[index];
        }

        private void CheckIfChildrenIsEmpty()
        {
            if (!this.Children.Any())
            {
                throw new InvalidOperationException("Actual node don't have childrens or it's empty.");
            }
        }

        public TreeNode<T> GetChildById(decimal ChildId)
        {
            CheckIfChildrenIsEmpty();
            TreeNode<T>? item = default;
            foreach(TreeNode<T> Child in this.Children)
            {
                if(Child.Id is not null)
                {
                    if(Child.Id == ChildId)
                    {
                        item = Child;
                    }
                }
            }
            if(item is null)
            {
                throw new KeyNotFoundException($"Actual node don't contains children with the id -> {ChildId}");
            }
            return item;
        }
        public void SetRoot(T Data, decimal? Id = null, TreeNode<T>? Parent = null)
        {
            this.Data = Data;
            this.Parent = Parent;
            this.Id = Id;
            this.Children = new List<TreeNode<T>>();
        }
        public void SetParent(TreeNode<T> ParentNode)
        {
            ParentNode.AddChildren(this);
        }
        public void SetParentById(decimal ParentId)
        {
            throw new NotImplementedException();
            //this.Parent = SearchById(TreeNodeId: ParentId);
        }

        public TreeNode<T>? SearcNode(decimal TreeNodeId)
        {
            
            if(this.Id == TreeNodeId)
            {
                return this;
            }
            else
            {
                foreach(TreeNode<T> Child in this.Children)
                {
                    TreeNode<T>? result = Child.SearcNode(TreeNodeId);
                    if(result is not null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
