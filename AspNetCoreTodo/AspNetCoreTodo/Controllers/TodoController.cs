using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController (ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index() 
        {
            var items = await _todoItemService.GetIncompleteItemAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        }
        
    }
}