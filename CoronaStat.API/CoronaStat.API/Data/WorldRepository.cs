using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaStat.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaStat.API.Data
{
    public class WorldRepository : IWorldRepository
    {
        private DataContext _context;

        public WorldRepository(DataContext context)
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

        public List<WorldParameter> GetWorldParameter()
        {
            var worldparametre = _context.WorldParameters.ToList();
            //var countries = _context.Countries.ToList();
            return worldparametre;
        }

        public WorldParameter GetWorldParameterById(int id)
        {
            var worldparametre = _context.WorldParameters.FirstOrDefault(c => c.Id == id);
            return worldparametre;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
