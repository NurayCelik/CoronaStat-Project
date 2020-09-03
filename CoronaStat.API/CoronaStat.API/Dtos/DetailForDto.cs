using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Dtos
{
    public class WorldForDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public DateTime Tarih { get; set; }
        public int Vaka { get; set; }
        public int Olum { get; set; }
        public int Iyilesme { get; set; }
    }
}
