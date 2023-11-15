using System.Collections.Generic;
using System.Windows;

namespace Authentication
{

    public partial class MainWindow : Window
    {
        Dictionary<string, string> userAccess = new()
        {
            { "Admin", "123133" },
            { "login", "password" },
            { "Valera", "Va1er4ik" },
            { "Kaban777", "777" },
            { "SupaDupa", "krosav4eg" },
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, RoutedEventArgs e) => MessageBox.Show
        (userAccess.ContainsKey(loginTextBox.Text) && userAccess.ContainsValue(passwordTextBox.Text)
         ? "Authentication successful"
         : "Access denied");
    }
}
