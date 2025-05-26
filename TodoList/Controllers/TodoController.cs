using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> lista = new List<TodoItem>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoItem item)
        {
            item.Id = nextId++;
            lista.Add(item);
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }
        
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return Index();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TodoItem editedItem)
        {
            var item = lista.FirstOrDefault(x => x.Id == editedItem.Id);
            if (item != null)
            {
                item.Name = editedItem.Name;
                
            }

            return RedirectToAction("Index");
        }


        public ActionResult Remove(int id)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item != null)
                lista.Remove(item);

            return RedirectToAction("Index");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
