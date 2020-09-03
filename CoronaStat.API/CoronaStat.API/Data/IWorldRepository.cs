using CoronaStat.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Data
{
    public interface IWorldRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        List<WorldParameter> GetWorldParameter();
        WorldParameter GetWorldParameterById(int id);
       
    }
}
