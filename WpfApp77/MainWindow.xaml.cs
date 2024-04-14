using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ArrayManipulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveArrayToFile_Click(object sender, RoutedEventArgs e)
        {
            string[] elements = ArrayElementsTextBox.Text.Split(',');
            string filePath = "array.txt";

            try
            {
                File.WriteAllLines(filePath, elements);
                OutputTextBlock.Text = "Array elements saved to file successfully.";
            }
            catch (Exception ex)
            {
                OutputTextBlock.Text = $"Error saving array elements to file: {ex.Message}";
            }
        }

        private void LoadArray_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "array.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string[] elements = File.ReadAllLines(filePath);
                    ArrayElementsTextBox.Text = string.Join(",", elements);
                    OutputTextBlock.Text = "Array loaded from file successfully.";
                }
                else
                {
                    OutputTextBlock.Text = "File does not exist.";
                }
            }
            catch (Exception ex)
            {
                OutputTextBlock.Text = $"Error loading array from file: {ex.Message}";
            }
        }
    }
}
