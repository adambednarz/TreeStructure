﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructure.DTO
{
    public class DirectoryDto
    {
        public DirectoryDto()
        {
            DirectoryChildren = new List<DirectoryDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<DirectoryDto> DirectoryChildren { get; set; } = null;
    }
}