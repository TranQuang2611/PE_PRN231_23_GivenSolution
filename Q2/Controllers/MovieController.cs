using Microsoft.AspNetCore.Mvc;
using Q2.DTO;

namespace Q2.Controllers
{
    public class MovieController : Controller
    {
        private HttpClient _httpClient;

        public MovieController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        public async Task<IActionResult> Index(int id)
        {
            var respond = await _httpClient.GetAsync("api/Author/List");
            List<AuthorDTO> authors = await respond.Content.ReadFromJsonAsync<List<AuthorDTO>>();
            var respondStudio = await _httpClient.GetAsync("api/Studio/List");
            List<StudioDTO> studios = await respondStudio.Content.ReadFromJsonAsync<List<StudioDTO>>();
            var respondMovie = await _httpClient.GetAsync("api/Movie/List");
            if(id != 0)
            {
                respondMovie = await _httpClient.GetAsync("api/Movie/List/"+id);
            }
            List<MovieDTO> movies = await respondMovie.Content.ReadFromJsonAsync<List<MovieDTO>>();
            ViewBag.authors = authors;
            ViewBag.studios = studios;
            return View(movies);
        }
    }
}
