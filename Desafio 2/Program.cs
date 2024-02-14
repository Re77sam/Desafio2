using System;
using System.Linq;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
}

public class TreeBuilder
{
    public TreeNode BuildTree(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return null;
        }

        // Encontrar o valor máximo (raiz) no array
        int max = array.Max();

        // Criar o nó raiz
        TreeNode root = new TreeNode
        {
            Value = max
        };

        // Dividir o array em duas partes (esquerda e direita do valor máximo)
        int[] leftArray = array.TakeWhile(x => x != max).ToArray();
        int[] rightArray = array.SkipWhile(x => x != max).Skip(1).ToArray();

        // Construir recursivamente os galhos esquerdo e direito
        root.Left = BuildTree(leftArray);
        root.Right = BuildTree(rightArray);

        return root;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Cenario 1
        int[] array1 = { 3, 2, 1, 6, 0, 5 };
        TreeBuilder treeBuilder1 = new TreeBuilder();
        TreeNode root1 = treeBuilder1.BuildTree(array1);
        Console.WriteLine("Array de entrada: [" + string.Join(", ", array1) + "]");
        Console.WriteLine("Raiz: " + root1.Value);
        Console.Write("Galhos da esquerda: ");
        PrintValues(root1.Left);
        Console.Write("\n Galhos da direita: ");
        PrintValues(root1.Right);

        // Cenario 2
        int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };
        TreeBuilder treeBuilder2 = new TreeBuilder();
        TreeNode root2 = treeBuilder2.BuildTree(array2);
        Console.WriteLine("\nArray de entrada: [" + string.Join(", ", array2) + "]");
        Console.WriteLine("Raiz: " + root2.Value);
        Console.Write("Galhos da esquerda: ");
        PrintValues(root2.Left);
        Console.Write("\n Galhos da direita: ");
        PrintValues(root2.Right);
    }

    static void PrintValues(TreeNode node)
    {
        if (node == null)
        {
            Console.WriteLine("Nenhum");
            return;
        }

        CollectValues(node);
    }

    static void CollectValues(TreeNode node)
    {
        if (node == null)
            return;

        CollectValues(node.Left);
        Console.Write(node.Value + " ");
        CollectValues(node.Right);
    }
}

