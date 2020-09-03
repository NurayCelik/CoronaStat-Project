using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Dtos
{
    public class CountryForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Vaka { get; set; }
    }
}
