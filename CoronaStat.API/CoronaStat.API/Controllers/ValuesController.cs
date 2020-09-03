using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaStat.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CoronaStat.API.Controllers
{
    //[Route("api/Values")]
    [Route("api/[Controller]")]
    // [HttpGet("")] //Default olarak direkt bunu çalıştır demek
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            return Ok(value);
        }
        [HttpGet("{vaka}")]
        public async Task<ActionResult> GetVaka()
        {
            var sumVaka = await _context.Values.SumAsync(v => v.Vaka);
            return Ok(sumVaka);
        }
        public async Task<ActionResult> GetOlum()
        {
            var sumOlum = await _context.Values.SumAsync(v => v.Olum);
            return Ok(sumOlum);
        }
        public async Task<ActionResult> GetIyilesme()
        {
            var sumIyilesme = await _context.Values.SumAsync(v => v.Iyilesme);
            return Ok(sumIyilesme);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
