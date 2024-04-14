using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace FileStatistics
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetFileStatistics_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int sentenceCount = lines.Length;
                    int uppercaseCount = 0;
                    int lowercaseCount = 0;
                    int vowelCount = 0;
                    int consonantCount = 0;
                    int digitCount = 0;

                    foreach (string line in lines)
                    {
                        foreach (char c in line)
                        {
                            if (char.IsUpper(c))
                            {
                                uppercaseCount++;
                            }
                            else if (char.IsLower(c))
                            {
                                lowercaseCount++;
                                if ("aeiouAEIOU".IndexOf(c) != -1)
                                {
                                    vowelCount++;
                                }
                                else
                                {
                                    consonantCount++;
                                }
                            }
                            else if (char.IsDigit(c))
                            {
                                digitCount++;
                            }
                        }
                    }

                    StatisticsTextBlock.Text = $"Number of sentences: {sentenceCount}\n" +
                                                $"Number of uppercase letters: {uppercaseCount}\n" +
                                                $"Number of lowercase letters: {lowercaseCount}\n" +
                                                $"Number of vowels: {vowelCount}\n" +
                                                $"Number of consonants: {consonantCount}\n" +
                                                $"Number of digits: {digitCount}";
                }
                else
                {
                    StatisticsTextBlock.Text = "File not found.";
                }
            }
            catch (Exception ex)
            {
                StatisticsTextBlock.Text = $"Error: {ex.Message}";
            }
        }
    }
}
