using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using todoFrançois.Data;
using todoFrançois.Models;

namespace todoFrançois.Pages.TodoTaskCRUD
{
    public class IndexModel : PageModel
    {
        private readonly todoFrançois.Data.TodoContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(TodoContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;

        }

        public IList<TodoTask> TodoTasks { get;set; }
        public string DateSort { get; set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<TodoTask> todoTasks { get; set;}

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else 
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<TodoTask> todoTasksIQ = from s in _context.TodoTask
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                todoTasksIQ = todoTasksIQ.Where(s => s.Name.Contains(searchString)
                    || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case " Date":
                    todoTasksIQ = todoTasksIQ.OrderBy(s=> s.DateFin);
                    break;
                case " Name":
                    todoTasksIQ = todoTasksIQ.OrderBy(s => s.Name);
                    break;
                default:
                    todoTasksIQ = todoTasksIQ.OrderBy(s=>s.DateDebut);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 4);
            TodoTasks = await PaginatedList<TodoTask>.CreateAsync(
                    todoTasksIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
