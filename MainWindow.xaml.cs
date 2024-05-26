using Kolokvijum2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Kolokvijum2
{
    public partial class MainWindow : Window
    {
        private readonly SchoolContext _context;

        public MainWindow(SchoolContext context)
        {
            InitializeComponent();
            _context = context;
            LoadData();
        }
   
        private void LoadData()
        {
            //ucitavanja u listu svih studenata iz skole
            _context.Schools.Load();
            SchoolsDataGrid.ItemsSource = _context.Schools.Local.ToObservableCollection();

            _context.Students.Load();
            StudentsDataGrid.ItemsSource = _context.Students.Local.ToObservableCollection();
        }

        protected void AddSchoolButton_Click(object sender, RoutedEventArgs e)
        {
            
            AddSchoolWindow w = new AddSchoolWindow(_context);
            w.Show();
        }
        protected void AddStudentButton_Click(object sender, RoutedEventArgs e) 
        {
            AddStudentWindow w = new AddStudentWindow(_context);
            w.Show();
        }

        protected void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            int sIndex = StudentsDataGrid.SelectedIndex;

            if (sIndex == -1)
            {
                MessageBox.Show("Ucenik mora biti selektovan!");
                return;
            }

            Student s = (Student)StudentsDataGrid.SelectedItem;
            EditStudentWindow w = new EditStudentWindow(_context, s, StudentsDataGrid);
            w.Show();
        }
        protected void DeleteStudentButton_Click(object sender, RoutedEventArgs e) {
            try
            {
                int sIndex = StudentsDataGrid.SelectedIndex;
                if (sIndex == -1)
                {
                    MessageBox.Show("Ucenik mora biti prvo selektrovan!", "Upozorenje!");
                    return;
                }

                MessageBoxResult res = MessageBox.Show("Da li ste sigurni da zelite da obrisete djaka?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                    return;
                Student s = (Student)StudentsDataGrid.SelectedItem;
                _context.Students.Remove(s);
                _context.SaveChanges();
            } catch(Exception ex)
            {
                MessageBox.Show("Doslo je do greske, pokusajte ponovo!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void SchoolsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //
            for (int i = SchoolsDataGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (SchoolsDataGrid.Columns[i].Header.ToString() == "Students")
                    SchoolsDataGrid.Columns.Remove(SchoolsDataGrid.Columns[i]);
            }

            for (int i = StudentsDataGrid.Columns.Count - 1; i >= 0; i--)
            {
                if (StudentsDataGrid.Columns[i].Header.ToString() == "School")
                    StudentsDataGrid.Columns.Remove(StudentsDataGrid.Columns[i]);
            }
        }
    }
}
