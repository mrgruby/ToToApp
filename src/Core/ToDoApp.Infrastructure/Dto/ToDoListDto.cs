using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Dto
{
    public class ToDoListDto
    {
        public string ToDoListName { get; set; }
        public ToDoItem ToDoItem { get; set; } = new ToDoItem();
    }
}
