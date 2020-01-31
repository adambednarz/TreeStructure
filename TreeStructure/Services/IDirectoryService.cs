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
        Task CreateAsync(string name, string parentName);
        Task CreateByIdAsync(string name, int? parentId);
        Task<DirectoryDto> GetAsync(int id);
        Task<DirectoryDto> GetAsync(string name);
        Task<IEnumerable<DirectoryDto>> BrowseAsync();
        Task<ICollection<DirectoryDto>> GetChilrenAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id);
        List<DirectoryDto> GetDirectoryTree(ICollection<DirectoryDto> directoryTree);
    }
}
