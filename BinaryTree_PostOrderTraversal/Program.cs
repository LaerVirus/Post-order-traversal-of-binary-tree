using System;

namespace BinaryTree_PostOrderTraversal
{
    public static class Program
    {
        static BinaryTree binaryTree = new BinaryTree();

        public static void Main(string[] args)
        {
            Console.WriteLine("Количество вершин:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Вершины:");
            for (int i = 0; i < n; i++)
            {
                binaryTree.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Готовое дерево:");
            binaryTree.PrintAsTree();

            Console.WriteLine("Обратный обход:");
            BinaryTreeConsole.PrintToConsole(binaryTree);
        }
    }
}
