using todoFrançois.Models;

namespace todoFrançois.Data
{
    public class DbInitializer
    {
        public static void Initialize(TodoContext context) { 
            if(context.TodoTask.Any())
            {
                return;
            }
            var todoTasks = new TodoTask[]
            {
                new TodoTask {Name="Faire devoir", Description=""},
                new TodoTask {Name="Manger", Description=""}
            };
            context.TodoTask.AddRange(todoTasks);
            context.SaveChanges();
        }
    }
}
