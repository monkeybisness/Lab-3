using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class TableCSV
    {
        public TableCSV() { }

        public static List<string[]> FillData(List<string[]> listData, int l)
        {
            for (int i = 0; i < listData.Count; i++)
            {
                for(int j = 0; j < listData.Count; j ++)
                {
                    if (listData[i][j] == null) { listData[i][j] = string.Concat(Enumerable.Repeat(" ", l)); }
                }
            }
            return listData;
        }
        public static List<string[]> TakeData(List<string[]> listData, int i , List<List<string>> file, int[] arr)
        {
            for(int l =  0; l < arr.Length ; l++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (arr.Contains(j)) { listData.Add(TableCSV.Data(i, file, arr[l])); break; }
                }
            }
            return listData;
        }
        public static string[] Data( int i, List<List<string>> file, int column)
        {
            var temp = new string[i];
            for (int j = 0; j < file.Count ; j++)
            {
                if ((file[j].Count < 4) && (column > 2)) { temp[j] = null; }
                else { temp[j] = file[j][column]; }
            }
            return temp;
        }
        public static int MaxLenColumn(List<string[]> file, int j)
        {
            var maxValue = 0;
            var columns = new List<string>();
            for (int i = 0; i <= file.Count - 1; i++)
            {
                columns.Add(file[j][i].Length.ToString());
            }
            foreach (var column in columns)
            {
                if (int.Parse(column) > maxValue) maxValue = int.Parse(column);
            }
            return maxValue;
        }
        public static string[] SetColumns(List<string[]> listDate, int i)
        {
            var setColumns = new string[listDate.Count];
            for (int j = 0;j < listDate.Count;j++) { setColumns[j] = listDate[j][i]; }
            return setColumns;
        }
        public static string[] SetSepLine(List<int> width)
        {
            var arrSep = new string[width.Count];
            for(int i = 0; i < width.Count; i++) { arrSep[i] = new string('-', width[i]); }
            return arrSep;
        }

        public static void PrintRow(List<int> arr, params string[] fileLine)
        {
            var seed = "|";
            string row = fileLine.Aggregate(seed, (separator, fileLineText) => separator + " " + fileLineText.PadRight(arr[Array.IndexOf(fileLine, fileLineText)]) + " " + seed);
            Console.WriteLine(row);
        }
    }
}
