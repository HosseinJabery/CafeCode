using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Caption { get; set; }
        public int? ParenId { get; set; }
        public virtual Menu ParenMenu { get; set; }
        public virtual ICollection<Menu> Children { get; set; }
    }
}
