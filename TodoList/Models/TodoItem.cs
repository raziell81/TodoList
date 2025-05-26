using Microsoft.AspNetCore.Components.Web;

namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        //public string Description { get; set; }
        
    }
}
