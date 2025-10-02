using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.IRpositries;
using Ordering.Infrastructure.AsyncRepositry;
using Ordering.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositry
{
    public class OrderRepositry : RepositryBase<Order>, IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepositry(OrderContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<Order>> GetOrderByUserName(string UserName)
        {
            var orderList = await context.Orders.Where(u => u.UserName == UserName).ToListAsync();
            return orderList;
        }


    }
}
