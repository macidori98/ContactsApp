using SQLite;

namespace ContactsApp.Classes
{
  public class Contacts
  {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public override string ToString()
    {
      return $"{this.Name} - {this.Email} - {this.PhoneNumber}";
    }
  }
}