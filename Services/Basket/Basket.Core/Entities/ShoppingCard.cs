using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entities
{
    public class ShoppingCard
    {
        public string UserName { get; set; }
        public List<ShoppingCardItem> Items { get; set; }
        public ShoppingCard() { }
        public ShoppingCard(string UserName)
        {
            this.UserName = UserName;
        }


    }
}
