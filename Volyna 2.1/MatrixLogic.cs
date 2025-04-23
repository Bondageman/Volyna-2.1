using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Volyna_2._1
{
    public static class MatrixLogic
    {
        public static int SumRowsWithoutNegatives(int[,] matrix)
        {
            int totalSum = 0;
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                bool hasNegative = false;
                int rowSum = 0;

                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    rowSum += matrix[i, j];
                }

                if (!hasNegative)
                    totalSum += rowSum;
            }

            return totalSum;
        }

        public static int MinSumOfMainDiagonals(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            List<int> diagonalSums = new List<int>();

            for (int d = 0; d < n; d++)
            {
                int sum = 0;
                for (int i = 0, j = d; j < n; i++, j++)
                {
                    sum += matrix[i, j];
                }
                diagonalSums.Add(sum);
            }

            for (int d = 1; d < n; d++)
            {
                int sum = 0;
                for (int i = d, j = 0; i < n; i++, j++)
                {
                    sum += matrix[i, j];
                }
                diagonalSums.Add(sum);
            }

            return diagonalSums.Min();
        }

        public static int[,] GetMatrixFromDataGridView(DataGridView dgv)
        {
            int rowCount = dgv.RowCount;
            int colCount = dgv.ColumnCount;

            if (rowCount != colCount)
                throw new Exception("Матриця повинна бути квадратною");

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    var cell = dgv.Rows[i].Cells[j].Value;
                    if (cell == null || !int.TryParse(cell.ToString(), out matrix[i, j]))
                        throw new Exception($"Некоректне значення в клітинці, або клітинках");
                }
            }

            return matrix;
        }
    }
}
