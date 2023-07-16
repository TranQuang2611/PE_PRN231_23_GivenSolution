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
    public class MovieController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("{id?}")]
        public IActionResult List(int? id)
        {
            if (id == null || id==0) return Ok(DataGeneration.Movies);
            else
                return Ok(DataGeneration.Movies.Where(b => b.StudioId == id).ToList());
        }

        [HttpPost]
        public IActionResult Add([FromForm] Movie movie)
        {
            try
            {
                if (DataGeneration.Studios.FirstOrDefault(a => a.StudioId == movie.StudioId) == null)
                    return Conflict();
                DataGeneration.Movies.Add(movie);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Conflict();
            }
        }
    }
}

