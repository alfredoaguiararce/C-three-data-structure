using data_structures.DataStructures;
using Xunit;

namespace datastructures.tests
{
    public class TreeStructureTests
    {
        [Fact]
        public void InitTest()
        {
            TreeNode<int> _tree = new TreeNode<int>();
            Assert.NotNull(_tree);
            Assert.IsType<TreeNode<int>>(_tree);
        }

        [Fact]
        public void TreeHeightTest()
        {
            // Create an empty tree
            TreeNode<int> _tree = new TreeNode<int>();
            _tree.SetRoot(1);
            Assert.Equal(1, _tree.GetHeight());

            _tree.AddChildren(2);
            Assert.Equal(2, _tree.GetHeight());

            _tree.GetChild(0).AddChildren(3);
            Assert.Equal(3, _tree.GetChild(0).GetChild(0).GetHeight());
        }

        [Fact]
        public void GetChildByIndex()
        {
            // Create an empty tree
            TreeNode<int> _tree = new TreeNode<int>();
            _tree.SetRoot(1);

            _tree.AddChildren(2);
            Assert.Equal(2, _tree.GetChild(0).Data);
        }
    }
}