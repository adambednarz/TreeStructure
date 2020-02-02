using System.Collections.Generic;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class EditItemViewComponentModel
    {
        public int Id { get; set; } = 0;
        public string NewName { get; set; } = null;
        public int? ParentId { get; set; } = null;
        public bool FirstCall { get; set; }
        public bool Confirmed { get; set; } = false;
        public IEnumerable<DirectoryDto> EditDirModel { get; set; }
        public IEnumerable<DirectoryDto> SelectDirModel { get; set; }
    }
}
