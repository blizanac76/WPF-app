using System.Windows;

namespace Kolokvijum2
{
    public partial class ViewStudentWindow : Window
    {
        public ViewStudentWindow(Student student)
        {
            InitializeComponent();
            LoadStudentDetails(student);
        }

        private void LoadStudentDetails(Student student)
        {
            FirstNameTextBlock.Text = student.FirstName;
            LastNameTextBlock.Text = student.LastName;
            AgeTextBlock.Text = student.Age.ToString();
            GenderTextBlock.Text = student.Gender;
            SchoolTextBlock.Text = student.School.Name;
            YearTextBlock.Text = student.YearOfStudy.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
