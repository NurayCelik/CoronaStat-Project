using CoronaStat.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStat.API.Data
{
    public interface IPhotoRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();

        List<Photo> GetPhotosBy(int id);
        List<Photo> GetPhotosBy();
        Photo GetPhoto(int id);
       
    }
}
