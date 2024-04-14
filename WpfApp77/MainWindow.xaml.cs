using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Moderator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModerateText_Click(object sender, RoutedEventArgs e)
        {
            string textFilePath = TextFilePathTextBox.Text;
            string moderationFilePath = ModerationFilePathTextBox.Text;

            if (File.Exists(textFilePath) && File.Exists(moderationFilePath))
            {
                string[] moderationWords = File.ReadAllLines(moderationFilePath);
                string[] lines = File.ReadAllLines(textFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    foreach (string word in moderationWords)
                    {
                        lines[i] = lines[i].Replace(word, new string('*', word.Length));
                    }
                }

                File.WriteAllLines(textFilePath, lines);

                OutputTextBlock.Text = "Moderation complete.";
            }
            else
            {
                OutputTextBlock.Text = "File paths are invalid.";
            }
        }
    }
}
