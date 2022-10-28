using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Cqrs.Paging
{
    public sealed class PagingInformation
    {
        public readonly int PageIndex;
        public readonly int PageSize;

        public PagingInformation(int pageIndex, int pageSize)
        {
            if (pageIndex < 0) throw new ArgumentOutOfRangeException("pageIndex");
            if (pageSize <= 0) throw new ArgumentOutOfRangeException("pageSize");

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}
