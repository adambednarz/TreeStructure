using System.Collections.Generic;
using TreeStructure.DTO;

namespace TreeStructure.ViewModels
{
    public class EditItemViewComponentModel
    {
        public int Id { get; set; } = 0;
        public string NewName { get; set; } = null;
        public int? ParentId { get; set; } = 0;
        public bool FirstCall { get; set; }
        public bool Confirmed { get; set; } = false;
        public ICollection<DirectoryDto> EditDirModel { get; set; }
        public ICollection<DirectoryDto> SelectDirModel { get; set; }
    }
}
