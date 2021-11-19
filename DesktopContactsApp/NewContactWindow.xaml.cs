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

            string databaseName = "Contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = System.IO.Path.Combine(folderPath + databaseName);

            using (SQLiteConnection dbConnection = new SQLiteConnection(databasePath))
            {
                dbConnection.CreateTable<Contact>();
                dbConnection.Insert(contact);
            }

            Close();
        }
    }
}
