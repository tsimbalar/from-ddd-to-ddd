using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sample.ORM.DataAccess;

namespace Sample._01_ORM
{
    class Example
    {
        public static async void UseCase(string customerId)
        {
            using (var db = new NorthwindContext())
            {
                var customer = await db.Customers
                    .Where(e => e.CustomerId == customerId)
                    .Include(e => e.Orders)
                    .SingleOrDefaultAsync();                

                if (customer.Orders.Count > 10)
                {
                    customer.ContactTitle = "VIP";
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
