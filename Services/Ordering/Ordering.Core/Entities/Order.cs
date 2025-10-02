using Ordering.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities
{
    public class Order : BaseEntity
    {

        public string? UserName { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? AddressLine { get; set; }
        public string? EmailAddress { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Counter { get; set; }

        public string? state { get; set; }

        public string? Zibcode { get; set; }

        public string? CardName { get; set; }

        public string? CardNumber { get; set; }
        public string? Expiration { get; set; }
        public string? Cvv { get; set; }
        public int? PaymentMethod { get; set; }






    }
}
