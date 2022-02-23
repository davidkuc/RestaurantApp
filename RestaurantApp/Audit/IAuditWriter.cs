namespace RestaurantApp.Audit
{
    public interface IAuditWriter
    {

        void WriteToAudit();

        void AddToAuditBatch(string auditLine);
    }


}
