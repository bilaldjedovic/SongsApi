using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SongsApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SongsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       SongsAppContext db = new SongsAppContext();

        [HttpGet]

        public IActionResult getCategory()
        {
            List<Category> categories = db.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult addCategory([FromBody] Category category)
        {
            db.Add(category);
            db.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult obrisiPodatak(int id)
        {
            Category category = db.Categories.Where(a => a.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound($"Podatak sa ID = {id} nije pronadjen");
            }
            else
            {
                try
                {
                    db.Remove(category);
                    db.SaveChanges();
                }
                catch
                {
                    return BadRequest("Error while deleting");
                }
            }
            return Ok("Deleted");
        }

        [HttpPost("{id}")]
        public IActionResult editCategory(int id, [FromBody] Category cat)
        {
            Category rezultat = db.Categories.Where(a => a.CategoryId.Equals(id)).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.CategoryName = (cat.CategoryName != null) ? cat.CategoryName : rezultat.CategoryName;

               


                db.SaveChanges();
            }
            else
            {
                return NotFound($"Pjesma sa id {cat.CategoryId} nije pronadjena");
            }

            return Ok(rezultat);
        }


    }
}
