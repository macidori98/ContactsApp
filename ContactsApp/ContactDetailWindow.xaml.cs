using ContactsApp.Classes;

using SQLite;

using System.Windows;

namespace ContactsApp
{
  /// <summary>
  /// Interaction logic for ContactDetailWindow.xaml
  /// </summary>
  public partial class ContactDetailWindow : Window
  {
    private Contacts contact;

    public ContactDetailWindow(Contacts contact)
    {
      InitializeComponent();
      this.contact = contact;
      this.nameTextBox.Text = this.contact.Name;
      this.phoneNumberTextBox.Text = this.contact.PhoneNumber;
      this.emailTextBox.Text = this.contact.Email;
    }

    private void updateButton_Click(object sender, RoutedEventArgs e)
    {
      this.contact.Name = this.nameTextBox.Text;
      this.contact.PhoneNumber = this.phoneNumberTextBox.Text;
      this.contact.Email = this.emailTextBox.Text;

      using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
      {
        connection.CreateTable<Contacts>();
        connection.Update(contact);
      }
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
      using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
      {
        connection.CreateTable<Contacts>();
        connection.Delete(contact);
      }

      this.Close();
    }
  }
}