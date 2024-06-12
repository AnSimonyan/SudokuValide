namespace SudokuValide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringStart = "[[\"5\",\"3\",\".\",\".\",\"7\",\".\",\".\",\".\",\".\"]\r\n,[\"6\",\".\",\".\",\"1\",\"9\",\"5\",\".\",\".\",\".\"]\r\n,[\".\",\"9\",\"8\",\".\",\".\",\".\",\".\",\"6\",\".\"]\r\n,[\"8\",\".\",\".\",\".\",\"6\",\".\",\".\",\".\",\"3\"]\r\n,[\"4\",\".\",\".\",\"8\",\".\",\"3\",\".\",\".\",\"1\"]\r\n,[\"7\",\".\",\".\",\".\",\"2\",\".\",\".\",\".\",\"6\"]\r\n,[\".\",\"6\",\".\",\".\",\".\",\".\",\"2\",\"8\",\".\"]\r\n,[\".\",\".\",\".\",\"4\",\"1\",\"9\",\".\",\".\",\"5\"]\r\n,[\".\",\".\",\".\",\".\",\"8\",\".\",\".\",\"7\",\"9\"]]\r\n";

            int[,] sudokuArr = splitingTheString(stringStart);

            for (int i = 0; i < 10; i++)
            {
               
                for (int j = 0; j < 10; j++)
                {
                   bool resultRow = istheNumberUnique(sudokuArr[0,0],sudokuArr);


                }
                Console.WriteLine();
            }
         
        }

        static int[,] splitingTheString(string stringStart)
        {
            int[,] sudokuArr = new int[9, 9];
            char[] separators = new char[] { '\n' };
            string[] rowsEntered = stringStart.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int i = 0; int j = 0;
            foreach (string row in rowsEntered)
            {
                char[] separatorsRow = new char[] { '\"' };
                string[] elementsInRow = row.Split(separatorsRow, StringSplitOptions.RemoveEmptyEntries);
                int k = 0;
                for (j = 1; j < 18; j = j + 2)
                {
                    if (int.TryParse(elementsInRow[j], out int number) == true)
                    {
                        int valueInNumber = Convert.ToInt16(elementsInRow[j]);
                        sudokuArr[i, k] = valueInNumber;
                    }
                    else
                    {
                        sudokuArr[i, k] = 0;
                    }
                    k++;
                }
                i = i + 1;

            }
            return sudokuArr;
        }

        static bool istheNumberUnique(int valueToSearch, int[] arrayToSearch)
        {
            bool resultToReturn = true;
            int numberOfOccurrences = 0;
            foreach (int value in arrayToSearch)
            {
                if (value == valueToSearch)
                {
                    numberOfOccurrences++;
                }
            }
            return (numberOfOccurrences == 1);
        }
    }
}
