using ContactsApp.Classes;

using SQLite;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Contacts> contacts;

    public MainWindow()
    {
      InitializeComponent();
      this.contacts = new List<Contacts>();
      this.ReadDatabase();
    }

    private void addNewContactButton_Click(object sender, RoutedEventArgs e)
    {
      NewContactWindow newContactWindow = new NewContactWindow();
      newContactWindow.ShowDialog();

      this.ReadDatabase();
    }

    private void ReadDatabase()
    {
      using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
      {
        connection.CreateTable<Contacts>();
        this.contacts = connection.Table<Contacts>().OrderBy(c => c.Name).ToList();//reading the table
      }

      if (contacts != null)
      {
        //beteszi a listaba az ujat es megjeleniti az egeszet
        this.contactListView.ItemsSource = this.contacts;
      }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      TextBox searchTextBox = sender as TextBox;

      List<Contacts> filteredList = this.contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
      this.contactListView.ItemsSource = filteredList;
    }
  }
}