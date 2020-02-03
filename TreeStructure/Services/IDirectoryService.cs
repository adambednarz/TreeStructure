using System.Collections.Generic;
using System.Threading.Tasks;
using TreeStructure.DTO;

namespace TreeStructure.Services
{
    public interface IDirectoryService
    {
        Task CreateAsync(string name, int? parentId = null, string parentName = null);
        Task<DirectoryDto> GetAsync(int id);
        Task<DirectoryDto> GetAsync(string name);
        Task<IEnumerable<DirectoryDto>> GetAlltTreeNodes();
        Task<IEnumerable<DirectoryDto>> GetNodeOfFirstLevelChilrenAsync(int? id);
        List<DirectoryDto> GetDirectoryTree(IEnumerable<DirectoryDto> directoryTree, DirectoryDto currentDirectory = null);
        Task<IEnumerable<DirectoryDto>> GetDirectoryTreeDifference(IEnumerable<DirectoryDto> parentCollection,
             IEnumerable<DirectoryDto> childCollection, int childCollectionParentId);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, string name, int? parentId);
    }
}
