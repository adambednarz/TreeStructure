using System.Collections.Generic;

namespace TreeStructure.DTO
{
    public class DirectoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<DirectoryDto> DirectoryChildren { get; set; }

        public DirectoryDto()
        {
            DirectoryChildren = new List<DirectoryDto>();
        }
    }
}
