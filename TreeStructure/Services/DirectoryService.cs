﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var directoryChildren = await GetNodeOfFirstLevelChilrenAsync(parentId);
            if (directoryChildren.Any(x => x.Name == name))
            {
                throw new Exception($"The folder with name '{name}' already exist in the current directory.");
            }

            var directory = new Directory(name, parentId);
            await _directoryRepository.AddAsync(directory);
        }

        public async Task<IEnumerable<DirectoryDto>> GetAlltTreeNodes()
        {
            var directories = await _directoryRepository.GetAllAsync();
            if (directories == null)
                return null;

            return _mapper.Map<IEnumerable<DirectoryDto>>(directories);
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

        public async Task<IEnumerable<DirectoryDto>> GetNodeOfFirstLevelChilrenAsync(int? id)
        {
            var directories = await _directoryRepository.GetChildrenAsync(id);
            if (directories == null)
                return null;

            return _mapper.Map<ICollection<DirectoryDto>>(directories);
        }

        public List<DirectoryDto> GetDirectoryTree(IEnumerable<DirectoryDto> directoryTree, DirectoryDto currentDirectory = null)
        {
            if (currentDirectory != null)
            {
                foreach (var item in directoryTree)
                {
                    item.DirectoryChildren = GetChildernRecursive(directoryTree, item);
                }

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

        private IEnumerable<DirectoryDto> GetChildernRecursive(IEnumerable<DirectoryDto> allDirectories, DirectoryDto directory)
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
            var children = await GetNodeOfFirstLevelChilrenAsync(id);
            if (children != null)
            {
                foreach (var item in children)
                {
                    await RemoveChildrenRecursive(children);
                }
            }
            await RemoveDirectoryAsync(id);
        }

        private async Task RemoveChildrenRecursive(IEnumerable<DirectoryDto> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var children = await GetNodeOfFirstLevelChilrenAsync(item.Id);
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

        public async Task<IEnumerable<DirectoryDto>> GetDirectoryTreeDifference(IEnumerable<DirectoryDto> parentCollection,
            IEnumerable<DirectoryDto> childCollection, int childCollectionParentId)
        {
            //var allDirectories = await GetAlltTreeNodes();
            //var children = await GetNodeOfFirstLevelChilrenAsync(id);
            {
                foreach (var item in childCollection.ToList())
                {
                    parentCollection = await SubtractChildrenRecursive(parentCollection, childCollection);
                }
            }
            return parentCollection.Where(x => x.Id != childCollectionParentId);
        }

        private async Task<IEnumerable<DirectoryDto>> SubtractChildrenRecursive(IEnumerable<DirectoryDto> bascollection, IEnumerable<DirectoryDto> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection.ToList())
                {
                    var children = await GetNodeOfFirstLevelChilrenAsync(item.Id);
                    await SubtractChildrenRecursive(bascollection, children);
                    bascollection = bascollection.Where(x => x.Id != item.Id);
                }
            }
            return bascollection;
        }
    }
}
