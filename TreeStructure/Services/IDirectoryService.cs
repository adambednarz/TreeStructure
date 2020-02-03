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
        Task CreateAsync(string name, int? parentId = null, string parentName = null);
        Task<DirectoryDto> GetAsync(int id);
        Task<DirectoryDto> GetAsync(string name);
        Task<IEnumerable<DirectoryDto>> GetAllNode();
        Task<IEnumerable<DirectoryDto>> GetNodeChilrenAsync(int? id);
        List<DirectoryDto> GetDirectoryTree(IEnumerable<DirectoryDto> directoryTree, DirectoryDto currentDirectory = null);
        Task<IEnumerable<DirectoryDto>> GetDirectoryTreeDifference(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, string name, int? parentId);
    }
}
