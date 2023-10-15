using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class TableData
    {
        public TableData(string path) { Path = path; }

        public string Path { get; set; }

        public List<List<string>> fileTableDate = new List<List<string>>();
        public void RecordFile()
        {
            string[] arr = File.ReadAllLines(Path);
            for (int i = 0; i < arr.Length; i++)
            {
                List<string> temp = arr[i].Split(';').ToList();
                fileTableDate.Add(temp);
            }
        }
        public void CheckTypeInt(int j)
        {
            for (int i = 1; i <= 1; i++)
            {
                if (int.TryParse(fileTableDate[j][i], out int valueOne) == false)
                {
                    Console.WriteLine($"Тип данных {fileTableDate[j][i]} не совпал с типом {i + 1} столбца TableDate.");
                    Environment.Exit(0);
                }
            }
        }
        public void CheckTypeDateTime(int j)
        {
            for (int i = 2; i < fileTableDate[j].Count; i++)
            {
                if (DateTime.TryParse(fileTableDate[j][i], out DateTime valueTwo) == false)
                {
                    Console.WriteLine($"Тип данных {fileTableDate[j][i]} не совпал с типом {i + 1} столбца TableDate.");
                    Environment.Exit(0);
                }
            }
        }
        public void CheckLength(int i)
        {
            if (fileTableDate[0].Count < fileTableDate[i].Count)
            {
                Console.WriteLine("Данных больше ,чем столбцов в таблице TableDate.");
                Environment.Exit(0);
            }
        }

        public void CheckFile()
        {
            RecordFile();
            for (int j = 1; j < fileTableDate.Count - 1; j++)
            {
                CheckLength(j);
                CheckTypeInt(j);
                CheckTypeDateTime(j);
            }
        }
    }
}