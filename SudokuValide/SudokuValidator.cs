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
        private int[,] sudokuArr = new int[SIZE_SUDOKU, SIZE_SUDOKU];

        /// <summary>
        /// Checking sudoku array [,] is valide by columns, rows and squares 
        /// </summary>
        /// <param name="sudokuArr"></param>
        /// <returns> bool true/false </returns>
        public bool checkingSudokuArray(int[,] sudokuArr)
        {
            bool result = true;

            for (int i = 0; i < SIZE_SUDOKU; i++)
            {
                for (int j = 0; j < SIZE_SUDOKU; j++)//Checking each element in sudokuArr by Row, Column and Square
                {
                    if (!isRowValid(sudokuArr[i, j], i)) return false;

                    if (!isColumnValid(sudokuArr[i, j], j)) return false;

                    if (!isCurrentSquareValid(sudokuArr[i, j], i,j)) return false;
                }
            }
            return result;
        }

        /// <summary>
        /// Spliting the string sudoku into int array [,]
        /// </summary>
        /// <param name="stringStart"></param>
        /// <returns> int array [,]</returns>
        public int[,] splitingTheString(string stringStart) //Splitting entered string 
        {
            //int[,] sudokuArr = new int[SIZE_SUDOKU, SIZE_SUDOKU];
            char[] separators = new char[] { '\r' }; //Splitting the string into rows

            stringStart = clearStringOfExtraCharacters(stringStart); //Clear of extra characters

            string[] rowsEntered = stringStart.Split(separators, StringSplitOptions.RemoveEmptyEntries);// In rowsEntered we have an array of each row sudoku

            for (int i = 0; i < SIZE_SUDOKU; i++) //Splitting each row into array[,]
            {
                char[] separatorsRow = new char[] { '\"' };
                string[] elementsInRow = rowsEntered[i].Split(separatorsRow, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < SIZE_SUDOKU; j++)
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
        /// Return true if column is valid
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="columnNumber"></param>
        /// <returns>int array[]</returns>
        public bool isColumnValid(int currentValue, int columnNumber)
        {
            bool resultToReturn = true; int numberOfOccurrences = 0;

            for (int i = 0; i < SIZE_SUDOKU; i++)
            {
                if (sudokuArr[i, columnNumber] == currentValue) numberOfOccurrences++;

            }
            if (numberOfOccurrences > 1 && currentValue != 0) resultToReturn = false;

            return resultToReturn;

        }

        /// <summary>
        /// Return true if row is valid
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="rowNumber"></param>
        /// <returns> int array[] </returns>
        public bool isRowValid(int currentValue, int rowNumber)
        {
            bool resultToReturn = true; int numberOfOccurrences = 0;

            for (int i = 0; i < SIZE_SUDOKU; i++)
            {
                if (sudokuArr[rowNumber, i] == currentValue) numberOfOccurrences++;

            }
            if (numberOfOccurrences > 1 && currentValue != 0) resultToReturn = false;

            return resultToReturn;
        }

        /// <summary>
        /// Return true if square by column & row is valid
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="rowNumber"></param>
        /// <param name="columnNumber"></param>
        /// <returns>int array[] </returns>
        public bool isCurrentSquareValid(int currentValue,int rowNumber, int columnNumber)
        {
            // Array for checking square
            //int[] square = new int[SIZE_SUDOKU];
            bool resultToReturn = true; int numberOfOccurrences = 0;
            int startSquareRow = (rowNumber / SQUARE_LENGHT) * SQUARE_LENGHT;
            int startSquareColumn = (columnNumber / SQUARE_LENGHT) * SQUARE_LENGHT;

            for (int i = startSquareRow; i < startSquareRow + SQUARE_LENGHT; i++)
            {
                for (int j = startSquareColumn; j < startSquareColumn + SQUARE_LENGHT; j++)
                {
                    if (sudokuArr[i, j] == currentValue) numberOfOccurrences++;
                }
            }
            if (numberOfOccurrences > 1 && currentValue != 0) resultToReturn = false;
            return resultToReturn;
        }

        
    }

}
