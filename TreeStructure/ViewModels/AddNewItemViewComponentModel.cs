using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructure.ViewModels
{
    public class AddNewItemViewComponentModel
    {
        public string Name { get; set; } = null;
        public int? ParentId { get; set; } = null;
        public string Order { get; set; }
    }
}
