using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class ReaderData
    {
        public ReaderData(string path, List<List<string>> fileReaders) 
        { 
            Path = path; 
            FileReaders = fileReaders; 
        }

        public string Path { get; set; }

        public List<List<string>> FileReaders { get; set; }
        public void RecordFile()
        {
            string[] arr = File.ReadAllLines(Path);
            for (int i = 0; i < arr.Length; i++)
            {
                List<string> temp = arr[i].Split(';').ToList();
                FileReaders.Add(temp);
            }
        }

        public void CheckTypeInt(int row, int column)
        {
            if (int.TryParse(FileReaders[row][column], out int valueOne) == false)
            {
                Console.WriteLine($"Тип данных {FileReaders[row][column]} не совпал с типом {column + 1} столбца Books.");
                Environment.Exit(0);
            }
        }
        public void CheckLengthRow(int row)
        {
            if (FileReaders[0].Count < FileReaders[row].Count)
            {
                Console.WriteLine("Данных больше ,чем столбцов в таблице Readers.");
                Environment.Exit(0);
            }
        }

        public void CheckData()
        {
            RecordFile();
            for (int i = 1; i < FileReaders.Count - 1; i++)
            {
                CheckLengthRow(i);
                CheckTypeInt(i, 0);
                CheckTypeInt(i, 2);
            }
        }
    }
}