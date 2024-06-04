using System.Text.Json;

namespace BinaryTree;

public class BinarySearchTree
{
    public TreeNode? Root { get; private set; }

    public void Add(int value)
    {
        if (Root is null)
        {
            Root = new TreeNode(value);
        }
        else
        {
            AddRecursive(Root, value);
        }
    }

    private void AddRecursive(TreeNode node, int value)
    {
        while (true)
        {
            if (value < node.Value)
            {
                if (node.Left is null)
                {
                    node.Left = new TreeNode(value);
                }
                else
                {
                    node = node.Left;
                    continue;
                }
            }
            else
            {
                if (node.Right is null)
                {
                    node.Right = new TreeNode(value);
                }
                else
                {
                    node = node.Right;
                    continue;
                }
            }

            break;
        }
    }

    public TreeNode? Search(int value)
    {
        return SearchRecursive(Root, value);
    }

    private TreeNode? SearchRecursive(TreeNode? node, int value)
    {
        while (true)
        {
            if (node is null || node.Value == value)
            {
                return node;
            }

            node = value < node.Value ? node.Left : node.Right;
        }
    }

    public void Remove(int value)
    {
        while (Search(value) is not null)
        {
            Root = RemoveRecursive(Root, value);
        }
    }

    private TreeNode? RemoveRecursive(TreeNode? node, int value)
    {
        if (node is null)
        {
            return null;
        }

        if (value < node.Value)
        {
            node.Left = RemoveRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = RemoveRecursive(node.Right, value);
        }
        else
        {
            node = RemoveNode(node);
        }

        return node;
    }

    private TreeNode? RemoveNode(TreeNode? node)
    {
        if (node is null)
        {
            return null;
        }

        if (node.Left is null)
        {
            return node.Right;
        }

        if (node.Right is null)
        {
            return node.Left;
        }

        var minValue = MinValue(node.Right);
        node.Right = RemoveRecursive(node.Right, minValue);

        return node;
    }

    public int MinValue(TreeNode node)
    {
        while (node.Left is not null)
        {
            node = node.Left;
        }

        return node.Value;
    }

    public void Preorder(TreeNode? node)
    {
        while (true)
        {
            if (node is not null)
            {
                Console.Write(node.Value + " ");
                Preorder(node.Left);
                node = node.Right;
                continue;
            }

            break;
        }
    }

    public void Inorder(TreeNode? node)
    {
        while (true)
        {
            if (node is not null)
            {
                Inorder(node.Left);
                Console.Write(node.Value + " ");
                node = node.Right;
                continue;
            }

            break;
        }
    }

    public void LevelOrder()
    {
        if (Root is null)
        {
            return;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            Console.Write(node.Value + " ");

            if (node.Left is not null)
            {
                queue.Enqueue(node.Left);
            }

            if (node.Right is not null)
            {
                queue.Enqueue(node.Right);
            }
        }
    }

    public void SaveToFile(TreeNode? root, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        WriteNode(writer, root);
    }

    private void WriteNode(StreamWriter writer, TreeNode? node)
    {
        while (true)
        {
            if (node is null)
            {
                writer.WriteLine("null");
                return;
            }

            writer.WriteLine(node.Value);
            WriteNode(writer, node.Left);
            node = node.Right;
        }
    }

    public void LoadFromFile(string filePath)
    {
        using var reader = new StreamReader(filePath);
        Root = ReadNode(reader);
    }

    private TreeNode? ReadNode(StreamReader reader)
    {
        var line = reader.ReadLine();
        if (line == "null" || line == null)
        {
            return null;
        }

        var value = int.Parse(line);
        var node = new TreeNode(value)
        {
            Left = ReadNode(reader),
            Right = ReadNode(reader)
        };

        return node;
    }
}