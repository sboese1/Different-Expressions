using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// This class handles all of the user I/O which includes the input into the
/// GUI as well as just the GUI in general.
/// </summary>

namespace Project4_starter
{
    public partial class Form1 : Form
    {
        string[] allNums = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        List<string> newParts = new List<string>();
        string result = "";
        Stack<string> s = new Stack<string>();
        ExpressionTree tree;

        public Form1()
        {
            InitializeComponent();

            // Gets the ComboBoxes ready
            List<string> list = new List<string>();
            list.Add("Infix");
            list.Add("Prefix");
            list.Add("Postfix");
            initialType.DataSource = list;

            list = new List<string>();
            list.Add("Infix");
            list.Add("Prefix");
            list.Add("Postfix");
            resultingType.DataSource = list;
        }

        /// <summary>
        /// When the user clicks the Convert Expression button, this method is called and it simply
        /// converts the expression given to the desired expression type.
        /// </summary>
        /// <param name="sender">Required for buttons</param>
        /// <param name="e">Required for buttons</param>
        private void uxConvertExpression_Click(object sender, EventArgs e)
        {
            try
            {
                GetList();
                string result = "";

                // Checks to see which type the user selected and calls the appropriate method to convert it to postfix expression
                if (initialType.SelectedItem == "Prefix")
                {
                    result = PrefixToPostfix();
                }
                else if (initialType.SelectedItem == "Infix")
                {
                    result = InfixToPostfix(newParts);
                }
                else
                {
                    result = initialExpressionText.Text.Trim();
                }

                // Creates a tree based on the postfix expression stated above
                tree = BuildTree(result);

                // Now it goes to the desired resulting type of expression and changes it to the appropriate type based on that
                if (resultingType.SelectedItem == "Prefix")
                {
                    resultingExpression.Text = tree.Preorder();
                }
                else if (resultingType.SelectedItem == "Infix")
                {
                    resultingExpression.Text = tree.Inorder();
                }
                else
                {
                    resultingExpression.Text = tree.Postorder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Invalid input expression.");
            }
        }

        /// <summary>
        /// When this button is clicked, a tree is created and displayed.
        /// The tree is an expression tree made up of the inputted expression given.
        /// </summary>
        /// <param name="sender">Required for buttons</param>
        /// <param name="e">Required for buttons</param>
        private void uxBuildTree_Click(object sender, EventArgs e)
        {
            GetList();

            string type = (string)initialType.SelectedItem;
            string res = "";
            List<string> list = new List<string>();

            //Converts the expression to postfix
            if (type == "Infix")
            {
                res = InfixToPostfix(newParts);
                string[] pieces = res.Split(' ');
                list = pieces.ToList();
                list.Remove("");
            }
            else if (type == "Prefix")
            {
                res = PrefixToPostfix();
                string[] pieces = res.Split(' ');
                list = pieces.ToList();
                list.Remove("");
            }
            else
            {
                list = newParts;
            }

            // And creates the tree
            Build(list);
        }

        /// <summary>
        /// This button simply evaluates the expression based on the expression tree.
        /// </summary>
        /// <param name="sender">Required for buttons</param>
        /// <param name="e">Required for buttons</param>
        private void uxEvaluate_Click(object sender, EventArgs e)
        {
            GetList();
            MessageBox.Show("Answer: " + tree.Solve());
        }

        /// <summary>
        /// This method gets the text in the initial expression textbox and converts
        /// it to a more useable list.
        /// </summary>
        private void GetList()
        {
            try
            {
                string expression = initialExpressionText.Text.Trim();
                List<string> oldParts = expression.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList(); // Splits all of the items in the
                newParts.Clear();                                                  // string and adds them to the list other than the blank entries
                result = "";
                List<string> items = new List<string>();
                StringBuilder sb = new StringBuilder();

                foreach (string s in oldParts) // For every item in that list
                {
                    if (s.Length > 1) // If it has more than 1 item in it
                    {
                        foreach (char c in s) // For every character in the string
                        {
                            if (!allNums.Contains(c.ToString())) // If that character is a operator
                            {
                                if (sb.Length > 0) // And there is at least one character in the stringbuilder
                                {
                                    newParts.Add(sb.ToString()); // Add that stringbuilder to the new list
                                    sb.Clear(); // And clear the stringbuilder
                                }
                                newParts.Add(c.ToString()); // Add that character to the list
                            }
                            else
                            {
                                sb.Append(c.ToString()); // Add on that character to the stringbuilder
                            }
                        }

                        if (sb.Length > 0) // If there is at least one character in the stringbuilder
                        {
                            newParts.Add(sb.ToString()); // Add that stringbuilder to the list
                            sb.Clear(); // And clear it
                        }
                    }
                    else
                    {
                        newParts.Add(s); // Add the string the list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Invalid input expression.");
            }
            
        }

        /// <summary>
        /// This method gives the operator a value of priority.
        /// The higher the more important.
        /// </summary>
        /// <param name="c">The operator</param>
        /// <returns>The operator's order of priority</returns>
        public int order(char c)
        {
            // The higher the priority, the higher the number
            if (c == '+' || c == '-')
            {
                return 1;
            }
            else if (c == '*' || c == '/')
            {
                return 2;
            } 
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts an infix expression to a postfix expession.
        /// </summary>
        /// <param name="parts">The list containing the strings</param>
        /// <returns>The resulting string</returns>
        public string InfixToPostfix(List<string> parts)
        {
            s.Push(" "); // End of the string
            foreach (string str in parts) // For each string in newParts (for every item in the expression)
            {
                if (allNums.Contains(str[0].ToString())) // If the string is a number
                {
                    result += (str + " "); // Add on the number to the resulting string
                }
                else if (str == "(") // If the string is an opening parethesis
                {
                    s.Push("("); // Push that parenthesis to the stack
                }
                else if (str == ")") // If the string is an closing parethesis
                {
                    while (s.Peek() != " " && s.Peek() != "(") // While we are not at the end of the string and the top item is not '('
                    {
                        result += (s.Pop() + " "); // Pop the top item off and add it result
                    }
                    s.Pop(); // Pop of the top item
                }
                else
                {
                    if (order(str[0]) > order(s.Peek()[0])) // If the current operator has a higher order of precendence than the top item 
                    {                                       // in the stack
                        s.Push(str); // Then push that item
                    }
                    else
                    {
                        while (s.Peek() != " ") // While we aren't at the end of the stack
                        {
                            result += (s.Pop() + " "); // Pop the top item off and add it result
                        }
                        s.Push(str); // Push that string
                    }
                }
            }

            while (s.Peek() != " ") // While we aren't at the end of the stack
            {
                if (s.Peek() != "(" && s.Peek() != ")")
                {
                    result += s.Pop() + " "; // Pop the top item off and add it result
                }
                else
                {
                    s.Pop(); // Pop the top item off
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a postfix expression to an infix expession.
        /// </summary>
        /// <returns>The resulting string</returns>
        public string PostfixToInfix()
        {
            foreach (string str in newParts) // For each string in newParts (for every item in the expression)
            {
                if (allNums.Contains(str[0].ToString())) // If the string is a number
                {
                    s.Push(str); // Push it to the stack
                }
                else
                {
                    string first = s.Pop(); // Get the first two items off the stack
                    string second = s.Pop();
                    result = "(" + second + " " + str + " " + first + ")"; // Concatenate those two items and add parenthesis to them
                    s.Push(result); // Push this concatenated string
                }
            }

            return result;
        }

        /// <summary>
        /// Converts an infix expression to a prefix expession.
        /// </summary>
        /// <returns>The resulting string</returns>
        public string InfixToPrefix()
        {
            newParts.Reverse(); // Reverse the list

            for (int i = 0; i < newParts.Count; i++) // For every item in newParts
            {
                if (newParts[i] == "(") // If the item at spot i in newParts is equal to '('
                {
                    newParts[i] = ")"; // Set that item to ')'
                    i++; // It would be an invalid expression if there was nothing inside the braces so automatically move to the next spot
                }
                else if (newParts[i] == ")")
                {
                    newParts[i] = "(";
                    i++;
                }
            }

            string prefix = InfixToPostfix(newParts); // Call the infixtopostfix method that we've already done to save time and effort

            // This just reverses the string as it comes backwards
            char[] charArray = prefix.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Converts a prefix expression to an infix expession.
        /// </summary>
        /// <returns>The resulting string</returns>
        public string PrefixToInfix()
        {
            List<string> temp = new List<string>();

            foreach (string str in newParts) // For every item in newParts
            {
                if (allNums.Contains(str[0].ToString())) // If it's a number
                {
                    temp.Add(str); // Add it to the list
                    if (temp.Count == 2) // If there are 2 items in the list
                    {
                        result += "(" + temp[0] + " " + s.Pop() + " " + temp[1] + ")"; // Add on this expression
                        if (s.Count > 0) // If there is at least one thing in the stack
                        {
                            result += " " + s.Pop() + " "; // Add on this expression
                        }
                        temp.Clear(); // Clear (empty) the list
                    }
                }
                else
                {
                    if (temp.Count == 1) // If there is one thing in the list
                    {
                        result += temp[0] + " " + s.Pop() + " "; // Add on this expression
                        temp.Clear(); // And clear the list
                    }
                    s.Push(str); // Add this string to the top of the stack
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a postfix expression to an prefix expession.
        /// </summary>
        /// <returns>The resulting string</returns>
        public string PostfixToPrefix()
        {
            foreach (string str in newParts) // For every item in newParts
            {
                if (!allNums.Contains(str[0].ToString())) // If the string is an operator
                {
                    string first = s.Pop(); // Pop off the first two items on the stack
                    string second = s.Pop();
                    string temp1 = str + " " + second + " " + first; // Concatenate the two items together
                    s.Push(temp1); // And put it on the top of the stack
                }
                else
                {
                    s.Push(str); // Add the string to the top of the stack
                }
            }

            while (s.Count > 0) // As long as there is something in the stack
            {
                result += s.Pop() + " "; // Pop off the top item and add it the resulting string
            }

            return result;
        }

        /// <summary>
        /// Converts a prefix expression to a postfix expession.
        /// </summary>
        /// <returns>The resulting string</returns>
        public string PrefixToPostfix()
        {
            for (int i = newParts.Count-1; i >= 0; i--) // Starts from the top of newParts and goes down
            {
                if (allNums.Contains(newParts[i][0].ToString())) // If it's a number
                {
                    s.Push(newParts[i]); // Add it on to the stack
                }
                else
                {
                    string val1 = s.Pop(); // Pop off the top two items on the stack
                    string val2 = s.Pop();
                    string res = val1 + " " + val2 + " " + newParts[i]; // Concatenate this expression

                    s.Push(res); // And add it to the stack
                }
            }

            return s.Pop();
        }

        /// <summary>
        /// This builds the expression tree using the ExpressionTree
        /// and ExpressionTreeLeaf classes and returns it
        /// </summary>
        /// <param name="st">The postfix expression</param>
        /// <returns>The final tree</returns>
        public ExpressionTree BuildTree(string st)
        {
            Stack<ExpressionTree> eStack = new Stack<ExpressionTree>();
            ExpressionTree et, tree1, tree2;
            ExpressionTreeLeaf etl;
            char[] c = { ' ' };
            string[] parts = st.Split(c, StringSplitOptions.RemoveEmptyEntries); // Splits the string and gets rid of all empty entries

            foreach (string str in parts) // For every item in parts
            {
                if (allNums.Contains(str[0].ToString())) // If it's a number
                {
                    etl = new ExpressionTreeLeaf(Convert.ToInt32(str)); // Create a new leaf with that number
                    eStack.Push(etl); // And push it onto the stack
                }
                else
                {
                    // Pop off the top two items
                    tree1 = eStack.Pop();
                    tree2 = eStack.Pop();

                    ExpressionTree newTree = new ExpressionTree(str, tree2, tree1); // Create a new expression tree with the operator and two operands

                    eStack.Push(newTree); // And push it onto the stack
                }
            }

            et = eStack.Pop(); // Pop off the last item
            return et;
        }

        /// <summary>
        /// This does the same thing as BuildList but draws the tree and
        /// doesn't return anything. It creates an expression tree.
        /// </summary>
        /// <param name="list">The list of strings to create the tree</param>
        public void Build(List<string> list)
        {
            Stack<ExpressionTree> eStack = new Stack<ExpressionTree>();
            ExpressionTree et, tree1, tree2;
            ExpressionTreeLeaf etl;

            foreach (string st in list) // For every item in the list
            {
                if (allNums.Contains(st[0].ToString())) // If it's a number
                {
                    etl = new ExpressionTreeLeaf(Convert.ToInt32(st)); // Create a leaf with that number
                    eStack.Push(etl); // And push it onto the stack
                }
                else
                {
                    // Pop off the top two items
                    tree1 = eStack.Pop();
                    tree2 = eStack.Pop();

                    ExpressionTree newTree = new ExpressionTree(st, tree2, tree1); // Create a new expression tree with the operator and two operands

                    eStack.Push(newTree); // And push it onto the stack
                }
            }
            et = eStack.Pop(); // Pop off the last item

            et.DrawTree(); // And draw the tree
        }
    }
}
