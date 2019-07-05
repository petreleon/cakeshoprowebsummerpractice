using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Data;
using CakeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CakeController(ApplicationDbContext context)
        {
            _context = context;
        }


        // POST: api/Cake
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCake(Cake cake)
        {
            try
            {
                _context.Cakes.Add(cake);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
           

            return CreatedAtAction(nameof(GetCake), new { id = cake.CakeId }, cake);
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(long id)
        {
            var cake = await _context.Cakes.FindAsync(id);

            if (cake == null)
            {
                return NotFound();
            }

            return cake;
        }
    }
}