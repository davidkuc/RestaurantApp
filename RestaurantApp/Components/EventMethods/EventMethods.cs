using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.EventMethods
{
    public class EventMethods
    {
        #region EventHandlerMethods
        void OnEmployeeAdded(object? sender, Employee item)
        {
            var message = $"Employee {item.FirstName} {item.LastName} added by {nameof(employeeRepository)}";
            Console.WriteLine(message);
            auditWriter.AddToAuditBatch(message);
        }

        void OnEmployeeRemoved(object? sender, Employee item)
        {
            var message = $"Employee {item.FirstName} {item.LastName} removed by {nameof(employeeRepository)}";
            Console.WriteLine(message);
            auditWriter.AddToAuditBatch(message);
        }

        void OnSupplierAdded(object? sender, Supplier item)
        {
            var message = $"Supplier {item.Name} added by {nameof(supplierRepository)}";
            Console.WriteLine(message);
            auditWriter.AddToAuditBatch(message);
        }

        void OnSupplierRemoved(object? sender, Supplier item)
        {
            var message = $"SupplierEmployee {item.Name} removed by {nameof(supplierRepository)}";
            Console.WriteLine(message);
            auditWriter.AddToAuditBatch(message);
        }

        void OnSupplyAdded(object? sender, Supply item)
        {
            var message = $"Supply {item.Name} {item.Category} added by {nameof(supplyRepository)}";
            Console.WriteLine($"Supply {item.Name} {item.Category} added by {nameof(supplyRepository)}");
            auditWriter.AddToAuditBatch(message);
        }

        void OnSupplyRemoved(object? sender, Supply item)
        {
            var message = $"Supply {item.Name} {item.Category} removed by {nameof(supplyRepository)}";
            Console.WriteLine(message);
            auditWriter.AddToAuditBatch(message);
        }

        #endregion
    }
}
