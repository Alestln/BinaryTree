namespace BinaryTree;

public class PrintBinaryTree
{
    public void Print(TreeNode? node, string indent, string prefix = "")
    {
        while (true)
        {
            if (node is null) return;

            Print(node.Right, indent + (prefix == "right" ? "      " : " |    "), "right");
            
            Console.WriteLine(indent + (prefix == "right" ? " /" : " \\") + "----- " + node.Value);
            
            node = node.Left;
            indent += (prefix == "left" ? "      " : " |    ");
            prefix = "left";
        }
    }
}