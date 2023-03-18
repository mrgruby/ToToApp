using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Dto
{
    public class ToDoItemDto
    {
        public string ToDoItemName { get; set; } = string.Empty;

        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
