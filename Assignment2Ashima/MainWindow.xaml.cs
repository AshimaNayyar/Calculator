/* Done by Ashima Ashima*/

using System;
using System.Collections.Generic;
using System.Data;
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

namespace Assignment2Ashima
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create and show the login page
            LoginPage loginPage = new LoginPage();
            loginPage.ShowDialog();

            // Check if the login was successful
            if (!loginPage.LoginSuccessful)
            {
                // If not successful, close the application
                Close();
            }
            else
            {
                // If successful, show the main window
                Visibility = Visibility.Visible;
            }
        }


        // Event handler for text changed in result textbox
        private void TB_Result_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Get the clicked button
                Button button = (Button)sender;
                // Extract the text content of the button
                string buttonText = button.Content.ToString();

                // Switch on the button content to determine the action
                switch (buttonText)
                {
                    // If the button is "=", evaluate the expression
                    case "=":
                        try
                        {
                            string result = new DataTable().Compute(TB_Result.Text, null).ToString();
                            TB_Result.Text = result;
                        }
                        catch (Exception)
                        {
                            TB_Result.Text = "Error!";
                        }
                        break;
                    // If the button is "R", remove the last character from the result
                    case "R":
                        if (TB_Result.Text.Length > 0)
                            TB_Result.Text = TB_Result.Text.Remove(TB_Result.Text.Length - 1);
                        break;
                    
                    // If the button is "Del", clear the result textbox
                    case "Del":
                        TB_Result.Text = "";
                        break;

                    // If the button is "Off", shutdown the application
                    case "Off":
                        Application.Current.Shutdown();
                        break;

                     // If the button is an arithmetic operation, append it to the result textbox
                     case "+":
                     case "-":
                     case "*":
                     case "/":
                       TB_Result.Text += buttonText;
                       break;

                     default:
                        TB_Result.Text += buttonText;
                        break;
                }
            }
        private void Off_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main window (calculator)
            this.Visibility = Visibility.Hidden;

            // Show the login window
            LoginPage loginPage = new LoginPage();
            loginPage.ShowDialog();

            // Check if the login was successful
            if (!loginPage.LoginSuccessful)
            {
                // If not successful, close the application
                Application app = Application.Current;
                if (app != null)
                {
                    app.Shutdown();
                }
            }
            else
            {
                // If successful, show the main window
                this.Visibility = Visibility.Visible;
            }
        }

    }


}


