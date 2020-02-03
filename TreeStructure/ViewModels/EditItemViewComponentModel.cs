using System.Collections.Generic;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class EditItemViewComponentModel
    {
        public int Id { get; set; } = 0;
        public string NewName { get; set; } = null;
        public int? ParentId { get; set; } = null;
        public string Order { get; set; }
        public IEnumerable<DirectoryDto> TreeModel { get; set; }
    }
}
