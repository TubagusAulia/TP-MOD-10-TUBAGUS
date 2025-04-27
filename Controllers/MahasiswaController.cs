using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300141.Models;
using tpmodul10_103022300141.Models;

namespace tpmodul10_103022300141.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> _mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Tubagus Aulia", Nim = "103022300141" },
            new Mahasiswa { Nama = "Irfan Rangga", Nim = "103022300100" },
            new Mahasiswa { Nama = "Riza Muhammad", Nim = "103022300104" },
            new Mahasiswa { Nama = "Gamaliel Pradana", Nim = "103022300015" },
            new Mahasiswa { Nama = "Muhammad Razky", Nim = "103022300047" },
            new Mahasiswa { Nama = "Christofer Abel", Nim = "103022330039" }
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(_mahasiswaList);
        }

        // GET api/mahasiswa/5
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetById(int id)
        {
            if (id < 0 || id >= _mahasiswaList.Count)
                return NotFound();

            return Ok(_mahasiswaList[id]);
        }

        // POST api/mahasiswa
        [HttpPost]
        public IActionResult Create([FromBody] Mahasiswa mahasiswa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(GetById), new { id = _mahasiswaList.Count - 1 }, mahasiswa);
        }

        // DELETE api/mahasiswa/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= _mahasiswaList.Count)
                return NotFound();

            var deleted = _mahasiswaList[id];
            _mahasiswaList.RemoveAt(id);
            return Ok(deleted);
        }
    }
}