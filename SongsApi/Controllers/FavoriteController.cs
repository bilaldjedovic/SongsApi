using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SongsApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SongsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        SongsAppContext db = new SongsAppContext();

        [HttpGet]

        public IActionResult getFavorite()
        {
            List<Favorite> favorites = db.Favorites.ToList();
            return Ok(favorites);
        }
    }
}
