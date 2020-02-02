using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructure.Models
{
    public class Directory
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int? ParentId { get; protected set; }

        public Directory(string name, int? parentId)
        {
            SetName(name);
            SetParent(parentId);
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new Exception("Directory can not have empty name.");
            if(name == Name)
                return;
            Name = name;
        }

        public void SetParent(int? parentId)
        {
            if (parentId == ParentId)
                return;
            ParentId = parentId;
        }
    }
}
