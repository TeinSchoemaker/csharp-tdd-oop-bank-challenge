using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        public decimal RequestedAmount { get; set; }
        public bool Approved { get; set; }

        public Overdraft(decimal requestedAmount)
        {
            
        }

        public void Approve() => Approved = true;
        public bool Denied() => Approved = false;
    }
}
