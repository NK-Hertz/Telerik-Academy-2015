namespace TreeTutorialFromLecture
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class TreeNode : IEnumerable<T>
        {
            public T Value { get; private set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(T value)
            {
                this.Value = value;
                this.Left = null;
                this.Right = null;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (this.Left != null)
                {
                    foreach (var item in this.Left)
                    {
                        yield return item;
                    }
                }

                yield return this.Value;

                if (this.Right != null)
                {
                    foreach (var item in this.Right)
                    {
                        yield return item;
                    }
                }
            }
                

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private TreeNode root;
        private int size;

        public Tree()
        {
            this.size = 0;
            this.root = null;
        }

        public int Size
        {
            get { return this.size; }
        }

        private TreeNode Add(TreeNode node, T value)
        {
            if (node == null)
            {
                ++this.size;
                node = new TreeNode(value);
                return node;

            }

            int compare = value.CompareTo(node.Value);
            if (compare == 0)
            {
                return node;
            }
            else if (compare < 0)
            {
                node.Left = this.Add(node.Left, value);
            }
            else
            {
                node.Right = this.Add(node.Right, value);
            }

            return node;
        }

        public void Add(T value)
        {
            this.root = this.Add(this.root, value);
        }

        public bool Contains(T value)
        {
            var node = this.root;
            while (node != null)
            {
                int compare = value.CompareTo(node.Value);
                if (compare == 0)
                {
                    return true;
                }
                if (compare < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        private TreeNode Remove(TreeNode node, T value)
        {

            if (node == null)
            {
                // the value isn`t there
                return null;

            }

            int compare = value.CompareTo(node.Value);
            if (compare == 0)
            {
                --this.size;
                if (node.Right == null)
                {
                    return node.Left;
                }
                if (node.Left == null)
                {
                    return node.Left;
                }

                var parent = node.Right;
                if (parent.Left == null)
                {
                    parent.Left = node.Left;
                    return parent;
                }

                while (parent.Left.Left != null)
                {
                    parent = parent.Left;
                }

                var minimal = parent.Left;
                parent.Left = minimal.Right;

                minimal.Left = node.Left;
                minimal.Right = node.Right;

                return minimal;
            }
            else if (compare < 0)
            {
                node.Left = this.Remove(node.Left, value);
            }
            else
            {
                node.Right = this.Remove(node.Right, value);
            }

            return node;
        }

        public void Remove(T value)
        {
            this.root = this.Remove(this.root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.root != null)
            {
                foreach (var item in this.root)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
