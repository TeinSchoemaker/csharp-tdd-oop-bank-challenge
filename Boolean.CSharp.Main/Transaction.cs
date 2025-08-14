using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date {  get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }

        public Transaction(DateTime date, decimal credit, decimal debit)
        {
            Date = date;
            Credit = credit;
            Debit = debit;
        }
    }
}
