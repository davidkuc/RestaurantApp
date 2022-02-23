using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Const;

namespace RestaurantApp.Audit
{
    public class AuditWriter : BaseAuditWriter
    {
        List<string> auditBatch = new List<string>();

        public override void AddToAuditBatch(string auditLine)
        {
            this.auditBatch.Add(auditLine);
        }

        public override void WriteToAudit()
        {
            using (var auditWriter = File.AppendText(Const.Const.auditTxtPath))
            {
                foreach (var item in this.auditBatch)
                {
                    auditWriter.WriteLine($"[{DateTime.Now}] --- | {item} | ---");
                }
            }

        }
    }
}
