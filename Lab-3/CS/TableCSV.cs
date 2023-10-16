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

        public static List<string[]> FillEmptyData(List<string[]> listData, int count)
        {
            for (int i = 0; i < listData.Count; i++)
            {
                for(int j = 0; j < 5; j ++)
                {
                    if (listData[i][j] == null) { listData[i][j] = string.Concat(Enumerable.Repeat(" ", count)); }
                }
            }
            return listData;
        }
        public static List<string[]> TakeArrayData(List<string[]> listData, int length , List<List<string>> fileData, int[] arrayColumns)
        {
            for(int l =  0; l < arrayColumns.Length ; l++)
            {
                for (int j = 0; j < fileData.Count; j++)
                {
                    if (arrayColumns.Contains(j)) { listData.Add(TableCSV.ArrayData(length, fileData, arrayColumns[l])); break; }
                }
            }
            return listData;
        }
        public static string[] ArrayData( int length, List<List<string>> fileData, int column)
        {
            var temp = new string[length];
            for (int j = 0; j < fileData.Count ; j++)
            {
                if ((fileData[j].Count < 4) && (column > 2)) { temp[j] = null; }
                else { temp[j] = fileData[j][column]; }
            }
            return temp;
        }
        public static int MaxWidthColumn(List<string[]> listData, int column)
        {
            var maxWidth = 0;
            var widths = new List<string>();
            for (int i = 0; i < listData[column].Length; i++)
            {
                widths.Add(listData[column][i].Length.ToString());
            }
            foreach (var width in widths)
            {
                if (int.Parse(width) > maxWidth) maxWidth = int.Parse(width);
            }
            return maxWidth;
        }
        public static string[] SetColumn(List<string[]> listDate, int row)
        {
            var setColumns = new string[listDate.Count];
            for (int j = 0;j < listDate.Count;j++) { setColumns[j] = listDate[j][row]; }
            return setColumns;
        }
        public static string[] SetSepColumn(List<int> arrayMaxWidth)
        {
            var arrSep = new string[arrayMaxWidth.Count];
            for(int i = 0; i < arrayMaxWidth.Count; i++) { arrSep[i] = new string('-', arrayMaxWidth[i]); }
            return arrSep;
        }

        public static void PrintRow(List<int> arrayMaxWidth, params string[] setColumns)
        {
            string row = setColumns.Aggregate("|", 
                (separator, ColumnText) => separator + " " + ColumnText.PadRight(arrayMaxWidth[Array.IndexOf(setColumns, ColumnText)]) + " " + "|");
            Console.WriteLine(row);
        }
    }
}
