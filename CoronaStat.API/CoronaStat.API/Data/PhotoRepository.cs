using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaStat.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaStat.API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private DataContext _context;

        public PhotoRepository(DataContext context)
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

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(c => c.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosBy(int id)
        {
            var photos = _context.Photos.Include(c => c.Url).ToList();
            //var countries = _context.Countries.ToList();
            return photos;
        }

        public List<Photo> GetPhotosBy()
        {
            var photo = _context.Photos.ToList();
            return photo;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
