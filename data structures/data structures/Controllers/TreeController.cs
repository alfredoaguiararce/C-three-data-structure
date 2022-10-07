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

            Tree<int> _tree = new Tree<int>();
            _tree.Root = new TreeNode<int>() { Data = 1 };
            _tree.Root.Children = new List<TreeNode<int>>
            {
             new TreeNode<int>() { Data = 50, Parent = _tree.Root },
             new TreeNode<int>() { Data = 1, Parent = _tree.Root },
             new TreeNode<int>() { Data = 150, Parent = _tree.Root }
            };
            return _tree.Root.GetHeight();
        }


        [HttpGet]
        [Route("children")]
        public List<TreeNode<int>> GetTreeChildren()
        {

            Tree<int> _tree = new Tree<int>();
            _tree.Root = new TreeNode<int>() { Data = 1 };
            _tree.Root.Children = new List<TreeNode<int>>
            {
             new TreeNode<int>() { Data = 50, Parent = _tree.Root },
             new TreeNode<int>() { Data = 1, Parent = _tree.Root },
             new TreeNode<int>() { Data = 150, Parent = _tree.Root }
            };
            return _tree.Root.Children;
        }

        [HttpGet]
        [Route("fulltree")]
        public Tree<int> GetTreeFull()
        {

            Tree<int> _tree = new Tree<int>();
            _tree.Root = new TreeNode<int>() { Data = 1 };
            _tree.Root.Children = new List<TreeNode<int>>
            {
             new TreeNode<int>() { Data = 50, Parent = _tree.Root },
             new TreeNode<int>() { Data = 1, Parent = _tree.Root },
             new TreeNode<int>() { Data = 150, Parent = _tree.Root }
            };
            _tree.Root.Children[1].Children = new List<TreeNode<int>>
            {
             new TreeNode<int>() { Data = 50, Parent = _tree.Root.Children[1] },
             new TreeNode<int>() { Data = 1, Parent = _tree.Root.Children[1] },
             new TreeNode<int>() { Data = 150, Parent = _tree.Root.Children[1] }
            };

            logger.LogInformation(1, "{data}", _tree);
            return _tree;
        }
    }
}
