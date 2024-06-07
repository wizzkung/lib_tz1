using lib_tz1.Data;
using lib_tz1.models;
using Microsoft.AspNetCore.Mvc;

namespace lib_tz1.Controllers
{
    public class ReturnedBookController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class ReturnedBooksController : ControllerBase
        {
            private readonly LibraryContext _context;

            public ReturnedBooksController(LibraryContext context)
            {
                _context = context;
            }

            [HttpGet]
            public ActionResult<IEnumerable<ReturnedBooks>> GetReturnedBooks()
            {
                return _context.returnedBooks.ToList();
            }

            [HttpGet("{id}")]
            public ActionResult<ReturnedBooks> GetReturnedBooks(int id)
            {
                var returnedBook = _context.returnedBooks.Find(id);

                if (returnedBook == null)
                {
                    return NotFound();
                }

                return returnedBook;
            }

            [HttpPost]
            public ActionResult<ReturnedBooks> PostReturnedBook(ReturnedBooks returnedBook)
            {
                _context.returnedBooks.Add(returnedBook);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetReturnedBooks), new { id = returnedBook.id }, returnedBook);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteReturnedBook(int id)
            {
                var returnedBook = _context.returnedBooks.Find(id);

                if (returnedBook == null)
                {
                    return NotFound();
                }

                _context.returnedBooks.Remove(returnedBook);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
