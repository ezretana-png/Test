using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEdwinZR
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Keywords { get; set; }
    }

   

}
