using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaStat.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaStat.API.Data
{
    public class AppRepository:IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<Country> GetCountries()
        {
            var countries = _context.Countries.Include(c => c.Values).ToList();
            //var countries = _context.Countries.ToList();
            return countries;
        }

        public Country GetCountryById(int id)
        {
            var country = _context.Countries.Include(c => c.Values).FirstOrDefault(c => c.Id == id);
            return country;
        }

        public List<Value> GetDetail()
        {
            var details = _context.Values.ToList();
            //var countries = _context.Countries.ToList();
            return details;
        }

        public Value GetDetails(int id)
        {
            var details = _context.Values.FirstOrDefault(v => v.Id == id);
            return details;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
