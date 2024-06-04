namespace BinaryTree;

public class LoadBinaryTree
{
    public BinaryTree Load(string filePath)
    {
        using var reader = new StreamReader(filePath);
        return new BinaryTree { Root = ReadNode(reader) };
    }

    private TreeNode? ReadNode(StreamReader reader)
    {
        var line = reader.ReadLine();
        if (line == "null" || line is null)
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