using System.Collections.Generic;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class SelectTreeViewComponentModel
    {
        public string Name { get; set; } = null;
        public int? ParentId { get; set; } = 0;
        public IEnumerable<DirectoryDto> TreeModel { get; set; }
        public string Sign { get; set; } = "";
        public bool IsFirstCall { get; set; } = false; 
    }
}
