using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            using (SQLiteConnection dbConnection = new SQLiteConnection(App.databasePath))
            {
                dbConnection.CreateTable<Contact>();
                dbConnection.Insert(contact);
            }

            Close();
        }
    }
}
