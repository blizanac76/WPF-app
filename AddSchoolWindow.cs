using System.Windows;
using Kolokvijum2.Models;

namespace Kolokvijum2
{
    public partial class AddSchoolWindow : Window
    {
        private SchoolContext context;

        public AddSchoolWindow(SchoolContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var school = new School
            {
                Name = NameTextBox.Text,
                Description = "Desc Text",
            };

            context.Schools.Add(school);
            context.SaveChanges();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}