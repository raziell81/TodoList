using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;
using Rotativa;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> list = new List<TodoItem>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(TodoItem item)
        {
            if(item.Name != null)
            {
                item.Id = nextId++;
                list.Add(item);
              
            }
            else
            {
                return RedirectToAction("Create");    
            }
                return RedirectToAction("Index");

        }

        public ActionResult Edit()
        {
            return View();
        }
        
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return Index();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TodoItem editedItem)
        {
            var item = list.FirstOrDefault(x => x.Id == editedItem.Id);
            if (item != null)
            {
                item.Name = editedItem.Name;
                
            }

            return RedirectToAction("Index");
        }


        public ActionResult Remove(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item != null)
                list.Remove(item);

            return RedirectToAction("Index");
        }


        public IActionResult PrintList(List<string> list)
        {
            return PartialView("_PrintList", list);
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
