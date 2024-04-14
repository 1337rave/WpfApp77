using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileInteraction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateNumbers_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(random.Next(1, 1000));
            }
            List<int> primes = numbers.Where(IsPrime).ToList();
            List<int> fibonaccis = GenerateFibonacci(numbers.Max());

            SaveToFile(primes, "primes.txt");
            SaveToFile(fibonaccis, "fibonacci.txt");

            OutputTextBlock.Text = $"Generated {numbers.Count} numbers.\n" +
                                   $"Saved {primes.Count} prime numbers to primes.txt.\n" +
                                   $"Saved {fibonaccis.Count} Fibonacci numbers to fibonacci.txt.";
        }

        private void SaveToFile(List<int> numbers, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (int number in numbers)
                {
                    sw.WriteLine(number);
                }
            }
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private List<int> GenerateFibonacci(int max)
        {
            List<int> fibonaccis = new List<int>();
            int a = 0;
            int b = 1;
            while (a <= max)
            {
                fibonaccis.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }
            return fibonaccis;
        }
    }
}
