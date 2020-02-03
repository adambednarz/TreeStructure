using System.Collections.Generic;
using System.Threading.Tasks;
using TreeStructure.Models;

namespace TreeStructure.Data.Repository
{
    public interface IDirectoryRepository
    {
        Task<Directory> GetAsync(int id);
        Task<Directory> GetAsync(string name);
        Task<IEnumerable<Directory>> GetChildrenAsync(int? parentId);
        Task<IEnumerable<Directory>> GetAllAsync();
        Task AddAsync(Directory dir);
        Task RemoveAsync(Directory dir);
        Task UpdateAsync(Directory dir);

    }
}
