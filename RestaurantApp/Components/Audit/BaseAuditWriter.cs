namespace RestaurantApp.Components.Audit
{
    public abstract class BaseAuditWriter : IAuditWriter
    {       

        public abstract void WriteToAudit();

        public abstract void AddToAuditBatch(string auditLine);

    }


}
