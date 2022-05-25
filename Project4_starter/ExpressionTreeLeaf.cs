/// <summary>
/// This class represents a number in the expression tree.
/// It essentially just holds its num value.
/// </summary>

namespace Project4_starter
{
    public class ExpressionTreeLeaf : ExpressionTree
    {
        public int num;

        public ExpressionTreeLeaf(int num) : base(num.ToString()) 
        { 
            this.num = num;
        }

        /// <summary>
        /// Returns the value of this node
        /// </summary>
        /// <returns>The value of this node</returns>
        public override string Preorder()
        {
            return num.ToString();
        }

        /// <summary>
        /// Returns the value of this node
        /// </summary>
        /// <returns>The value of this node</returns>
        public override string Inorder()
        {
            return num.ToString();
        }

        /// <summary>
        /// Returns the value of this node
        /// </summary>
        /// <returns>The value of this node</returns>
        public override string Postorder()
        {
            return num.ToString();
        }
    }
}
