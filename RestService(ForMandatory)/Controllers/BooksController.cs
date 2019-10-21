using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Book = BookLibrary.Model.Book;

namespace RestService_ForMandatory_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> books  = new List<Book>()
        {
            new Book("The Adventure of the Musgrave Ritual", "Arthur Conan Doyle", 1200, "9781789320848"),
            new Book("The Boscombe Valley Mystery", "Arthur Conan Doyle", 31, "9780140815122"),
            new Book("The House of Silk", "Anthony Horowitz", 294, "9781611132908"),
            new Book("The Adventures of Sherlock Holmes", "Arthur Conan Doyle", 307,  "9781581180671"),
            new Book("The Adventure of Silver Blaze ", " Arthur Conan Doyle", 330,  "9788771303803")

        };

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookLibrary.Model.Book>>Get()
        {
            return books;
        }

       

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(string id)
        {
            return books.Find(e => e.iSBN == id);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book addNewBook)
        {
            books.Add(addNewBook);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book addNewBook)
        {
            Delete(id);
            Post(addNewBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {

            books.RemoveAll(e => e.iSBN == id);
        }
    }
}
