namespace SudokuValide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] sudokuArr = new int[9, 9];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = ran.Next(1, 15);
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
