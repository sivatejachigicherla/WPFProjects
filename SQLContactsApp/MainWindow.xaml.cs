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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void newContact_Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        public void ReadDatabase()
        {
            List<Contact> contacts;
            SQLiteConnection conn = new SQLiteConnection(App.databasePath);
            conn.CreateTable<Contact>();
            contacts = conn.Table<Contact>().ToList();

            if(contacts != null)
            {
                //foreach( var c in contacts)
                //{
                //    ListView.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    });
                //}
                contactListView.ItemsSource = contacts;
            }
            conn.Close();

        }

        private void contactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactListView.SelectedItem;
            if(selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReadDatabase();

        }
    }
}
