using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Reader
    {
        public Reader() { }
        public uint Id { get; set; }

        public string FullName { get; set; }

        public uint ReaderTicket { get; set; }

        public Dictionary<uint, DateTime> DateCapture { get; set; }

        public Dictionary<uint, DateTime> DateReturn { get; set; }

        public Reader ReaderAdd(ReaderData readerData, TableData tableData, int row)
        {
            return new Reader()
            {
                Id = Convert.ToUInt32(readerData.FileReaders[row][0]),

                FullName = readerData.FileReaders[row][1],

                ReaderTicket = Convert.ToUInt32(readerData.FileReaders[row][2]),

                DateCapture = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.FileTableDate[row][0]), Convert.ToDateTime(tableData.FileTableDate[row][2])}
                },

                DateReturn = new Dictionary<uint, DateTime> { }
            };
        }
        public static string[] SortedReaderAndDate(List<Reader> readers, int length, bool typeSwitch)
        {
            var arr = new string[length];
            if (typeSwitch)
                Array.Fill<string>(arr, " ");
            else { Array.Fill<string>(arr, ""); }
            foreach (Reader reader in readers)
            {
                for (uint j = 1; j < length; j++)
                {
                    if ((reader.DateCapture.ContainsKey(j) && !reader.DateReturn.ContainsKey(j)) && (j > 0))
                    {
                        if (!typeSwitch)
                            arr[j] = reader.FullName;
                        else
                            arr[j] = reader.DateCapture[j].ToString("d", CultureInfo.GetCultureInfo("fr-FR"));
                        break;
                    }
                }
            }
            return arr;
        }

        public static List<string[]> СhangeArrayData(List<string[]> listData, int[] arrayColumn, List<Reader> readers, int length, bool typeSwitch)
        {
            var tempName = Reader.SortedReaderAndDate(readers, length, typeSwitch);
            var tempDate = Reader.SortedReaderAndDate(readers, length, !typeSwitch);
            for (int j = 1; j < listData[arrayColumn[0]].Length; j++)
            {
                listData[arrayColumn[0]][j] = tempName[j];
            }
            for (int j = 1; j < listData[arrayColumn[1]].Length; j++)
            {
                listData[arrayColumn[1]][j] = tempDate[j];
            }
            return listData;
        }

    }
}