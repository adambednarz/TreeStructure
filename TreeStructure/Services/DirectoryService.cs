using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
using TreeStructure.DTO;
using TreeStructure.Extensionx;
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


        public async Task CreateAsync(string name, int? parentId = null, string parentName = null)
        {

            if (parentId == null && parentName != null)           // required for DatainitIalizer service
            {
                var parent = await _directoryRepository.GetOrFailAsync(parentName);
                parentId = parent.Id;
            }
            else if (parentId != null)
            {
                await _directoryRepository.GetOrFailAsync((int)parentId);
            }

            var directoryChildren = await GetNodeChilrenAsync(parentId);
            if (directoryChildren.Any(x => x.Name == name))
            {
                throw new Exception($"The folder with name '{name}' already exist in the current directory.");
            }

            var directory = new Directory(name, parentId);
            await _directoryRepository.AddAsync(directory);
        }

        public async Task<ICollection<DirectoryDto>> BrowseAsync()
        {
            var directories = await _directoryRepository.GetAllAsync();
            if (directories == null)
                return null;

            return _mapper.Map<ICollection<DirectoryDto>>(directories);
        }

        public async Task<DirectoryDto> GetAsync(int id)
        {
            var directory = await _directoryRepository.GetAsync(id);
            if (directory == null)
                return null;

            return _mapper.Map<DirectoryDto>(directory);
        }

        public async Task<DirectoryDto> GetAsync(string name)
        {
            var directory = await _directoryRepository.GetAsync(name);
            if (directory == null)
                return null;

            return _mapper.Map<DirectoryDto>(directory);
        }

        public async Task<ICollection<DirectoryDto>> GetNodeChilrenAsync(int? id)
        {
            var directories = await _directoryRepository.GetChildrenAsync(id);
            if (directories == null)
                return null;

            return _mapper.Map<ICollection<DirectoryDto>>(directories);
        }

        public List<DirectoryDto> GetDirectoryTree(ICollection<DirectoryDto> directoryTree, DirectoryDto currentDirectory = null)
        {
            if (currentDirectory != null)
            {
                foreach (var item in directoryTree)
                {
                    item.DirectoryChildren = GetChildernRecursive(directoryTree, currentDirectory);
                }
                //currentDirectory.DirectoryChildren = GetChildernRecursive(directoryTree, currentDirectory);
                return directoryTree.Where(b => b.ParentId == currentDirectory.Id).ToList();
            }
            else
            {
                foreach (var item in directoryTree)
                {
                    item.DirectoryChildren = GetChildernRecursive(directoryTree, item);
                }

                return directoryTree.Where(b => b.ParentId == null).ToList();
            }
        }

        private ICollection<DirectoryDto> GetChildernRecursive(ICollection<DirectoryDto> allDirectories, DirectoryDto directory)
        {
            if (allDirectories.All(b => b.ParentId != directory.Id)) return null;

            directory.DirectoryChildren = allDirectories
                .Where(b => b.ParentId == directory.Id)
                .ToList();

            foreach (var item in directory.DirectoryChildren)
            {
                item.DirectoryChildren = GetChildernRecursive(allDirectories, item);
            }

            return directory.DirectoryChildren;
        }
        public async Task RemoveAsync(int id)
        {
            var children = await GetNodeChilrenAsync(id);
            if (children != null)
            {
                foreach (var item in children)
                {
                    await RemoveChildrenRecursive(children);
                }
            }
            await RemoveDirectoryAsync(id);
        }

        private async Task RemoveChildrenRecursive(ICollection<DirectoryDto> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var children = await GetNodeChilrenAsync(item.Id);
                    await RemoveChildrenRecursive(children);
                    await RemoveDirectoryAsync(item.Id);
                }
            }
        }

        private async Task RemoveDirectoryAsync(int id)
        {
            var directory = await _directoryRepository.GetAsync(id);
            if (directory != null)
                await _directoryRepository.RemoveAsync(directory);
        }

        public async Task UpdateAsync(int id, string name, int? parentId)
        {
            var directory = await _directoryRepository.GetAsync(id);
            directory.SetName(name);
            directory.SetParent(parentId);
            await _directoryRepository.UpdateAsync(directory);
        }
    }
}
