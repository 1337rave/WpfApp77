using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileStatistics
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            if (File.Exists(filePath))
            {
                List<int> numbers = ReadNumbersFromFile(filePath);

                int positiveCount = numbers.Count(n => n > 0);
                int negativeCount = numbers.Count(n => n < 0);
                int twoDigitCount = numbers.Count(n => n >= 10 && n <= 99);
                int fiveDigitCount = numbers.Count(n => n >= 10000 && n <= 99999);

                OutputTextBlock.Text = $"Positive numbers: {positiveCount}\n" +
                                       $"Negative numbers: {negativeCount}\n" +
                                       $"Two-digit numbers: {twoDigitCount}\n" +
                                       $"Five-digit numbers: {fiveDigitCount}";

                SaveNumbersToFile(numbers.Where(n => n > 0).ToList(), "positive_numbers.txt");
                SaveNumbersToFile(numbers.Where(n => n < 0).ToList(), "negative_numbers.txt");
                SaveNumbersToFile(numbers.Where(n => n >= 10 && n <= 99).ToList(), "two_digit_numbers.txt");
                SaveNumbersToFile(numbers.Where(n => n >= 10000 && n <= 99999).ToList(), "five_digit_numbers.txt");
            }
            else
            {
                OutputTextBlock.Text = "File path is invalid.";
            }
        }

        private List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            return numbers;
        }

        private void SaveNumbersToFile(List<int> numbers, string fileName)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(FilePathTextBox.Text), fileName);
            File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
        }
    }
}
