using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Spec
{
    public class CatalogSpecParams
    {
        private const int MaxSize = 80;
        private int _pagesize = 10;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _pagesize;
            set => _pagesize = value > MaxSize ? MaxSize : value;
        }
        public string? BrandId { get; set; }
        public string? TypeId { get; set; }


        public string? Sort { get; set; }
        public string? Search { get; set; }
    }
}
