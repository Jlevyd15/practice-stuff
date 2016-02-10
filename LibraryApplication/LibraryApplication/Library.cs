using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication
{
    class Library
    {
        public const string hours = "9 AM to 5 PM";
        public string address { get; set; }
        public List<Book> bookList { get; set; }

        public Library(string address)
        {
            List<Book> books = new List<Book>();
            bookList = books;
            this.address = address;
        }

        //start main
        static void Main(string[] args)
        {
            //Test Book
            Book.testBook();

            // Create two libraries
            Library firstLibrary = new Library("10 Main St.");
            Library secondLibrary = new Library("228 Liberty St.");

            // Add four books to the first library
            firstLibrary.addBook(new Book("The Da Vinci Code"));
            firstLibrary.addBook(new Book("Le Petit Prince"));
            firstLibrary.addBook(new Book("A Tale of Two Cities"));
            firstLibrary.addBook(new Book("The Lord of the Rings"));
            //secondLibrary.addBook(new Book("A Tale of Two Cities"));
            // Print opening hours and the addresses
            Console.WriteLine("Library hours:");
            printOpeningHours();
            Console.WriteLine();

            Console.WriteLine("Library addresses:");
            firstLibrary.printAddress();
            secondLibrary.printAddress();
            Console.WriteLine();

            // Try to borrow The Lords of the Rings from both libraries
            Console.WriteLine("Borrowing The Lord of the Rings:");
            firstLibrary.borrowBook("The Lord of the Rings");
            firstLibrary.borrowBook("The Lord of the Rings");
            secondLibrary.borrowBook("The Lord of the Rings");
            Console.WriteLine();

            // Print the titles of all available books from both libraries
            Console.WriteLine("Books available in the first library:");
            firstLibrary.printAvailableBooks();
            Console.WriteLine();
            Console.WriteLine("Books available in the second library:");
            secondLibrary.printAvailableBooks();
            Console.WriteLine();

            // Return The Lords of the Rings to the first library
            Console.WriteLine("Returning The Lord of the Rings:");
            firstLibrary.returnBook("The Lord of the Rings");
            Console.WriteLine();

            // Print the titles of available from the first library
            Console.WriteLine("Books available in the first library:");
            firstLibrary.printAvailableBooks();
            Console.ReadKey();
        }//end main

        public void addBook(Book book)
        {
            if (book == null) { Console.WriteLine("error"); Console.ReadKey(); }
            try
            {
                bookList.Add(book);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e);
                Console.ReadKey();
            }
        }

        public string printAddress()
        {
            Console.WriteLine(address);
            return address;
        }

        public static string printOpeningHours()
        {
            Console.WriteLine(hours);
            return hours;
        }


        public void borrowBook(string title)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                bool matches = bookList.Any(item => bookList[i].bookTitle == title);
                //check that the book exists in the bookList
                if (title.Equals(bookList[i].bookTitle) && bookList[i].isBorrowed().Equals(false))
                {
                    bookList[i].borrowed();
                    Console.WriteLine("You successfully borrowed {0}", bookList[i].bookTitle);
                }
                else if (bookList[i].isBorrowed() == true)
                {
                    Console.WriteLine("Sorry, {0} is already borrowed.", bookList[i].bookTitle);
                }else if (matches){ Console.WriteLine("That Book Doesn't Exist in this Library"); }
            }
        }

        public void returnBook(string title)
        {
            foreach (Book b in bookList)
            {
                if (b.bookTitle == title && b.isBorrowed() == true)
                {
                    b.returned();
                    Console.WriteLine("You successfully returned {0}", b.bookTitle);
                }
            }
        }

        public void printAvailableBooks()
        {
            if (bookList.Count > 0)
            {
                foreach (Book b in bookList)
                {

                    Console.WriteLine(b.bookTitle);
                }
            }
            else Console.WriteLine("No Books in the Catalog");
        }
    }//end class
}//end namespace