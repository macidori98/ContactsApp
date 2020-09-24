using ContactsApp.Classes;

using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp.Controls
{
  /// <summary>
  /// Interaction logic for ContactControl.xaml
  /// </summary>
  public partial class ContactControl : UserControl
  {
    public Contacts Contact
    {
      get { return (Contacts)GetValue(ContactProperty); }
      set { SetValue(ContactProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ContactProperty =
        DependencyProperty.Register("Contact", typeof(Contacts), typeof(ContactControl), new PropertyMetadata(null, SetText));

    private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ContactControl control = d as ContactControl;

      if (control != null)
      {
        control.nameTextBlock.Text = (e.NewValue as Contacts).Name;
        control.emailTextBlock.Text = (e.NewValue as Contacts).Email;
        control.phoneNumberTextBlock.Text = (e.NewValue as Contacts).PhoneNumber;
      }
    }

    public ContactControl()
    {
      InitializeComponent();
    }
  }
}