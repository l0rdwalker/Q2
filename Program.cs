using System;

class Program
{
    static void Main(string[] args)
    {
        int[] a5 = new int[] { 2, 4};
        int[] a1 = new int[] { 21, 22, 23};
        int[][] arrays = new int[][] { a1, a5};
        //print(arrays);

        q2 UnionEngine = new q2(arrays);
        Console.WriteLine(UnionEngine.getPair());
        
        UnionEngine.left_forward();
        UnionEngine.left_forward();
        UnionEngine.left_forward();
        
        UnionEngine.right_backward();
        UnionEngine.right_backward();
        UnionEngine.right_backward();
        UnionEngine.right_backward();

        int[] test = UnionEngine.getPair();
        print(arrays);
        
    }

    public static void print(int[][] arrays) {
        Console.WriteLine("");
        for (int x = 0; x<arrays.Length; x++) {
            Console.Write(" [");
            for (int y = 0; y<arrays.Length; y++) {
                Console.Write(arrays[x][y].ToString() + ", ");
            }
            Console.Write("]");
        }
    }
}
