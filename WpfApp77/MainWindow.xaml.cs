using System;
using System.IO;
using System.Windows;

namespace ArrayToFile
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
    }
}
