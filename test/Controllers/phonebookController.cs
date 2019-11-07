using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class phonebookController : ControllerBase
    {
        private readonly phonebookContext _context;

        public phonebookController(phonebookContext context)
        {
            _context = context;

            if (_context.PhonebookItems.Count() == 0)
            {
                _context.PhonebookItems.Add(new phonebookItem
                {
                    firstName = "testName", secondName = "testSecondName",
                    bDay = "18.10", email = "test@test.ru", phone = "89003211213"
                });
                _context.SaveChanges();
            }
        }
        
        //GET: api/phonebook
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<phonebookItem>>> GetPhonebookItem()
        {
            return await _context.PhonebookItems.ToListAsync();
        }
         
        //GET: api/phonebook/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<phonebookItem>> GetPhonebookItem(int id)
        {
            var phonebookItem = await _context.PhonebookItems.FindAsync(id);

            if (phonebookItem == null)
            {
                return NotFound();
            }

            return phonebookItem;
        }
        
        // POST: api/phonebook
        [HttpPost]

        public async Task<ActionResult<phonebookItem>> PostPhonebookItem(phonebookItem item)
        {
            Console.WriteLine(item);
            _context.PhonebookItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhonebookItem), new {id = item.Id}, item);
        }
        
        // PUT: api/phonebook/5
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutPhonebookItem(int id, phonebookItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        //DELETE api/phonebook/5
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeletePhonebookItem(int id)
        {
            var phonebookItem = await _context.PhonebookItems.FindAsync(id);

            if (phonebookItem == null)
            {
                return NotFound();
            }

            _context.PhonebookItems.Remove(phonebookItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    
    
}