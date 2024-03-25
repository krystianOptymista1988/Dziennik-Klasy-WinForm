using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Dziennik_Klasy
{
    public partial class Main : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt"); 
        public Main()
        {
            InitializeComponent();

            var students = DeserializeFromFile();

            dgvStudentsDiary.DataSource = students;
     

        }

        public void SerializeToFile(List<Student> students)
        {
                var serializer = new XmlSerializer(typeof(List<Student>));
            
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }

        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>) serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();  
            addEditStudent.ShowDialog();
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
            var confirmDelete = MessageBox.Show($@"czy napewno chcesz usunąć ucznia: {(selectedSudent.Cells[1].Value.ToString() + " " +  selectedSudent.Cells[2].Value.ToString()).Trim()}","Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                var students = DeserializeFromFile();
                students.RemoveAll(x => x.Id == Convert.ToInt32(selectedSudent.Cells[0].Value));
                SerializeToFile(students);
                dgvStudentsDiary.DataSource = students;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();

            dgvStudentsDiary.DataSource = students;
        }
    }
}
