using data_structures.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace data_structures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeController : ControllerBase
    {
        private readonly ILogger<TreeController> logger;


        public TreeController(ILogger<TreeController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public int GetTreeHeight()
        {
            TreeNode<int> _tree = GenerateTree();
            return _tree.GetHeight();
        }

        [HttpGet]
        [Route("GetTreeView")]
        public TreeNode<int> GetTreeView()
        {
            TreeNode<int> _tree = GenerateTree();
            return _tree;
        }

        [HttpGet("{index}")]
        public TreeNode<int> GetChildByIndexInRoot(decimal index)
        {
            TreeNode<int> _tree = GenerateTree();
            return _tree.GetChild((int)index);
        }

        [HttpGet("ID/{Id}")]
        public TreeNode<int>? GetChildByIdInRoot(decimal Id)
        {
            TreeNode<int> _tree = GenerateTree();
            return _tree.SearcNode(Id);
        }

        private TreeNode<int> GenerateTree()
        {
            TreeNode<int> _tree = new TreeNode<int>();
            _tree.SetRoot(1, 1);

            TreeNode<int> _tree2 = new TreeNode<int>();
            _tree2.SetRoot(2, 2);

            TreeNode<int> _tree3 = new TreeNode<int>();
            _tree3.SetRoot(3, 3);
            TreeNode<int> _tree4 = new TreeNode<int>();
            _tree4.SetRoot(4, 4);
            TreeNode<int> _tree5 = new TreeNode<int>();
            _tree5.SetRoot(5, 5);

            _tree.AddChildren(_tree2);
            _tree.AddChildren(2, 10);
            _tree3.AddChildren(_tree4);
            _tree3.GetChild(0).AddChildren(_tree5);

            _tree3.SetParent(_tree2);


            return _tree;
        }
    }
}
