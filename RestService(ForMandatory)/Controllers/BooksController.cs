using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using java.awt.print;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Book = BookLibrary.Model.Book;

namespace RestService_ForMandatory_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> Books { get; set; } = new List<Book>()
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
            return Books;
        }

       

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
