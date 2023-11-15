using System;
using System.Windows;
using System.Windows.Controls;

namespace HM1_Calculator
{
    public partial class MainWindow : Window
    {
        private string currentNumber = string.Empty;
        private string previousOperation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            switch (content)
            {
                case "C":
                    ClearAll();
                    break;
                case "CE":
                    ClearEntry();
                    break;
                case "<-":
                    Backspace();
                    break;
                case "=":
                    CalculateResult();
                    break;
                default:
                    AppendToCurrentNumber(content);
                    break;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            char operation = button.Content.ToString()[0];

            if (!string.IsNullOrEmpty(currentNumber))
            {
                if (!string.IsNullOrEmpty(previousOperation))
                {
                    CalculateResult();
                    UpdatePreviousOperationTextBox();
                }
                else { previousOperation = currentNumber; }

                currentNumber = string.Empty;
                UpdateCurrentNumberTextBox();

                if (Array.IndexOf(new[] { '+', '-', '*', '/' }, operation) != -1)
                {
                    previousOperation += $" {operation} ";
                    UpdatePreviousOperationTextBox();
                }
            }
        }
        private void ClearAll()
        {
            currentNumber = string.Empty;
            previousOperation = string.Empty;
            UpdateCurrentNumberTextBox();
            UpdatePreviousOperationTextBox();
        }
        private void ClearEntry()
        {
            currentNumber = string.Empty;
            UpdateCurrentNumberTextBox();
        }
        private void Backspace()
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                UpdateCurrentNumberTextBox();
            }
        }
        private void AppendToCurrentNumber(string value)
        {
            currentNumber += value;
            UpdateCurrentNumberTextBox();
        }
        private void CalculateResult()
        {
            double result = Convert.ToDouble(new System.Data.DataTable().Compute($"{previousOperation} {currentNumber}", ""));
            currentNumber = result.ToString();
            UpdateCurrentNumberTextBox();
            previousOperation = string.Empty;
            UpdatePreviousOperationTextBox();
        }
        private void UpdateCurrentNumberTextBox() => currentNumberTextBox.Text = currentNumber;
        private void UpdatePreviousOperationTextBox() => previousOperationTextBox.Text = previousOperation;
    }
}
