using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dziennik_Klasy
{
    public partial class AddEditStudent : Form
    {
        public delegate void MySimpleDelegate();
        public event MySimpleDelegate StudentAdded;

        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");
        private int _studentId;
        private Student _student;
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);
        public AddEditStudent(int id = 0)
        {

            InitializeComponent();
            _studentId = id;

            GetStudentData();

            tbFirstName.Select();
        }
        public void OnStudentAdded()
        {
            StudentAdded?.Invoke();
        }
        private void GetStudentData()

        {
            if (_studentId != 0)
            {

                Text = "Edytowanie Danych Ucznia";
                var students = _fileHelper.DeserializeFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studentId);

                if (_student == null)
                {
                    throw new Exception("Brak uzytkownika o podanym Id");
                }
                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {
            tbID.Text = _student.Id.ToString();
            tbFirstName.Text = _student.firstName;
            tbLastName.Text = _student.lastName;
            tbMath.Text = _student.Math;
            tbPhysics.Text = _student.Physics;
            tbForeignLang.Text = _student.ForeignLang;
            tbPolishLang.Text = _student.PolishLang;
            tbTechnology.Text = _student.Technology;
            rtbComments.Text = _student.comments;
            tbGroupId.Text = _student.GroupId.ToString();
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_studentId != 0)
                students.RemoveAll(x => x.Id == _studentId);
            else
                AssignIdToNewStudent(students);
            AddNewUserToList(students);

            _fileHelper.SerializeToFile(students);

            OnStudentAdded();


            Close();

        }

        private void AddNewUserToList(List<Student> students)
        {
            var student = new Student
            {
                Id = _studentId,
                firstName = tbFirstName.Text,
                lastName = tbLastName.Text,
                comments = rtbComments.Text,
                ForeignLang = tbForeignLang.Text,
                Physics = tbPhysics.Text,
                Math = tbMath.Text,
                PolishLang = tbPolishLang.Text,
                Technology = tbTechnology.Text,
                Activities = CheckBoxCheck(chbActivities),
                GroupId = tbGroupId.Text,

            };
            students.Add(student);
        
        }

        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();
            
            _studentId = studentWithHighestId == null ? 1 : studentWithHighestId.Id + 1;

        }
     

        private bool CheckBoxCheck (CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                return true;
            }
            return false;
        }

        private void AddEditStudent_Load(object sender, EventArgs e)
        {

        }

        private bool chbActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chbActivities.Checked)
            {
                _student.Activities = true;
                return true;
            }
            else 
            { 
                _student.Activities = false;
                return false;
            }
            
      
        }
    }
}
