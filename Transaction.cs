using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLedger
{
    public class Transaction
    {
        #region Properties

        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Decimal Amount { get; set; }
        
        // in case of record this obcject to database, be sure that
        // Category and Subcategory wont' be record.
        // The same valuses must be set in Tags
        // Tags is the target type for this properties
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string[] Tags { get; set; }

        #endregion 
    }
}
