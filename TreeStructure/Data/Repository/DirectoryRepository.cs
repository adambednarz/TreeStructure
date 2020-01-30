using Microsoft.EntityFrameworkCore;
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


        public async Task AddAsync(Directory dir)
        {
            await _dbContext.Directores.AddAsync(dir);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Directory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Directory>> GetAllAsync()
            => await _dbContext.Directores.ToListAsync();

        public async Task<Directory> GetAsync(int id)
            => await _dbContext.Directores.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Directory>> GetAllForParentIdAsync(int? parentId)
            => await _dbContext.Directores.Where(x => x.ParentId == parentId).ToAsyncEnumerable().ToList();

        public async Task RemoveAsync(Directory dir)
        {
            _dbContext.Directores.Remove(dir);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Directory dir)
        {
            _dbContext.Directores.Update(dir);
            await _dbContext.SaveChangesAsync();
        }

    }
}
