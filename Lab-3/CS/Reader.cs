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

        public Reader ReaderAddThree(ReaderData readerData, TableData tableData, int j)
        {
            return new Reader()
            {
                Id = Convert.ToUInt32(readerData.fileReaders[j][0]),

                FullName = readerData.fileReaders[j][1],

                ReaderTicket = Convert.ToUInt32(readerData.fileReaders[j][2]),

                DateCapture = new Dictionary<uint, DateTime>
                {
                    { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][2])}
                },

                DateReturn = new Dictionary<uint, DateTime> { },
            };
        }
        public static string[] BookReader(List<Reader> readers, int i, bool status)
        {
            var arr = new string[i];
            int count = 1;
            if (status)
                Array.Fill<string>(arr, " ");
            else { Array.Fill<string>(arr, ""); }
            foreach (Reader reader in readers)
            {
                for (uint j = 1; j < i; j++)
                {
                    if ((reader.DateCapture.ContainsKey(j) && !reader.DateReturn.ContainsKey(j)) && (j > 0))
                    {
                        if (!status)
                            arr[j] = reader.FullName;
                        else
                            arr[j] = reader.DateCapture[j].ToString("d", CultureInfo.GetCultureInfo("fr-FR"));
                        count++;
                        break;
                    }
                }
            }
            return arr;
        }

        public static List<string[]> Swich(List<string[]> list, int[] arr, List<Reader> readers, int len, bool status)
        {
            var tempName = Reader.BookReader(readers, len, status);
            var tempDate = Reader.BookReader(readers, len , !status);
            for (int j = 1; j < list[arr[0]].Length; j++)
            {
                list[arr[0]][j] = tempName[j];
            }
            for (int j = 1; j < list[arr[1]].Length; j++)
            {
                list[arr[1]][j] = tempDate[j];
            }
            return list;
        }

    }
}