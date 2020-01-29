using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.Models;

namespace TreeStructure.Data.Repository
{
    public interface IDirectoryRepository
    {
        Directory Get(int id);
        List<Directory> GetAll();
        void Add(Directory dir);
        void Remove(Directory dir);
        void Update(Directory dir);

        Task<bool> SaveChangesAsync();
    }
}
