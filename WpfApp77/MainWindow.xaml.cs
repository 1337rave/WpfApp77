using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileReversal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReverseFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                Array.Reverse(lines);

                string reversedFilePath = Path.Combine(Path.GetDirectoryName(filePath), "reversed_" + Path.GetFileName(filePath));
                File.WriteAllLines(reversedFilePath, lines);

                OutputTextBlock.Text = $"File content reversed and saved to {reversedFilePath}.";
            }
            else
            {
                OutputTextBlock.Text = "File path is invalid.";
            }
        }
    }
}
