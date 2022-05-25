using System;
using System.Drawing;
using KansasStateUniversity.TreeViewer2;

/// <summary>
/// This class is the home of the expression tree. It holds methods to create a tree
/// as well as to traverse it in a couple of ways.
/// </summary>

namespace Project4_starter
{
    public class ExpressionTree : ITree, IColorizer
    {
        public ExpressionTree Left { get; set; }
        public ExpressionTree Right { get; set; }
        public string Data { get; set; }

        /// <summary>
        /// Root is equal to Data in this case
        /// </summary>
        public object Root
        {
            get { return Data; }
        }

        /// <summary>
        /// Creates two ITree children
        /// </summary>
        public ITree[] Children
        {
            get
            {
                ITree[] children = new ITree[2];
                children[0] = (ITree)Left;
                children[1] = (ITree)Right;

                return children;
            }
        }

        /// <summary>
        /// If Data is empty, this is true
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (Data == null);
            }
        }

        public ExpressionTree(string d)
        {
            Data = d;
        }        
        
        public ExpressionTree(string d, ExpressionTree l, ExpressionTree r)
        {
            Data = d;
            Left = l;
            Right = r;
        }
        
        /// <summary>
        /// A preorder traversal of the tree
        /// </summary>
        /// <returns>The resulting string from this traversal</returns>
        public virtual string Preorder()
        {
            return Data + " " + Left.Preorder() + " " + Right.Preorder();
        }

        /// <summary>
        /// A postorder traversal of the tree
        /// </summary>
        /// <returns>The resulting string from this traversal</returns>
        public virtual string Postorder()
        {
            return Left.Postorder() + " " + Right.Postorder() + " " + Data;
        }

        /// <summary>
        /// A inorder traversal of the tree
        /// </summary>
        /// <returns>The resulting string from this traversal</returns>
        public virtual string Inorder()
        {
            return "(" + Left.Inorder() + Data + Right.Inorder() + ")";
        }

        /// <summary>
        /// Gets the color
        /// </summary>
        /// <param name="obj">Required for this method</param>
        /// <returns>The color</returns>
        public Color GetColor(object obj)
        {
            return Color.Black;
        }

        /// <summary>
        /// Returns the value of this node
        /// </summary>
        /// <returns>The value of this node</returns>
        public override string ToString()
        {
            return Data;
        }
        
        /// <summary>
        /// Draws the tree
        /// </summary>
        public void DrawTree()
        {
            new TreeForm(this, 100, this).Show();
        }
        
        /// <summary>
        /// This method solves the expression by traversing through
        /// the tree.
        /// </summary>
        /// <returns>The resulting value</returns>
        public int Solve()
        {
            if (this == null)
            {
                return 0;
            }

            // Essentially, if we are at a leaf (a number)
            if (Left == null && Right == null)
            {
                return Convert.ToInt32(Data);
            }

            int left = 0;
            int right = 0;
            // If either of the subtrees is null, don't recurse through that
            if (Left != null)
            {
                left = Left.Solve();
            }
            if (Right != null)
            {
                right = Right.Solve();
            }

            //Checks for what the operator is, and calculates accordingly
            if (Data == "+")
            {
                return left + right;
            }
            else if (Data == "-")
            {
                return left - right;
            }
            else if (Data == "*")
            {
                return left * right;
            }
            else
            {
                return left / right;
            }
        }
    }
}
