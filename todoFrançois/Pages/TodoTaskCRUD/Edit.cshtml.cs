using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using todoFrançois.Data;
using todoFrançois.Models;

namespace todoFrançois.Pages.TodoTaskCRUD
{
    public class EditModel : PageModel
    {
        private readonly todoFrançois.Data.TodoContext _context;

        public EditModel(todoFrançois.Data.TodoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TodoTask TodoTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TodoTask == null)
            {
                return NotFound();
            }

            var todotask =  await _context.TodoTask.FirstOrDefaultAsync(m => m.Id == id);
            if (todotask == null)
            {
                return NotFound();
            }
            TodoTask = todotask;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TodoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTaskExists(TodoTask.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoTaskExists(int id)
        {
          return _context.TodoTask.Any(e => e.Id == id);
        }
    }
}
