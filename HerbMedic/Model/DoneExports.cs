using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Model
{
    public class DoneExports
    {
        public string name { get; set; }
        public int quantity { get; set; }

        public DoneExports(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }
}
