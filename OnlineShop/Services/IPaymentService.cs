using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tourism_Project.Dtos;
using Tourism_Project.Enums;
using Tourism_Project.Models;

namespace Tourism_Project.Services
{
     public  interface IPaymentService
    {
        public Task<string> CreatePaymentSession(Order order);
        public Task<Order> UpdateOrderStatus(string sessionId, OrderStatus status);

    }
}
