using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStructure.DTO;

namespace TreeStructure.Services
{
    public interface IDirectoryService
    {
        Task CreateAsync(string name, int? parentId);
        Task<DirectoryDto> GetAsync(int id);
        Task<IEnumerable<DirectoryDto>> BrowseAsync();
        Task<IEnumerable<DirectoryDto>> GetChilrenAsync(int? parentId);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id);
    }
}
