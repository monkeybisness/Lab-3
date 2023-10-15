using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class ReaderData
    {
        public ReaderData(string path) { Path = path; }

        public string Path { get; set; }

        public List<List<string>> fileReaders = new List<List<string>>();
        public void RecordFile()
        {
            string[] arr = File.ReadAllLines(Path);
            for (int i = 0; i < arr.Length; i++)
            {
                List<string> temp = arr[i].Split(';').ToList();
                fileReaders.Add(temp);
            }
        }

        public void CheckTypeInt(int i, int j)
        {
            if (int.TryParse(fileReaders[i][j], out int valueOne) == false)
            {
                Console.WriteLine($"Тип данных {fileReaders[i][j]} не совпал с типом {j + 1} столбца Books.");
                Environment.Exit(0);
            }
        }
        public void CheckLength(int i)
        {
            if (fileReaders[0].Count < fileReaders[i].Count)
            {
                Console.WriteLine("Данных больше ,чем столбцов в таблице Readers.");
                Environment.Exit(0);
            }
        }

        public void CheckFile()
        {
            RecordFile();
            for (int i = 1; i < fileReaders.Count - 1; i++)
            {
                CheckLength(i);
                CheckTypeInt(i, 0);
                CheckTypeInt(i, 2);
            }
        }
    }
}