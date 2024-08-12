using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.Action_Filters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlllBooksAsync()
        {
                    
                var books =await _manager.BookService.GetAllBooksAsync(false);
                return Ok(books);          
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
                var book =await _manager.BookService.GetOneBookByIdAsync(id, false);
                return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {

                var book = await _manager.BookService.CreateOneBookAsync(bookDto);
                return StatusCode(201, book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromBody] BookDtoForUpdate bookDto, [FromRoute(Name = "id")] int id)
        {

                await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
                return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
                await _manager.BookService.DeleteOneBookAsync(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDto> book)
        {
                var bookDto =  await _manager.BookService.GetOneBookByIdAsync(id, true);

                book.ApplyTo(bookDto);
                 await _manager.BookService.UpdateOneBookAsync(id, new BookDtoForUpdate()
                {
                    Id= bookDto.Id,
                    Title= bookDto.Title,
                    Price= bookDto.Price,
                },
                true);

                return NoContent();
        }
    }
}
