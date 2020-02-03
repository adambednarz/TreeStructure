using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
using TreeStructure.DTO;
using TreeStructure.Models;

namespace TreeStructure.Extensionx
{
    public static class ServiceExtensions
    {
        public static IEnumerable<DirectoryDto> OrderDirectoryBy(this IEnumerable<DirectoryDto> directories, string orderType)
        {
            if (orderType == "ascending")
                directories = directories.OrderBy(x => x.Name).ToList();
            else if (orderType == "descending")
                directories = directories.OrderByDescending(x => x.Name).ToList();
            else if (orderType == "reverse")
                directories = directories.Reverse().ToList();

            return directories;
        }
    }
}
