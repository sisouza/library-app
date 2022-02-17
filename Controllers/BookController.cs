
using Microsoft.AspNetCore.Mvc;

namespace library_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        
        //set book list
        private static List<Book> books = new List<Book>();


        //create a new book
        public void CreateBook(Book book)
        {
            books.Add(book);
        }
    }
}