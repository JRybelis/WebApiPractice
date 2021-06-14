using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPractice.Models;

namespace WebApiPractice.Data
{
    public class DataService
    {
        public List<TodoItem> Items { get; set; }
        public List<Customer> Customers { get; set; }
        public DataService()
        {
            Items = new List<TodoItem>();
            Customers = new List<Customer>();
        }

    }

}
