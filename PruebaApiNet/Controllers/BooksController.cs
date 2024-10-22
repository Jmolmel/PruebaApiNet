using Microsoft.AspNetCore.Mvc;
using PruebaApiNet.Database;

namespace PruebaApiNet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly MyDbContext _context;

    public BooksController (MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Book> GetBooks() //Toda coleccion es un IEnumerable
    { 
        return _context.Books;
    }
}
