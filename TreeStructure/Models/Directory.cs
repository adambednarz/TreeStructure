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
        public Directory(string name, int? parentId, int id)
        {
            Id = id;
            SetName(name);
            SetParent(parentId);
        }

        private void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new Exception("Directory can not have empty name.");
            if(name == Name)
                return;
            Name = name;
        }

        private void SetParent(int? parentId)
        {
            //if (parentId >= Id)
            //    throw new Exception("The value of parent id can not be equal and grater than id.");
            if (parentId == ParentId)
                return;
            ParentId = parentId;
        }
    }
}
