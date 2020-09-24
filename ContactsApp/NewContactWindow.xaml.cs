using ContactsApp.Classes;

using SQLite;

using System;
using System.IO;
using System.Windows;

namespace ContactsApp
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

    private void saveButton_Click(object sender, RoutedEventArgs e)
    {
      if (this.nameTextBox.Text != "" &&
        this.emailTextBox.Text != "" &&
        this.phoneNumberTextBox.Text != "" &&
        this.IsValidEmail(this.emailTextBox.Text))
      {
        Contacts contact = new Contacts()
        {
          Name = this.nameTextBox.Text,
          Email = this.emailTextBox.Text,
          PhoneNumber = this.phoneNumberTextBox.Text
        };

        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
        {
          connection.CreateTable<Contacts>();
          connection.Insert(contact);
        }
      }

      this.Close();
    }

    private bool IsValidEmail(string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }
  }
}