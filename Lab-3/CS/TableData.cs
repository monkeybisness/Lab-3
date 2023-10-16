using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class TableData
    {
        public TableData(string path, List<List<string>> fileTableDate) 
        { 
            Path = path; 
            FileTableDate = fileTableDate; 
        }

        public string Path { get; set; }

        public List<List<string>> FileTableDate { get; set; }
        public void RecordFile()
        {
            string[] arr = File.ReadAllLines(Path);
            for (int i = 0; i < arr.Length; i++)
            {
                List<string> temp = arr[i].Split(';').ToList();
                FileTableDate.Add(temp);
            }
        }
        public void CheckTypeInt(int row)
        {
            for (int column = 1; column <= 1; column++)
            {
                if (int.TryParse(FileTableDate[row][column], out int valueOne) == false)
                {
                    Console.WriteLine($"Тип данных {FileTableDate[row][column]} не совпал с типом {column + 1} столбца TableDate.");
                    Environment.Exit(0);
                }
            }
        }
        public void CheckTypeDateTime(int row)
        {
            for (int column = 2; column < FileTableDate[row].Count; column++)
            {
                if (DateTime.TryParse(FileTableDate[row][column], out DateTime valueTwo) == false)
                {
                    Console.WriteLine($"Тип данных {FileTableDate[row][column]} не совпал с типом {column + 1} столбца TableDate.");
                    Environment.Exit(0);
                }
            }
        }
        public void CheckLengthRow(int row)
        {
            if (FileTableDate[0].Count < FileTableDate[row].Count)
            {
                Console.WriteLine("Данных больше ,чем столбцов в таблице TableDate.");
                Environment.Exit(0);
            }
        }

        public void CheckData()
        {
            RecordFile();
            for (int j = 1; j < FileTableDate.Count - 1; j++)
            {
                CheckLengthRow(j);
                CheckTypeInt(j);
                CheckTypeDateTime(j);
            }
        }
    }
}