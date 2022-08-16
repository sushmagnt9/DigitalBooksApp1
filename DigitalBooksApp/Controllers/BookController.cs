﻿using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBooksApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _ibookService;
        public BookController(IBookService ibookService)
        {
            _ibookService = ibookService;
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            return Ok(_ibookService.GetAllBooks());
        }
        [HttpPost]
        public ActionResult<string> CreateBook([FromBody] Book book)
        {
            string result = _ibookService.CreateBook(book);
            return Ok(result);
        }
        [HttpPut("{bookId}")]
        public ActionResult UpdateBooks(int bookId, [FromBody] Book book)
        {
            if (bookId == book.BookId)
            {
                string result = _ibookService.UpdateBooks(bookId, book);
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteBooks(int bookId)
        {
            string result = _ibookService.DeleteBooks(bookId);
            return Ok(result);
        }
    }
}