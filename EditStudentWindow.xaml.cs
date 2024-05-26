using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kolokvijum2.Models;


//



namespace Kolokvijum2
{
    public partial class EditStudentWindow : Window
    {
        private SchoolContext context;
        private Student student;
        private DataGrid _dg;
        public EditStudentWindow(SchoolContext context, Student student, DataGrid dg)
        {
            InitializeComponent();
            this.context = context;
            this.student = student;
            this._dg = dg;

            //povezivanje polja
           
            FirstNameTextBox.Text = student.FirstName;
            LastNameTextBox.Text = student.LastName;
            AgeTextBox.Text = student.Age.ToString();
            GenderComboBox.SelectedIndex = student.Gender == "musko" ? 0 : 1;
            for (int i = 0; i < YearComboBox.Items.Count; i++)
            {
                ComboBoxItem cb = (ComboBoxItem)YearComboBox.Items[i];
                if (cb.Content.ToString() == student.YearOfStudy.ToString())
                {
                    YearComboBox.SelectedIndex = i;
                    i = 999;
                }
            }

            if (context.Schools.Count() == 0)
            {
                MessageBox.Show("Doslo je do problema, kontaktirajte administratora!");
                this.Close();
            }
            List<string> list = new List<string>();
            foreach (var x in context.Schools.ToList())
            {
                list.Add(x.Name);
                SchoolComboBox.Items.Add(x.Name);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == student.School.Name)
                {
                    SchoolComboBox.SelectedIndex = i;
                    break;
                }
            }

            if (SchoolComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Doslo je do problema, skola nije pronadjena u bazi!");
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            student.FirstName = FirstNameTextBox.Text;
            student.LastName = LastNameTextBox.Text;
            student.Age = int.Parse(AgeTextBox.Text);
            student.Gender = (string)(GenderComboBox.SelectedItem as ComboBoxItem).Content;
            student.YearOfStudy = int.Parse((string)(YearComboBox.SelectedItem as ComboBoxItem).Content);
            string schoolName = SchoolComboBox.SelectedItem.ToString()!;
            School? school = context.Schools.FirstOrDefault(p => p.Name == schoolName);
            if (school == null)
            {
                MessageBox.Show("Doslo je do problema probajte ponovo!", "Greska!");
                return;
            }
            student.SchoolId = school.Id;
            student.School = school;

            context.Update(student);
            context.SaveChanges();
            _dg.Items.Refresh();
            //CLOSEEE
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
