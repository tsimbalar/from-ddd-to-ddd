using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.ORM.DataAccess;

namespace Sample._01_ORM
{
    class Example
    {
        public static async void UpdateUseCase(string customerId)
        {
            using (var db = new NorthwindContext())
            {
                var customer = await db.Customers
                    .Where(e => e.CustomerId == customerId)
                    .SingleOrDefaultAsync();

                if (customer.Orders.Count > 10)
                {
                    customer.ContactTitle = "VIP";
                }

                await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Orders>> QueryUseCase(DateTime orderDate)
        {
            using (var db = new NorthwindContext())
            {
                var orders = await db.Orders
                    .Where(o => o.OrderDetails.Count > 5)
                    .Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Date == orderDate)
                    .OrderBy(o => o.OrderId)
                    .Include(o => o.Customer)
                    .ToListAsync();

                return orders;
            }
        }
    }
}
