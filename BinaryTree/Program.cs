﻿namespace BinaryTree;

class Program
{
    static void Main(string[] args)
    {
        var bst = new BinaryTree();

        var rand = new Random();
        for (var i = 0; i < 10; i++)
        {
            bst.Add(rand.Next(1, 10));
        }

        Console.WriteLine("Preorder Traversal:");
        bst.Preorder(bst.Root);
        Console.WriteLine();

        Console.WriteLine("Inorder Traversal:");
        bst.Inorder(bst.Root);
        Console.WriteLine();

        Console.WriteLine("Level-Order Traversal:");
        bst.LevelOrder();
        Console.WriteLine();

        var searchValue = rand.Next(1, 10);
        Console.WriteLine($"Searching for {searchValue} in the tree.");
        var foundNode = bst.Search(searchValue);
        
        Console.WriteLine(foundNode is not null
            ? $"Found node with value: {foundNode.Value}"
            : "Value not found in the tree.");

        Console.WriteLine("Removing the minimum value from the tree.");
        if (bst.Root is not null)
        {
            bst.Remove(bst.MinValue(bst.Root));

            Console.WriteLine("Inorder Traversal after removing the minimum value:");
            bst.Inorder(bst.Root);
        }

        var printer = new PrintBinaryTree();
        Console.WriteLine("\nBinary tree: ");
        printer.Print(bst.Root, "");
        
        var filePath = "tree.txt";

        Console.WriteLine("Saving binary tree in file...");
        new SaveBinaryTree().Save(bst.Root, filePath);

        Console.WriteLine("Loading binary tree in file...");
        var bstFromFile = new LoadBinaryTree().Load(filePath);

        Console.WriteLine("\nBinary tree from file: ");
        printer.Print(bstFromFile.Root, "");
    }
}