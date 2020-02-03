using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class HomeTreeViewComponentModel
    {
        public IEnumerable<DirectoryDto> TreeModel { get; set; }
        public string Order { get; set; }
    }
}
