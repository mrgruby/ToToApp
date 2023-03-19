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
        public int ToDoItemId { get; set; }
        public string ToDoItemName { get; set; } = string.Empty;
        public string ToDoDescription { get; set; } = string.Empty;
        public bool ToDoIsDone { get; set; }
    }
}
