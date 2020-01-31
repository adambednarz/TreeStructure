using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
using TreeStructure.DTO;
using TreeStructure.Models;

namespace TreeStructure.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IMapper _mapper;

        public DirectoryService(IDirectoryRepository directoryRepository, IMapper mapper)
        {
            _directoryRepository = directoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DirectoryDto>> BrowseAsync()
        {
            var directories = await _directoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DirectoryDto>>(directories);
        }

        public async Task CreateAsync(string name, string parentName)
        {
            int? parentId = null;
            if (parentName != null)
            {

                var parent = await _directoryRepository.GetAsync(parentName);
                parentId = parent.Id;
            }

            var directory = new Directory(name, parentId);
            await _directoryRepository.AddAsync(directory);
        }

        public async Task CreateByIdAsync(string name, int? parentId)
        {
            var directory = new Directory(name, parentId);
            await _directoryRepository.AddAsync(directory);
        }

        public async Task<DirectoryDto> GetAsync(int id)
        {
            var directory = await _directoryRepository.GetAsync(id);
            return _mapper.Map<DirectoryDto>(directory);
        }
        public async Task<DirectoryDto> GetAsync(string name)
        {
            var directory = await _directoryRepository.GetAsync(name);
            return _mapper.Map<DirectoryDto>(directory);
        }

        public async Task<ICollection<DirectoryDto>> GetChilrenAsync(int id)
        {
            var directories = await _directoryRepository.GetChildrenAsync(id);

            return _mapper.Map<ICollection<DirectoryDto>>(directories);
        }

        public List<DirectoryDto> GetDirectoryTree(ICollection<DirectoryDto> directoryTree)
        {
            foreach (var item in directoryTree)
            {
                item.DirectoryChildren = GetDirectoryChildren(directoryTree, item);
            }

            return directoryTree.Where(b => b.ParentId == null).ToList();
        }

        private ICollection<DirectoryDto> GetDirectoryChildren(ICollection<DirectoryDto> allDirectories, DirectoryDto directory)
        {
            if (allDirectories.All(b => b.ParentId != directory.Id)) return null;

            //recursive case
            directory.DirectoryChildren = allDirectories
                .Where(b => b.ParentId == directory.Id)
                .ToList();

            foreach (var item in directory.DirectoryChildren)
            {
                item.DirectoryChildren = GetDirectoryChildren(allDirectories, item);
            }

            return directory.DirectoryChildren;
        }
        public async Task RemoveAsync(int id)
        {
            var children = await GetChilrenAsync(id);
            if (children != null)
            {
                foreach (var item in children)
                {
                    await RemoveRecursive(children);
                }
            }
            await RemoveDirAsync(id);
        }

        private async Task RemoveRecursive(ICollection<DirectoryDto> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var children = await GetChilrenAsync(item.Id);
                    await RemoveRecursive(children);
                    await RemoveDirAsync(item.Id);
                }
            }
        }

        private async Task RemoveDirAsync(int id)
        {
            var directory = await _directoryRepository.GetAsync(id);
            if(directory != null)
            await _directoryRepository.RemoveAsync(directory);
        }

        public async Task UpdateAsync(int id)
        {
            var directory = await _directoryRepository.GetAsync(id);
            await _directoryRepository.UpdateAsync(directory);
        }
    }
}
