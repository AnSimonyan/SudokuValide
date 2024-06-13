namespace SudokuValide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringStart = "[[\"5\",\"3\",\"6\",\".\",\"7\",\".\",\".\",\".\",\".\"]\r\n,[\".\",\".\",\".\",\"1\",\"9\",\"5\",\".\",\".\",\".\"]\r\n,[\".\",\"9\",\"8\",\".\",\".\",\".\",\".\",\"6\",\".\"]\r\n,[\"8\",\".\",\".\",\".\",\"6\",\".\",\".\",\".\",\"3\"]\r\n,[\"4\",\".\",\".\",\"8\",\".\",\"3\",\".\",\".\",\"1\"]\r\n,[\"7\",\".\",\".\",\".\",\"2\",\".\",\".\",\".\",\"6\"]\r\n,[\".\",\"6\",\".\",\".\",\".\",\".\",\"2\",\"8\",\".\"]\r\n,[\".\",\".\",\".\",\"4\",\"1\",\"9\",\".\",\".\",\"5\"]\r\n,[\".\",\".\",\".\",\".\",\"8\",\".\",\".\",\"7\",\"9\"]]\r\n";
            //string stringStart = "[[\"8\",\"3\",\".\",\".\",\"7\",\".\",\".\",\".\",\".\"]\r\n,[\"6\",\".\",\".\",\"1\",\"9\",\"5\",\".\",\".\",\".\"]\r\n,[\".\",\"9\",\"8\",\".\",\".\",\".\",\".\",\"6\",\".\"]\r\n,[\"8\",\".\",\".\",\".\",\"6\",\".\",\".\",\".\",\"3\"]\r\n,[\"4\",\".\",\".\",\"8\",\".\",\"3\",\".\",\".\",\"1\"]\r\n,[\"7\",\".\",\".\",\".\",\"2\",\".\",\".\",\".\",\"6\"]\r\n,[\".\",\"6\",\".\",\".\",\".\",\".\",\"2\",\"8\",\".\"]\r\n,[\".\",\".\",\".\",\"4\",\"1\",\"9\",\".\",\".\",\"5\"]\r\n,[\".\",\".\",\".\",\".\",\"8\",\".\",\".\",\"7\",\"9\"]]\r\n";
            int[,] sudokuArr = splitingTheString(stringStart); 
            bool result = true;

            for (int i = 0; i < 9; i++)
            {                             
                int[] colums = new int[9];//Array for chechink columns
                for (int k = 0; k < 9; k++) {colums[k] = sudokuArr[k, i]; }
                
                int[] row = new int[9];//Array for checking rows
                for (int k = 0; k < 9; k++) { row[k] = sudokuArr[i, k]; }//Checking columns

                for (int j = 0; j < 9; j++)//Checking each element in sudokuArr by Rows, Columns and Square
                {
                    result = istheNumberUnique(sudokuArr[i, j], row);//Checking Row
                    if (result) { result = istheNumberUnique(sudokuArr[i, j], colums);}//If there is an error we cn stop

                    if (result)
                    {
                        // Array for checking square
                        int[] square = new int[9];
                        int indexSquare = 0;
                        for (int k = (j / 3) * 3; k < (j / 3) * 3 + 3; k++)
                        {
                            for (int l = (j / 3) * 3; l < (j / 3) * 3 + 3; l++)
                            {
                                square[indexSquare] = sudokuArr[k, l];
                                indexSquare++;
                            }
                        }
                        result = istheNumberUnique(sudokuArr[i, j], square);
                        if (!result){ break; }//If there is an error we cn stop
                    }
                }
            }
            Console.WriteLine(result);
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
            if (numberOfOccurrences > 1 && valueToSearch != 0)
            {
                resultToReturn = false;
            }
            return resultToReturn;
        }
    }
}
