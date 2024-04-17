using todoFrançois.Models.TodoViewModels;
using todoFrançois.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoFrançois.Models;


namespace todoFrançois.Pages
{
    public class AboutModel : PageModel
    {
        private readonly TodoContext _context;
        public AboutModel(TodoContext context)
        {
            _context = context;
        }

        public IList<DureeGroupe> TodoTasks { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<DureeGroupe> data =
                from todotask in _context.TodoTask
                group todotask by todotask.Duree into dureeGroupe
                select new DureeGroupe()
                {
                    Duree = dureeGroupe.First().Duree,
                    TodoCount = dureeGroupe.Count()
                };
            TodoTasks = await data.AsNoTracking().ToListAsync();
        }
    }
}
