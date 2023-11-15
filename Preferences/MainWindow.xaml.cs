using System.Windows;
using System.Windows.Controls;

namespace Preferences
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            if (sportRadioButton.IsChecked == true) { resultTextBlock.Text += sportRadioButton.Content; }
            if (musicRadioButton.IsChecked == true) { resultTextBlock.Text += musicRadioButton.Content; }
            if (foodRadioButton.IsChecked == true) { resultTextBlock.Text += foodRadioButton.Content; }
        }

        private void ClearSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            sportRadioButton.IsChecked = false;
            musicRadioButton.IsChecked = false;
            foodRadioButton.IsChecked = false;

            resultTextBlock.Text = "Selected preferences: ";
        }
    }
}
