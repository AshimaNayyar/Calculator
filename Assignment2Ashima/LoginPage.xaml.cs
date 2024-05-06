using System;
using System.Windows;

namespace Assignment2Ashima
{
    public partial class LoginPage : Window
    {
        public bool LoginSuccessful { get; private set; }
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if login credentials are correct
            if (UsernameTextBox.Text == "ashima" && PasswordBox.Password == "password")
            {
                // Set LoginSuccessful to true
                LoginSuccessful = true;

                // Hide the login window
                Hide();
            }
            else
            {
                MessageBox.Show(" Incorrect login");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the entire application
            if (Application.Current != null)
            {
                Application.Current.Shutdown();
            }

        }
    }
}
