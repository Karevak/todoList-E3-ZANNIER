using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using todoFrançois.Data;
using todoFrançois.Models;

namespace todoFrançois.Pages.TodoTaskCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly todoFrançois.Data.TodoContext _context;

        public DeleteModel(todoFrançois.Data.TodoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TodoTask TodoTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TodoTask == null)
            {
                return NotFound();
            }

            var todotask = await _context.TodoTask.FirstOrDefaultAsync(m => m.Id == id);

            if (todotask == null)
            {
                return NotFound();
            }
            else 
            {
                TodoTask = todotask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TodoTask == null)
            {
                return NotFound();
            }
            var todotask = await _context.TodoTask.FindAsync(id);

            if (todotask != null)
            {
                TodoTask = todotask;
                _context.TodoTask.Remove(TodoTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
