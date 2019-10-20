using System;

namespace BookLibrary.Model
{
    public class Book
    {

        public string title;
        public string author;
        public int page;
        public string iSBN;


        public Book(string title, string author, int page, string iSBN)
        {
            verification(title, author, page, iSBN);
        }


        public void verification(string title, string author, int page, string iSBN)
        {
            if (title.Length > 2)
            {
                this.title = title;
            }
            else
            {
                throw new System.ArgumentException("Title must be longer than 2 characters");
            }
            if (page > 10 && page <= 1000)
            {
                this.page = page;
            }
            else
            {
                throw new System.ArgumentException("Page must be between 10 than to 1000 characters");
            }
            if (iSBN.Length == 13)
            {
                this.iSBN = iSBN;
            }
            else
            {
                throw new System.ArgumentException("ISBN must be exactly 13 characters");

            }
            this.author = author;
        }

        public override string ToString()
        {
            return "Title: " + title + "Author: " + author + "Page: " + page + "ISBN: " + iSBN;
        }
    }
}
