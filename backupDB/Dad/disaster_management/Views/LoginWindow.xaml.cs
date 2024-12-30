using disaster_management.Services;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace disaster_management.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public string username { get; set; }
        public string password { get; set; }
        private readonly IUserService _userService;
        private const string CredentialsFilePath = "credentials.xml";
        public LoginWindow()
        {
            InitializeComponent();
            // Resolve user service from DI
            _userService = App.ServiceProvider.GetRequiredService<IUserService>();
            username = txtUsername.Text.Trim();
            password = pwdPassword.Password.Trim();
            LoadCredentials();
        }
        private void btnTogglePassword_Click(object sender, RoutedEventArgs e)
        {
            if (pwdPassword.Visibility == Visibility.Visible)
            {
                // Show password as plain text
                txtVisiblePassword.Text = pwdPassword.Password;
                txtVisiblePassword.Visibility = Visibility.Visible;
                pwdPassword.Visibility = Visibility.Collapsed;
                btnTogglePassword.Content = "🔒";
            }
            else
            {
                // Hide password
                pwdPassword.Password = txtVisiblePassword.Text;
                txtVisiblePassword.Visibility = Visibility.Collapsed;
                pwdPassword.Visibility = Visibility.Visible;
                btnTogglePassword.Content = "👁";
            }
        }

     
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //username = txtUsername.Text.Trim();
            //password = pwdPassword.Password.Trim();
            try
            {

          

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var currentUser =  await _userService.ValidateUser(username, password);
            if (currentUser != null)
            {
                if (chkRememberMe.IsChecked == true)
                {
                    SaveCredentials(username, password);
                }
                DialogResult = true; // Login successful
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }
            catch (Exception)
            {

            }
        }

        private void CHeckRemember(object sender, RoutedEventArgs e)
        {
         //   LoadCredentials();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void SaveCredentials(string username, string password)
        {
            var doc = new XDocument(
                new XElement("Credentials",
                    new XElement("Username", username),
                    new XElement("Password", password)
                )
            );
            doc.Save(CredentialsFilePath);
        }

        private void LoadCredentials()
        {
            if (File.Exists(CredentialsFilePath))
            {
                var doc = XDocument.Load(CredentialsFilePath);
                var username = doc.Root.Element("Username")?.Value;
                var password = doc.Root.Element("Password")?.Value;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    txtUsername.Text = username;
                    pwdPassword.Password = password;
                    chkRememberMe.IsChecked = true;
                }
            }
        }

        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                var pwb = sender as PasswordBox;
                password = pwb.Password;
            }
            catch (Exception)
            {

             
            }
          

        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var textbox = sender as TextBox;
                username = textbox.Text;
            }
            catch (Exception)
            {
            }
         
        }

        private void passChangedShow(object sender, TextChangedEventArgs e)
        {
            var pwb = sender as TextBox;
            password = pwb.Text;
        }
    }
    }
