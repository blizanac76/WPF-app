using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Kolokvijum2.Models;
using MySql.Data.MySqlClient;


//dodavanje studenta
namespace Kolokvijum2
{
    public partial class AddStudentWindow : Window
    {
        private SchoolContext _context;

        public AddStudentWindow(SchoolContext context)
        {
            InitializeComponent();
            this._context = context;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> lista = _context.Schools.Select(p => p.Name).ToList();
            // Nema skola registrovanih
            if (lista.Count == 0) 
            {
                MessageBox.Show("Nema skola registrovanih, prvo registrujte skolu!", "Upozorenje!");
                this.Close();
            }
            SchoolComboBox.ItemsSource = _context.Schools.Select(p => p.Name).ToList();
            SchoolComboBox.SelectedIndex = 0;
            GenderComboBox.SelectedIndex = 0;
            YearComboBox.SelectedIndex = 0;
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            try
            {

                //Student s = new Student()
                //{
                //    Index = "TestInd",
                //    Age = 20,
                //    Degree = "Racuncarstvo",
                //    DegreeCode = "",
                //    FirstName = "Aleksa",
                //    LastName = "Crveni",
                //    Gender = "Muski",
                //    Grade = "Prvi",
                //    SchoolId = 1
                //};
                //_context.Students.Add(s);
                //_context.SaveChanges();


                //foreach (var x in _context.Schools.ToList())
                //{
                //    lista.Add(x.Name);
                //    SchoolComboBox.Items.Add(x.Name);
                //}

                int broj = 0;
                if (FirstNameTextBox.Text.Trim().Length > 50 || FirstNameTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("ime Mora ime biti u opsegu 1-50 karaktera");
                    return;
                }
                if (LastNameTextBox.Text.Trim().Length > 50 || LastNameTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("prezime Mora ime biti u opsegu 1-50 karaktera");
                    return;
                }
                if (int.Parse(AgeTextBox.Text) < 7 || int.Parse(AgeTextBox.Text) > 120)
                {
                    MessageBox.Show("Godine moraju biti ispravne");
                    return;
                }
                string firstName = FirstNameTextBox.Text.Trim();
                string lastName = LastNameTextBox.Text.Trim();
                int age = int.Parse(AgeTextBox.Text);
                string gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
                string selectedSchool = SchoolComboBox.SelectedItem.ToString();
                int schoolId = _context.Schools.FirstOrDefault(p => p.Name == selectedSchool)?.Id ?? -1;
                // ovo ne bi trebalo da moze da se desi
                if (schoolId == -1)
                {
                    MessageBox.Show("Doslo je do problema, aplikacija ce se zatvoriti!");
                    Application.Current.Shutdown();
                }
                int yearOfStudy = int.Parse(((ComboBoxItem)YearComboBox.SelectedItem).Content.ToString());
                //unos studenta na osnovu podataka unetih iz windowa
                string index = Guid.NewGuid().ToString();
                index = index.Substring(0, index.IndexOf("-"));
                student.Index = index;
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Gender = gender;
                student.SchoolId = schoolId;
                student.YearOfStudy = yearOfStudy;

                _context.Students.Add(student);
                _context.SaveChanges();

                MessageBox.Show("ovo je proslo, dodat je student u xontext");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Vrlo vrlo retka situacija posto je guid skoro uvek unique
                    if (ex.InnerException.Message.Contains("Duplicate entry") || ex.InnerException.Message.Contains("Index"))
                    {
                        _context.Students.Remove(student);
                        MessageBox.Show("Doslo je do problema, pokusajte ponovo!");
                        return;
                    }
                }
                if (student.Index != "")
                {
                    _context.Students.Remove(student);
                }
                MessageBox.Show("exception u dodavanjustuednta u kolekciju studenata iz conteza   : " + ex.Message);

            }
            //catch baca exception
            //try
            //{
            //    string firstName = FirstNameTextBox.Text;
            //    string lastName = LastNameTextBox.Text;
            //    int age = int.Parse(AgeTextBox.Text);
            //    string gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
            //    School selectedSchool = (School)SchoolComboBox.SelectedItem;
            //    int yearOfStudy = int.Parse(((ComboBoxItem)YearComboBox.SelectedItem).Content.ToString());

            //    //unos studenta na osnovu podataka unetih iz windowa
            //    var student = new Student
            //    {
            //        FirstName = firstName,
            //        LastName = lastName,
            //        Age = age,
            //        Gender = gender,
            //        SchoolId = selectedSchool.SchoolId,
            //        YearOfStudy = yearOfStudy
            //    };

            //    //context.Student.Add(student);
            //    context.SaveChanges();

            //    MessageBox.Show("ovo je proslo, dodat je student u xontext");
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("exception u dodavanjustuednta u kolekciju studenata iz conteza   : " + ex.Message);
            //}
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
