using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SongsApi.Models;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SongsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    [EnableCors]
    public class SongController : ControllerBase
    {
        SongsAppContext db = new SongsAppContext();

        [HttpGet]

        public IActionResult getSongs()
        {
            List<VwSong> songs = db.VwSongs.OrderByDescending(x=>x.Rate).ToList();
            return Ok(songs);
        }

        [HttpGet("{id}")]

        public IActionResult song(int id)
        {
            Song song = db.Songs.Where(x => x.SongId == id).FirstOrDefault();
            return Ok(song);
        }
        [EnableCors]
        [HttpPost]

        public IActionResult addSong([FromBody] Song song)
        {
            db.Add(song);
            db.SaveChanges();
            return Ok(song);
        }
        [EnableCors]
        [HttpPost("{id}")]
        public IActionResult editSong(int id, [FromBody] Song songPod)
        {
            Song rezultat = db.Songs.Where(a => a.SongId.Equals(id)).FirstOrDefault();
            if (rezultat != null)
            {
                rezultat.SongName = (songPod.SongName != null) ? songPod.SongName : rezultat.SongName;
                rezultat.Author = (songPod.Author != null) ? songPod.Author : rezultat.Author;
                rezultat.Rate = (songPod.Rate != null) ? songPod.Rate : rezultat.Rate;
                rezultat.ModifiedAt = (songPod.ModifiedAt != null) ? songPod.ModifiedAt : rezultat.ModifiedAt;
                rezultat.Link = (songPod.Link != null) ? songPod.Link : rezultat.Link;
              
              
                db.SaveChanges();
            }
            else
            {
                return NotFound($"Pjesma sa id {songPod.SongId} nije pronadjena");
            }

            return Ok(rezultat);
        }
        [EnableCors]
        [HttpDelete("{id}")]
        public IActionResult obrisiPodatak(int id)
        {
            Song song = db.Songs.Where(a => a.SongId == id).FirstOrDefault();
            if (song == null)
            {
                return NotFound($"Podatak sa ID = {id} nije pronadjen");
            }
            else
            {
                try { 
                db.Remove(song);
                db.SaveChanges();
                }catch {
                    return BadRequest("brisanje nije moguće");
                }
            }
            return Ok("Obrisano");
        }

    }
}
