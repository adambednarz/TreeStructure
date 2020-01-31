using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructure.ViewModels
{
    public class AddNewItemComponentModel
    {
        public string Name { get; set; } = null;
        public int? ParentId { get; set; } = 0;

    }
}
