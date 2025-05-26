using Microsoft.AspNetCore.Mvc;
using System.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private static List<Tasks> tasks = new ();
        private static int nextId = 1;
        
        
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(string text)
        {
            var newTasks = new Tasks
            {
                Id = nextId++,
                Name = text
            }; 
            
            tasks.Add(newTasks);
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(i => i.Id == id);
            if (task == null) return HttpNotFound();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, string text) 
        {
            var task = tasks.FirstOrDefault(i => i.Id == id);
            if (task != null)
            {
                task.Name = text;
            }
                       
            return RedirectToAction("Index");

        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(i => i.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            foreach (var _tasks in tasks) 
            {
              int id = _tasks.Id;
              string name= _tasks.Name;  
            }


                return View(tasks);
            
        }
    }
}