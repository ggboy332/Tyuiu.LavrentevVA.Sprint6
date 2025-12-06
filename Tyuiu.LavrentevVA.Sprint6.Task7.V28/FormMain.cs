using System;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.LavrentevVA.Sprint6.Task7.V28.Lib;

namespace Tyuiu.LavrentevVA.Sprint6.Task7.V28
{
    public partial class FormMain : Form
    {
        private int[,]? _inputMatrix;
        private int[,]? _outputMatrix;
        private readonly DataService _dataService = new DataService();

        public FormMain()
        {
            InitializeComponent();

            // Wire up buttons that designer doesn't assign
            button2.Click += ButtonSave_Click;
            button3.Click += ButtonExecute_Click;

            // Optional: set dialog defaults
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.FileName = "OutPutFileTask7.csv";

            // Initial grid formatting
            ConfigureGridAppearance(dataGridView1);
            ConfigureGridAppearance(dataGridView2);
        }

        // Load button (designer wired)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                string path = openFileDialog1.FileName;

                _inputMatrix = _dataService.GetMatrix(path);

                if (_inputMatrix == null || _inputMatrix.GetLength(0) == 0 || _inputMatrix.GetLength(1) == 0)
                {
                    MessageBox.Show("Файл не содержит корректную матрицу.");
                    return;
                }

                FillDataGrid(dataGridView1, _inputMatrix);

                // Clear output
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                _outputMatrix = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}");
            }
        }

        // Execute button (button3)
        private void ButtonExecute_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_inputMatrix == null)
                {
                    MessageBox.Show("Сначала загрузите файл с матрицей.");
                    return;
                }

                _outputMatrix = _dataService.ProcessMatrix(_inputMatrix);
                FillDataGrid(dataGridView2, _outputMatrix);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении обработки: {ex.Message}");
            }
        }

        // Save button (button2)
        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_outputMatrix == null)
                {
                    MessageBox.Show("Нет данных для сохранения. Выполните обработку сначала.");
                    return;
                }

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                _dataService.SaveToFile(saveFileDialog1.FileName, _outputMatrix);
                MessageBox.Show("Файл успешно сохранён.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        // Helper: fill DataGridView from matrix
        private void FillDataGrid(DataGridView dgv, int[,] matrix)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
                return;

            for (int c = 0; c < cols; c++)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "C" + c;
                col.HeaderText = string.Empty;
                col.Width = 40;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns.Add(col);
            }

            dgv.Rows.Add(rows);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    dgv[c, r].Value = matrix[r, c];
                }
            }

            // Apply consistent sizing
            // Let DataGridView size columns to fit content to avoid clipping (ellipsis)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // Keep a consistent row height (optional)
            dgv.RowTemplate.Height = Math.Max(24, dgv.Font.Height + 8);

            // Visual tweaks
            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.Refresh();
        }

        private void ConfigureGridAppearance(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.WhiteSmoke;
            dgv.GridColor = Color.LightGray;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Consolas", 10);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
