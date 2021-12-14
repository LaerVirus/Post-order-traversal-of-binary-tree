using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree_PostOrderTraversal
{
    public class BinaryTree : ICollection<int>
    {
        public int Count { get; private set; }

        public Node Root { get; private set; }

        readonly PostOrderTraversal postOrderTraversal = new PostOrderTraversal();

        public bool IsReadOnly => false;

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                var node = Root;
                var stack = new Stack<Node>();
                stack.Push(node);

                while (stack.Count > 0)
                {
                    node = stack.Pop();

                    if (value < node.Value)
                    {
                        if (node.Left == null)
                        {
                            node.Left = new Node(value);
                        }
                        else
                        {
                            stack.Push(node.Left);
                        }
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = new Node(value);
                        }
                        else
                        {
                            stack.Push(node.Right);
                        }
                    }
                }
            }

            Count++;
        }

        public bool Contains(int value)
        {
            return FindWithParent(value, out var _) != null;
        }

        private Node FindWithParent(int value, out Node parent)
        {
            var current = Root;
            parent = null;

            while (current != null)
            {
                if (current.Value < value)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (current.Value > value)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            var items = postOrderTraversal.Traversal(Root);

            foreach (var item in items)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(int item)
        {
            var current = FindWithParent(item, out var parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if (parent.Value < current.Value)
                    {
                        parent.Right = current.Left;
                    }
                    else if (parent.Value > current.Value)
                    {
                        parent.Left = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Root = current.Right;
                }
                else
                {
                    if (parent.Value < current.Value)
                    {
                        parent.Right = current.Right;
                    }
                    else if (parent.Value > current.Value)
                    {
                        parent.Left = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    Root = leftMost;
                }
                else
                {
                    if (parent.Value < current.Value)
                    {
                        parent.Right = leftMost;
                    }
                    else if (parent.Value > current.Value)
                    {
                        parent.Left = leftMost;
                    }
                }
            }

            return true;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return postOrderTraversal.Traversal(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}