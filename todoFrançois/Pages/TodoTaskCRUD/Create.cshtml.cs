using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using todoFrançois.Data;
using todoFrançois.Models;

namespace todoFrançois.Pages.TodoTaskCRUD
{
    public class CreateModel : PageModel
    {
        private readonly todoFrançois.Data.TodoContext _context;

        public CreateModel(todoFrançois.Data.TodoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoTask TodoTask { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TodoTask.Add(TodoTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
