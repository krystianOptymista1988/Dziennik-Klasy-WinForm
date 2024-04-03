using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Dziennik_Klasy.Properties;


namespace Dziennik_Klasy
{
    public partial class Main : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");

        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Path.Combine(Program.FilePath));

        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }
            set
            {
                Settings.Default.IsMaximize = value;
            }
        }
        public Main()
        {
            InitializeComponent();
            RefreshDiary();
            SetColumnsHeader();

            if (IsMaximize)
            {
                WindowState = FormWindowState.Maximized;
            }

        }

        private void SetColumnsHeader()
        {
            dgvStudentsDiary.Columns[0].HeaderText = "Numer";
            dgvStudentsDiary.Columns[1].HeaderText = "Imię";
            dgvStudentsDiary.Columns[2].HeaderText = "Nazwisko";
            dgvStudentsDiary.Columns[3].HeaderText = "Uwagi";
            dgvStudentsDiary.Columns[4].HeaderText = "Matematyka";
            dgvStudentsDiary.Columns[5].HeaderText = "Technologia";
            dgvStudentsDiary.Columns[6].HeaderText = "Fizyka";
            dgvStudentsDiary.Columns[7].HeaderText = "Język polski";
            dgvStudentsDiary.Columns[8].HeaderText = "Język obcy";
            dgvStudentsDiary.Columns[9].HeaderText = "Dodatkowe zajęcia";

        }

        private void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();

            dgvStudentsDiary.DataSource = students;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.StudentAdded += AddEditStudent_StudentAdded;
            addEditStudent.ShowDialog();
            addEditStudent.StudentAdded -= AddEditStudent_StudentAdded;
        }

        private void AddEditStudent_StudentAdded()
        {
            RefreshDiary();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudentsDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz ucznia którego dane chcesz edytować");
                return;
            }

            var addEditStudent = new AddEditStudent(Convert.ToInt32(dgvStudentsDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.ShowDialog();

        }

        private void tbnDelete_Click(object sender, EventArgs e)
        {

            if (dgvStudentsDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz ucznia którego dane chcesz usunąć");
                return;
            }

            var selectedSudent = dgvStudentsDiary.SelectedRows[0];
            var confirmDelete = MessageBox.Show($@"czy napewno chcesz usunąć ucznia: {(selectedSudent.Cells[1].Value.ToString() + " " + selectedSudent.Cells[2].Value.ToString()).Trim()}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedSudent.Cells[0].Value));
                RefreshDiary();
                
            }

        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                IsMaximize = true;
            }
            else
            {
                IsMaximize = false;
            }
            Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbGroup.SelectedValue.ToString();
            
        }
    }
}
