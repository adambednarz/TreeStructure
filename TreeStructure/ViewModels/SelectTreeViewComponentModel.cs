using System.Collections.Generic;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class SelectTreeViewComponentModel
    {
        public string Name { get; set; } = null;
        public int? ParentId { get; set; } = 0;
        public ICollection<DirectoryDto> SelectDirModel { get; set; }
    }
}
