using CoronaStat.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        List<Country> GetCountries();
        Country GetCountryById(int id);
        List<Value> GetDetail();
        Value GetDetails(int id);
    }
}
