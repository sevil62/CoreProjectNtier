using Project.ENTITIES.Models;
using System.Collections.Generic;

namespace Project.CoreUI.Models.PageVM
{
    public class CategoryPageVM
    {

        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
