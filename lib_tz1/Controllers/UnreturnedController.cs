﻿using lib_tz1.Data;
using lib_tz1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lib_tz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnreturnedBooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UnreturnedBooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnreturnedBook>> GetUnreturnedBooks()
        {
            return _context.unreturnedBooks.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<UnreturnedBook> GetUnreturnedBook(int id)
        {
            var unreturnedBook = _context.unreturnedBooks.Find(id);

            if (unreturnedBook == null)
            {
                return NotFound();
            }

            return unreturnedBook;
        }

        [HttpPost]
        public ActionResult<UnreturnedBook> PostUnreturnedBook(UnreturnedBook unreturnedBook)
        {
            _context.unreturnedBooks.Add(unreturnedBook);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUnreturnedBook), new { id = unreturnedBook.id }, unreturnedBook);
        }

        [HttpPut("{id}")]
        public IActionResult PutUnreturnedBook(int id, UnreturnedBook unreturnedBook)
        {
            if (id != unreturnedBook.id)
            {
                return BadRequest();
            }

            _context.Entry(unreturnedBook).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnreturnedBook(int id)
        {
            var unreturnedBook = _context.unreturnedBooks.Find(id);
            if (unreturnedBook == null)
            {
                return NotFound();
            }

            _context.unreturnedBooks.Remove(unreturnedBook);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
