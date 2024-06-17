using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValide
{

    public class SudokuValidator
    {
        public const int SIZE_SUDOKU = 9;
        public const int SQUARE_LENGHT = 3;

        public bool checkingSudokuArray(int[,] sudokuArr)
        {
            bool result = true;

            for (int i = 0; i < SIZE_SUDOKU; i++)
            {
                int[] row       = getCurrentRow (sudokuArr, i);
                               
                for (int j = 0; j < SIZE_SUDOKU; j++)//Checking each element in sudokuArr by Row, Column and Square
                {
                    if (!istheNumberUnique(sudokuArr[i, j], row)) return false;

                    int[] column = getCurrentColumn(sudokuArr, j);
                    if (!istheNumberUnique(sudokuArr[i, j], column)) return false; 

                    int[] square = getCurrentSquare(sudokuArr, i, j);
                    if (!istheNumberUnique(sudokuArr[i, j], square)) return false;
                }
            }
            return result;
        }

        public int[,] splitingTheString(string stringStart) //Splitting entered string 
        {
            int[,] sudokuArr = new int[SIZE_SUDOKU, SIZE_SUDOKU];
            char[] separators = new char[] { '\r' }; //Splitting the string into rows

            stringStart = clearStringOfExtraCharacters(stringStart); //Clear of extra characters

            string[] rowsEntered = stringStart.Split(separators, StringSplitOptions.RemoveEmptyEntries);// In rowsEntered we have an array of each row sudoku
           
            for (int i = 0; i< SIZE_SUDOKU; i++) //Splitting each row into array[,]
            {
                char[] separatorsRow = new char[] { '\"' };
                string[] elementsInRow = rowsEntered[i].Split(separatorsRow, StringSplitOptions.RemoveEmptyEntries);
                
                for (int j = 0; j < SIZE_SUDOKU ; j++)
                {
                    sudokuArr[i, j] = 0;
                    if (int.TryParse(elementsInRow[j], out int valueInNumber) == true) sudokuArr[i, j] = valueInNumber;
                }
            }
            return sudokuArr;
        }

        private string clearStringOfExtraCharacters(string stringStart)
        {
            stringStart = stringStart.Replace("[", string.Empty);
            stringStart = stringStart.Replace("]", string.Empty);
            stringStart = stringStart.Replace(",", string.Empty);
            stringStart = stringStart.Replace("\n", string.Empty);
            return stringStart;
        }

        /// <summary>
        /// Return an int array[] of column by column number
        /// </summary>
        /// <param name="sudokuArr"></param>
        /// <param name="columnNumber"></param>
        /// <returns>int array[]</returns>
        public int[] getCurrentColumn(int[,] sudokuArr, int columnNumber)
        {
            int[] column = new int[SIZE_SUDOKU];
            for (int i = 0; i < SIZE_SUDOKU; i++) column[i] = sudokuArr[ i, columnNumber];
            return column;
        }

        /// <summary>
        /// Return an int array[] of row by row number
        /// </summary>
        /// <param name="sudokuArr"></param>
        /// <param name="rowNumber"></param>
        /// <returns> int array[] </returns>
        public int[] getCurrentRow(int[,] sudokuArr, int rowNumber)
        {
            int[] row = new int[SIZE_SUDOKU];
            for (int k = 0; k < SIZE_SUDOKU; k++) row[k] = sudokuArr[rowNumber, k];
            return row;
        }

        /// <summary>
        /// Return an int array[] of square by column & row numbers
        /// </summary>
        /// <param name="sudokuArr"></param>
        /// <param name="rowNumber"></param>
        /// <param name="columnNumber"></param>
        /// <returns>int array[] </returns>
        public int[] getCurrentSquare(int[,] sudokuArr, int rowNumber, int columnNumber)
        {
            // Array for checking square
            int[] square = new int[SIZE_SUDOKU]; int indexSquare = 0;
            int startSquareRow      = (rowNumber / SQUARE_LENGHT) * SQUARE_LENGHT;
            int startSquareColumn   = (columnNumber / SQUARE_LENGHT) * SQUARE_LENGHT;
            
            for (int i = startSquareRow; i < startSquareRow + SQUARE_LENGHT; i++)
            {
                for (int j = startSquareColumn; j < startSquareColumn + SQUARE_LENGHT; j++)
                {
                    square[indexSquare] = sudokuArr[i, j];
                    indexSquare++;
                }
            }
            return square;
        }

        public bool istheNumberUnique(int valueToSearch, int[] arrayToSearch) //Verifying if number is unique in the array []
        {
            bool resultToReturn = true; int numberOfOccurrences = 0;

            foreach (int value in arrayToSearch)
            {
                if (value == valueToSearch) numberOfOccurrences++;
                
            }
            if (numberOfOccurrences > 1 && valueToSearch != 0) resultToReturn = false;

            return resultToReturn;
        }
    }

}
