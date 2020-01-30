using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.Models;

namespace TreeStructure.Data.Repository
{
    public interface IDirectoryRepository
    {
        Task<Directory> GetAsync(int id);
        Task<IEnumerable<Directory>> GetAllForParentIdAsync(int? parentId);
        Task<IEnumerable<Directory>> GetAllAsync();
        Task AddAsync(Directory dir);
        Task RemoveAsync(Directory dir);
        Task UpdateAsync(Directory dir);

    }
}
