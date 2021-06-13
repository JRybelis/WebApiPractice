using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly DataService _dataService;

        public TodosController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _dataService.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            _dataService.Items.Remove(item);
        }
        
        [HttpGet]
        public List<TodoItem> GetAll()
        {
            return _dataService.Items;
        }

        [HttpGet("{id}")]
        public TodoItem GetById(int id)
        {
            var item = _dataService.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }

        [HttpPost]
        public void Create(TodoItem item)
        {
            _dataService.Items.Add(item);
        }

        [HttpPut]
        public void Update(TodoItem item)
        {
            var itemToReplace = _dataService.Items.FirstOrDefault(i => i.Id == item.Id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Items[item.Id] = item;
        }
    };
}
