using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private List<TodoItem> Items = new List<TodoItem>();

        public TodosController()
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                throw new KeyNotFoundException();
            }
            Items.Remove(item);
        }
        
        [HttpGet]
        public List<TodoItem> GetAll()
        {
            return Items;
        }

        [HttpGet("{id}")]
        public TodoItem GetById(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }

        [HttpPost]
        public void Create(TodoItem item)
        {
            Items.Add(item);
        }

        [HttpPut]
        public void Update(TodoItem item)
        {
            var itemToReplace = Items.FirstOrDefault(i => i.Id == item.Id);
            if (item != null)
            {
                throw new KeyNotFoundException();
            }

            Items[item.Id] = item;
        }
    };
}
