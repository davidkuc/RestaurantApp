using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Audit
{
    public abstract class BaseAuditWriter : IAuditWriter
    {       

        public abstract void WriteToAudit();

        public abstract void AddToAuditBatch(string auditLine);

    }


}
