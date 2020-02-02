using System;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
using TreeStructure.Models;

namespace TreeStructure.Extensionx
{
    public static class RepositoryExtensions
    {
        public static async Task<Directory> GetOrFailAsync(this IDirectoryRepository repository, int id)
        {
            var directory = await repository.GetAsync(id);
            if (directory == null)
                throw new Exception($"Directory with id '{id}' does not exist.");

            return directory;
        }

        public static async Task<Directory> GetOrFailAsync(this IDirectoryRepository repository, string name)
        {
            var directory = await repository.GetAsync(name);
            if (directory == null)
                throw new Exception($"Directory with id '{name}' does not exist.");

            return directory;
        }
    }
}
