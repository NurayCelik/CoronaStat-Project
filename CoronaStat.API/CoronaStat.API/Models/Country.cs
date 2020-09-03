using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Models
{
    public class Country
    {
        public Country() {
            Values = new List<Value>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Value> Values { get; set; }
    }
}
