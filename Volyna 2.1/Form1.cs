using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Volyna_2._1;

namespace Volyna_2._1
{
    public partial class Form1 : Form
    {
        private void CreateMatrixGrid(int size)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;

            for (int i = 0; i < size; i++)
            {
                dataGridView1.Columns.Add($"col{i}", $"C{i + 1}");
                dataGridView1.Columns[i].Width = 40;
            }

            for (int i = 0; i < size; i++)
            {
                dataGridView1.Rows.Add();
            }
            //dataGridView1.Cursor = Cursors.Help;
        }
        private void GenerateRandomMatrix(int size, int minValue = -20, int maxValue = 20)
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rand.Next(minValue, maxValue + 1);
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //dataGridView1.Cursor = Cursors.Help;
            string input = e.FormattedValue.ToString();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (!int.TryParse(input, out _) || input != input.TrimStart('0'))
            {
                MessageBox.Show("Некоректне введення! Не можна вводити числа з зайвими нулями (наприклад, 01, 0020 і т.д.)", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] matrix = MatrixLogic.GetMatrixFromDataGridView(dataGridView1);
                int sumRows = MatrixLogic.SumRowsWithoutNegatives(matrix);
                int minDiag = MatrixLogic.MinSumOfMainDiagonals(matrix);

                textBoxSum.Text = sumRows.ToString();
                textBoxMin.Text = minDiag.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CreateMatrixGrid(4);
            //dataGridView1.CellValidating += dataGridView1_CellValidating;
            int size = 4;
            CreateMatrixGrid(size);
            GenerateRandomMatrix(size);
            dataGridView1.CellValidating += dataGridView1_CellValidating;

        }
    }
}
