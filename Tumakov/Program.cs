using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tumakov
{
    internal class Program
    {
        static void Lesson1()
        {
            Console.WriteLine("Задание 1:");
            Bank firstAccount = new Bank(1200, BankTypes.Current);
            Bank secondAccount = new Bank(1800, BankTypes.Current);
            Console.WriteLine($"Текущий баланс счета равен {firstAccount.accountBalance}. Какую сумму вы хотите перевести?");    
            if (uint.TryParse(Console.ReadLine(), out uint input))
                firstAccount.TransferMoneyToAnotherAccount(secondAccount, input);
            Console.WriteLine($"Оставшийся баланс {firstAccount.accountBalance}");
        }
        static void Lesson2()
        {
            Console.WriteLine("\nЗадание 2:");
            string ReverseString(string str)
            {
                StringBuilder newString = new StringBuilder();
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    newString.Append(str[i]);
                }

                return newString.ToString();
            }
            Console.WriteLine("Введите строку, которую хотите перевернуть: ");
            Console.WriteLine($"{ReverseString(Console.ReadLine())}");
        }
        static void Lesson3()
        {
            Console.WriteLine("\nЗадание 3:");
            Console.WriteLine("Введите название файла");

            string fileName = Console.ReadLine();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].ToUpper();
                }

                string outputFileName = $"new-{fileName}";
                File.WriteAllLines(outputFileName, lines);

                Console.WriteLine($"Содержимое файла записано в {outputFileName} заглавными буквами.");
            }
            else
                Console.WriteLine("Файл с таким названием не существует!!!");
        }
        static void Lesson4()
        {
            Console.WriteLine("\nЗадание 4:");
            Object value = 15;

            if (CheckIFormattable(value))
                Console.WriteLine("Параметр реализует интерфейс IFormattable");
            else
                Console.WriteLine("Параметр не реализует интерфейс IFormattable");

            bool CheckIFormattable(object obj)
            {
                if (obj is IFormattable)
                {
                    IFormattable formattable = obj as IFormattable;
                    if (formattable != null)
                        return true;
                }
                return false;
            }
        }
        static void Homework1()
        {
            Console.WriteLine("\nДомашнее задание 1:");

            string fileName = "users.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    SearchMail(ref lines[i]);
                }

                string outputFileName = $"email-{fileName}";
                File.WriteAllLines(outputFileName, lines);
                Console.WriteLine($"Email адреса записаны в {outputFileName}");
            }
            else
                Console.WriteLine("Неудалось найти файл!");
        }
        public static void SearchMail(ref string s)
        {
            s = s.Replace(" ", "").Split('#')[1];
        }
        static void Main(string[] args)
        {
            Lesson1();
            Lesson2();
            Lesson3();
            Lesson4();
            Homework1();

            Console.WriteLine("\nДомашнее задание 2:");
            List<Song> songs = new List<Song>();

            Song song1 = new Song();
            song1.SetName("Песня 1");
            song1.SetAuthor("Автор 1");
            songs.Add(song1);

            Song song2 = new Song();
            song2.SetName("Песня 2");
            song2.SetAuthor("Автор 2");
            song2.SetPreviousSong(song1);
            songs.Add(song2);

            Song song3 = new Song();
            song3.SetName("Песня 3");
            song3.SetAuthor("Автор 3");
            song3.SetPreviousSong(song2);
            songs.Add(song3);

            Song song4 = new Song();
            song4.SetName("Песня 4");
            song4.SetAuthor("Автор 4");
            song4.SetPreviousSong(song3);
            songs.Add(song4);

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());

                if (song.Equals(songs[0]))
                {
                    Console.WriteLine("Первая песня в списке.");
                }
                else if (song.Equals(songs[1]))
                {
                    Console.WriteLine("Вторая песня в списке.");
                }

                Console.WriteLine();
            }
        }
    }
}
