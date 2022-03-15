namespace RestaurantApp.Components.Audit
{
    public interface IAuditWriter
    {

        void WriteToAudit();

        void AddToAuditBatch(string auditLine);
    }


}
