using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQLContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            name.Text = contact.Name;
            email.Text = contact.Email;
            phone.Text = contact.PhoneNumber;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = name.Text;
            contact.Email = email.Text;
            contact.PhoneNumber = phone.Text;
            SQLiteConnection connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Contact>();
            connection.Update(contact);
            connection.Close();
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Contact>();
            connection.Delete(contact);
            connection.Close();
            Close();

        }
    }
}
