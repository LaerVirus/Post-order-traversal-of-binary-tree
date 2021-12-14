using System;

namespace BinaryTree_PostOrderTraversal
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Value { get; }
    }
}