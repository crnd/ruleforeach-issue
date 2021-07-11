using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BookshelfManager.Bookshelves
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookshelvesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Bookshelf> CreateBookshelf(CreateBookshelfCommand command)
        {
            return new ObjectResult(new Bookshelf { Books = command.Books })
            {
                StatusCode = 201
            };
        }
    }
}
