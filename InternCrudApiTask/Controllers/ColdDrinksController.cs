using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternCrudApiTask.Data;
using InternCrudApiTask.Models;

namespace InternCrudApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColdDrinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ColdDrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColdDrink>>> GettblColdDrinks()
        {
            return await _context.tblColdDrinks.ToListAsync();
        }

        // GET: api/ColdDrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColdDrink>> GetColdDrink(int id)
        {
            var coldDrink = await _context.tblColdDrinks.FindAsync(id);

            if (coldDrink == null)
            {
                return NotFound();
            }

            return coldDrink;
        }


        // GET: API 04- Find remaining products nam
        [HttpGet("findremainingproductname")]
        public async Task<ActionResult<IEnumerable<string>>> GetRemainingColdDrinksName()
        {
            return await _context.tblColdDrinks.Select(x => x.strColdDrinksName).ToListAsync();
        }


        // GET: API 06: Find total price of all products

        [HttpGet("totalprice")]
        public async Task<ActionResult<decimal>> TotalPriceOfAllProducts()
        {
            return await _context.tblColdDrinks.SumAsync(x => x.numUnitPrice);
        }

        // PUT: api/ColdDrinks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColdDrink(int id, ColdDrink coldDrink)
        {
            if (id != coldDrink.intColdDrinksId)
            {
                return BadRequest();
            }

            _context.Entry(coldDrink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColdDrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ColdDrinks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ColdDrink>> PostColdDrink(ColdDrink coldDrink)
        {
            _context.tblColdDrinks.Add(coldDrink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColdDrink", new { id = coldDrink.intColdDrinksId }, coldDrink);
        }

        // DELETE: api/ColdDrinks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColdDrink>> DeleteColdDrink(int id)
        {
            var coldDrink = await _context.tblColdDrinks.FindAsync(id);
            if (coldDrink == null)
            {
                return NotFound();
            }

            _context.tblColdDrinks.Remove(coldDrink);
            await _context.SaveChangesAsync();

            return coldDrink;
        }

        //DELETE: API 05- Delete All products if it’s quantity is less than 500
        [HttpDelete("deleteallproduct")]
        public async Task<ActionResult<List<ColdDrink>>> DeleteAllProductIfQuantityLessThan500()
        {
            var coldDrinks = await _context.tblColdDrinks.ToListAsync();
            if (coldDrinks.Count == 0 || !coldDrinks.Any())
            {
                return null;
            }

            var listOf500ProductQuantity = coldDrinks.Where(x => x.numQuantity < 500).ToList();
            foreach (var item in listOf500ProductQuantity)
            {
                _context.tblColdDrinks.Remove(item);
            }
            await _context.SaveChangesAsync();

            return listOf500ProductQuantity;
        }

        private bool ColdDrinkExists(int id)
        {
            return _context.tblColdDrinks.Any(e => e.intColdDrinksId == id);
        }
    }
}
