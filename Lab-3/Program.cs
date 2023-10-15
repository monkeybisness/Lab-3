using System.Globalization;

namespace Lab
{
    class Programm
    {
        void Initialize()
        {
            BookData bookData = new BookData("C:\\Users\\User\\source\\repos\\Lab-3\\Lab-3\\CSV\\Books.csv");
            bookData.CheckFile();

            ReaderData readerData = new ReaderData("C:\\Users\\User\\source\\repos\\Lab-3\\Lab-3\\CSV\\Readers.csv");
            readerData.CheckFile();

            TableData tableData = new TableData("C:\\Users\\User\\source\\repos\\Lab-3\\Lab-3\\CSV\\TableDate.csv");
            tableData.CheckFile();

            List<Reader> readers = new List<Reader>();
            for (int j = 1; j <= tableData.fileTableDate.Count - 1; j++)
            {
                Reader readery = new Reader();
                if (tableData.fileTableDate[j].Count < 4) { readers.Add(readery.ReaderAdd(readerData, tableData, j)); }
                else
                {
                    readers.Add(readery.ReaderAdd(readerData, tableData, j));
                    readers[readers.Count - 1].DateReturn = new Dictionary<uint, DateTime>
                    {
                        { Convert.ToUInt32(tableData.fileTableDate[j][0]), Convert.ToDateTime(tableData.fileTableDate[j][3]) }
                    };
                }
            }

            List<Book> books = new List<Book>();
            for (int i = 1; i <= bookData.fileBooks.Count - 1; i++)
            {
                Book book = new Book();
                books.Add(book.BooksAdd(bookData, i));
            }
            var maxArr = new List<int>();

            var listData = new List<string[]>();

            TableCSV.TakeData(listData, bookData.fileBooks.Count, bookData.fileBooks, new int[] { 1, 2});
            TableCSV.TakeData(listData, bookData.fileBooks.Count, readerData.fileReaders, new int[] {  1 });
            TableCSV.TakeData(listData, bookData.fileBooks.Count, tableData.fileTableDate, new int[] { 2});
            Reader.Switch(listData, new int[] { 2, 3}, readers, bookData.fileBooks.Count, false);
            TableCSV.FillData(listData, 3);
            for (int i = 0; i < listData.Count; i++) { maxArr.Add(TableCSV.MaxLenColumn(listData, i)); }

            for (int i = 0; i < bookData.fileBooks.Count; i++)
            {
                if(i == 1)
                {
                    TableCSV.PrintRow(maxArr, TableCSV.SetSepLine(maxArr));
                }
                TableCSV.PrintRow(maxArr, TableCSV.SetColumns(listData, i ));
            }
        }
        public static void Main(string[] args)
        {
            Programm dataBase = new Programm();
            dataBase.Initialize();
        }
    }
}