using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities
{
    public class RefDetail
    {
        public Guid RefDetailID { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public string collectionType { get; set; }
        public Guid RefId { get; set; }
        public Ref Ref { get; set; }
    }
}
