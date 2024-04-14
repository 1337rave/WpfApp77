using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace RandomNumbersToFile
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateAndSaveNumbers_Click(object sender, RoutedEventArgs e)
        {
            // Generate 10000 random numbers
            Random random = new Random();
            int[] numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(int.MinValue, int.MaxValue);
            }

            // Save even and odd numbers to separate files
            string evenFilePath = "even_numbers.txt";
            string oddFilePath = "odd_numbers.txt";

            int evenCount = 0;
            int oddCount = 0;

            using (StreamWriter evenWriter = new StreamWriter(evenFilePath))
            using (StreamWriter oddWriter = new StreamWriter(oddFilePath))
            {
                foreach (int number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        evenWriter.WriteLine(number);
                        evenCount++;
                    }
                    else
                    {
                        oddWriter.WriteLine(number);
                        oddCount++;
                    }
                }
            }

            // Display statistics
            StatisticsTextBlock.Text = $"Total numbers generated: {numbers.Length}\n" +
                                        $"Even numbers: {evenCount}\n" +
                                        $"Odd numbers: {oddCount}\n" +
                                        $"Even numbers saved to: {evenFilePath}\n" +
                                        $"Odd numbers saved to: {oddFilePath}";
        }
    }
}
