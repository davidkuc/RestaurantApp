using RestaurantApp.Data;

namespace RestaurantApp.Components.Audit
{
    public class AuditWriter : BaseAuditWriter
    {
        List<string> auditBatch = new List<string>();

        public override void AddToAuditBatch(string auditLine)
        {
            auditBatch.Add(auditLine);
        }

        public override void WriteToAudit()
        {
            using (var auditWriter = File.AppendText(Constants.auditTxtPath))
            {
                foreach (var item in auditBatch)
                {
                    auditWriter.WriteLine($"[{DateTime.Now}] --- | {item} | ---");
                }
            }

        }
    }
}
