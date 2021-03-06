﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication
{
    public class Book
    {
        public string bookTitle { get; set; }
        public bool borrowedFlag { get; set; }

        // Creates a new Book
        public Book(string bookTitle)
        {
            // Implement this method
            this.bookTitle = bookTitle;
        }

        // Marks the book as rented
        public void borrowed()
        {
            this.borrowedFlag = true;
            // Implement this method
        }

        // Marks the book as not rented
        public void returned()
        {
            this.borrowedFlag = false;
        }

        // Returns true if the book is rented, false otherwise
        public bool isBorrowed()
        {
            if (borrowedFlag)
            {
                return true;
            }
            return false;
        }

        // Returns the title of the book
        public string getTitle()
        {
            return this.bookTitle;
        }

        public static void testBook()
        {
            // Small test of the Book class
            Book example = new Book("The Da Vinci Code");
            Console.WriteLine("Title should be The Da Vinci Code): " + example.getTitle());
            Console.WriteLine("Borrowed? (should be false): " + example.isBorrowed());
            //example.rented();
            Console.WriteLine("Borrowed? (should be true): " + example.isBorrowed());
            example.returned();
            Console.WriteLine("Borrowed? (should be false): " + example.isBorrowed());
        }
    }
}
