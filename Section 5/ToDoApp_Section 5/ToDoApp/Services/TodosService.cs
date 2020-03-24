using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DTO;
using AutoMapper;

namespace ToDoApp.Services
{
    public class TodosService : IToDosService
    {
        private AppDbContext _context;
        private Mapper _mapper;

        public TodosService(AppDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Todo> ChangeStatus(ChangeToDoStatusDTO td)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == td.Id);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }
            todo.Status = td.Status;
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> Create(CreateToDoDTO todo)
        {
            var t = _mapper.Map<CreateToDoDTO, Todo>(todo);
            _context.Todos.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<IEnumerable<Todo>> GetAll(int userId)
        {
            return await (from t in _context.Todos where t.UserId == userId select t).ToListAsync();
        }
    }
}
