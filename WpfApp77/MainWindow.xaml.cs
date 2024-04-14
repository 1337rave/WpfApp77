using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace FileSearch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchWord = SearchWordTextBox.Text;

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                try
                {
                    ResultsListBox.Items.Clear();

                    // Search for the word in the file
                    string filePath = "sample.txt";
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (Regex.IsMatch(lines[i], @"\b" + Regex.Escape(searchWord) + @"\b", RegexOptions.IgnoreCase))
                        {
                            ResultsListBox.Items.Add($"Line {i + 1}: {lines[i]}");
                        }
                    }

                    // Display search result
                    if (ResultsListBox.Items.Count > 0)
                    {
                        ResultTextBlock.Text = $"{ResultsListBox.Items.Count} occurrences of \"{searchWord}\" found.";
                    }
                    else
                    {
                        ResultTextBlock.Text = $"No occurrences of \"{searchWord}\" found.";
                    }
                }
                catch (Exception ex)
                {
                    ResultTextBlock.Text = $"Error searching for \"{searchWord}\": {ex.Message}";
                }
            }
            else
            {
                ResultTextBlock.Text = "Please enter a search word.";
            }
        }
    }
}
