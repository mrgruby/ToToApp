﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Contracts.DataServices.ToDoServices
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllToDoItems();
    }
}