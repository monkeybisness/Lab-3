using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Book
    {
        public Book() { }
        public uint Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public uint PublicationYear { get; set; }

        public uint CabinetNumber { get; set; }

        public uint ShelfNumber { get; set; }

        public Book BooksAdd(BookData bookData, int row)
        {
            return new Book
            {
                Id = Convert.ToUInt32(bookData.FileBooks[row][0]),

                Author = bookData.FileBooks[row][1],

                Title = bookData.FileBooks[row][2],

                PublicationYear = Convert.ToUInt32(bookData.FileBooks[row][3]),

                CabinetNumber = Convert.ToUInt32(bookData.FileBooks[row][4]),

                ShelfNumber = Convert.ToUInt32(bookData.FileBooks[row][5]),
            };

        }
    }
}