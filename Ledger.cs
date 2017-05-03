using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLedger
{
    public class Ledger
    {
        public List<Transaction> Transactions;

        public Ledger()
        {
            this.Transactions = new List<Transaction>();
        }
    }
}
