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
            new Book("1984", "George Orwell", 243, "3215423215429"),
            new Book("Twenty Thousand Leagues Under the Sea", "Jules Verne", 151, "9215483218428"),
            new Book("Small Prince", "A. d. Saint-Exupéry", 300, "9997448539997"),
            new Book("Metro 2033", "D. Glukhovsky", 530,  "5544483218433"),
            new Book("Brave New World ", " A. Huxley", 330,  "5544483218433")

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
