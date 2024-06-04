namespace BinaryTree;

public class SaveBinaryTree
{
    public void Save(TreeNode? node, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        WriteNode(writer, node);
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
}