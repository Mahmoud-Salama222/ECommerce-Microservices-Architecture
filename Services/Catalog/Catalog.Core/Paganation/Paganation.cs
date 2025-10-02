using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catalog.Core.Paganation
{
    public class Paganation<T>
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

        public Paganation(int PageIndex, int PageSize, int Count, IReadOnlyList<T> Data)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.Count = Count;
            this.Data = Data;
        }

    }
}
