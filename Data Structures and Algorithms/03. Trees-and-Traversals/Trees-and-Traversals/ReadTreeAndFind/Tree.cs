namespace ReadTreeAndFind
{
    using System;
    using System.Collections.Generic;

    // needs parent
    // put for adoption
    public class Tree<T>
        where T : IComparable<T>
    {
        private class TreeNode
        {
            public TreeNode(T value)
            {
                this.Value = value;
                this.Children = new List<TreeNode>();
            }

            public T Value { get; private set; }

            public List<TreeNode> Children { get; set; }
        }

        private TreeNode root;

        public Tree()
        {
            root = null;
        }

        private TreeNode Add(T key, T value, TreeNode node)
        {
            if (node != null && !node.Value.Equals(key))
            {
                var parentFound = false;
                foreach (var child in node.Children)
                {
                    if (child.Value.Equals(key)) // child != null && 
                    {
                        child.Children.Add(new TreeNode(value));
                        parentFound = true;
                        break;
                    }
                }


                if (!parentFound)
                {
                    foreach (var child in node.Children)
                    {
                        var childrenCount = child.Children.Count;
                        this.Add(key, value, child);
                        var elementAdded = childrenCount > child.Children.Count;
                        if (elementAdded)
                        {
                            break;
                        }
                    }
                }
            }
            else if (node != null && node.Value.Equals(key))
            {
                node.Children.Add(new TreeNode(value));
            }
            else
            {
                node = new TreeNode(key);
                node.Children.Add(new TreeNode(value));
            }

            return node;
        }

        public void Add(T key, T value)
        {
            this.root = this.Add(key, value, this.root);
        }
    }
}
