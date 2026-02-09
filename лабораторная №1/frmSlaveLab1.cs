using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    /// <summary>
    /// Основной класс формы для приложения.
    /// </summary>
    public partial class frmSlaveLab1 : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="frmSlaveLab1"/>.
        /// </summary>
        public frmSlaveLab1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вычисляет скалярное произведение двух векторов.
        /// </summary>
        /// <param name="vectorA">Первый вектор.</param>
        /// <param name="vectorB">Второй вектор.</param>
        /// <returns>Скалярное произведение векторов.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если векторы имеют разную длину.</exception>
        private double DotProduct(double[] vectorA, double[] vectorB)
        {
            if (vectorA.Length != vectorB.Length)
                throw new ArgumentException("Векторы должны быть одинаковой длины");

            double result = 0;
            for (int i = 0; i < vectorA.Length; i++)
            {
                result += vectorA[i] * vectorB[i];
            }
            return result;
        }

        /// <summary>
        /// Умножает матрицу на вектор.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        /// <param name="vector">Вектор.</param>
        /// <returns>Результирующий вектор после умножения.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество
        /// столбцов в матрице не совпадает с длиной вектора.</exception>
        private double[] MatrixVectorMultiplication(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols != vector.Length)
                throw new ArgumentException("Количество столбцов в матрице должно совпадать с длиной вектора");

            double[] result = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                result[i] = 0;
                for (int j = 0; j < cols; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }
            return result;
        }

        /// <summary>
        /// Парсит строку и преобразует её в матрицу.
        /// </summary>
        /// <param name="matrixText">Строка, представляющая матрицу.</param>
        /// <returns>Двумерный массив, представляющий матрицу.</returns>
        private double[,] ParseMatrix(string matrixText)
        {
            string[] rows = matrixText.Split(';');
            int rowCount = rows.Length;
            int colCount = rows[0].Split(',').Length;

            double[,] matrix = new double[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                double[] row = Array.ConvertAll(rows[i].Split(','), s 
                    => double.Parse(s, CultureInfo.InvariantCulture));
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для вычисления скалярного произведения.
        /// </summary>
        /// <param name="sender">Объект-источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnCalculateDotProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Преобразуем введенные строки в массивы double
                double[] vectorA = Array.ConvertAll(txtVectorA.Text.Split(','), s 
                    => double.Parse(s, CultureInfo.InvariantCulture));
                double[] vectorB = Array.ConvertAll(txtVectorB.Text.Split(','), s 
                    => double.Parse(s, CultureInfo.InvariantCulture));

                // Вычисляем скалярное произведение
                double result = DotProduct(vectorA, vectorB);

                // Выводим результат
                lblResult.Text = $"Скалярное произведение: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для умножения матрицы на вектор.
        /// </summary>
        /// <param name="sender">Объект-источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnMatrixVectorMultiplication_Click(object sender, EventArgs e)
        {
            try
            {
                // Преобразуем введенную строку в матрицу double
                double[,] matrix = ParseMatrix(txtMatrix.Text);

                // Преобразуем введенную строку в вектор double
                double[] vector = Array.ConvertAll(txtVector.Text.Split(','), s 
                    => double.Parse(s, CultureInfo.InvariantCulture));

                // Выполняем умножение матрицы на вектор
                double[] result = MatrixVectorMultiplication(matrix, vector);

                // Выводим результат
                lblResult.Text = $"Результат умножения матрицы на вектор: {string.Join(", ", result)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
