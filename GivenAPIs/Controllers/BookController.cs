using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivenAPIs.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GivenAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        // GET: /<controller>/
        
        [HttpGet]
        [Route("{id?}")]
        public IActionResult List(int? id)
        {
            if (id == null || id == 0) return Ok(DataGeneration.Books);
            else
                return Ok(DataGeneration.Books.Where(b=>b.AuthorId==id).ToList());
        }

        [HttpPost]
        public IActionResult Add([FromForm] Book book)
        {
            try
            {
                if (DataGeneration.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId) == null)
                    return Conflict();
                DataGeneration.Books.Add(book);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }
    }
}

