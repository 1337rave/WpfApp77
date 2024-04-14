using System.IO;
using System.Windows;

namespace FileInteraction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReplaceWords_Click(object sender, RoutedEventArgs e)
        {
            string findWord = FindTextBox.Text;
            string replaceWord = ReplaceTextBox.Text;

            int replacements = ReplaceWordsInFile(findWord, replaceWord);

            OutputTextBlock.Text = $"Replaced {replacements} occurrences of '{findWord}' with '{replaceWord}'.";
        }

        private int ReplaceWordsInFile(string findWord, string replaceWord)
        {
            string fileName = "text.txt";
            string tempFileName = "temp.txt";

            int replacements = 0;

            using (StreamReader reader = new StreamReader(fileName))
            using (StreamWriter writer = new StreamWriter(tempFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(findWord, replaceWord);
                    replacements += CountReplacementsInLine(line, findWord, replaceWord);
                    writer.WriteLine(line);
                }
            }

            File.Delete(fileName);
            File.Move(tempFileName, fileName);

            return replacements;
        }

        private int CountReplacementsInLine(string line, string findWord, string replaceWord)
        {
            int count = 0;
            int index = line.IndexOf(findWord);
            while (index != -1)
            {
                count++;
                index = line.IndexOf(findWord, index + 1);
            }
            return count;
        }
    }
}

