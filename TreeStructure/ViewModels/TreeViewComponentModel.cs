using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class TreeViewComponentModel
    {
        public bool IsFirstCall { get; set; }
        public ICollection<DirectoryDto> DirModel { get; set; }

    };
}
