using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItem
    {
        public required int Id { get; set; }

        [MaxLength(50)]
        //[Required(ErrorMessage ="Este campo é obrigatório!")]
        public required string Name { get; set; }
        //public string Description { get; set; }
        
    }
}
