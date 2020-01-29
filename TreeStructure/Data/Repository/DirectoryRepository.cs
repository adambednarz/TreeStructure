using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.Models;

namespace TreeStructure.Data.Repository
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly AppDbContext _dbContext;

        public DirectoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Add(Directory dir)
            => _dbContext.Directores.Add(dir);


        public List<Directory> GetAll()
            =>  _dbContext.Directores.ToList();


        public Directory Get(int id)
            => _dbContext.Directores.FirstOrDefault(x => x.Id == id);


        public void Remove(Directory dir)
            => _dbContext.Directores.Remove(dir);

        public void Update(Directory dir)
            => _dbContext.Directores.Update(dir);

        public async Task<bool> SaveChangesAsync()
        {
            if (await _dbContext.SaveChangesAsync() > 0)
                return true;

            return false;
        }
    }
}
