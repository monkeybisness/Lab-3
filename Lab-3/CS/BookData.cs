using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class BookData
    {
        public BookData(string path, List<List<string>> fileBooks)
        {
            Path = path; 
            FileBooks = fileBooks; 
        }

        public string Path { get; set; }

        public List<List<string>> FileBooks { get; set; }

        public void RecordFile()
        {
            string[] arr = File.ReadAllLines(Path);
            for (int i = 0; i < arr.Length; i++)
            {
                List<string> temp = arr[i].Split(';').ToList();
                FileBooks.Add(temp);
            }
        }
        public void CheckTypeInt(int row, int column)
        {
            if (int.TryParse(FileBooks[row][column], out int valueOne) == false)
            {
                Console.WriteLine($"Тип данных {FileBooks[row][column]} не совпал с типом {column + 1} столбца Books.");
                Environment.Exit(0);
            }
        }
        public void CheckLengthRow(int row)
        {
            if (FileBooks[0].Count < FileBooks[row].Count)
            {
                Console.WriteLine("Данных больше ,чем столбцов в таблице Readers.");
                Environment.Exit(0);
            }
        }

        public void CheckData()
        {
            RecordFile();
            for (int i = 1; i <= FileBooks.Count - 1; i++)
            {
                CheckLengthRow(i);
                CheckTypeInt(i, 0);
                for (int j = 3; j <= FileBooks[i].Count - 1; j++) 
                {
                    CheckTypeInt(i, j); 
                }
            }
        }
    }
}