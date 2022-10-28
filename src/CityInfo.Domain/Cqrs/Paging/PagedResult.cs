using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Cqrs.Paging
{
    public sealed class PagedResult<T>
    {
        public readonly PagingInformation Paging;
        public readonly int PageCount;
        public readonly int ItemCount;
        public readonly ReadOnlyCollection<T> Page;

        public PagedResult(
            PagingInformation paging, int pageCount, int itemCount, ReadOnlyCollection<T> page)
        {
            this.Paging = paging;
            this.PageCount = pageCount;
            this.ItemCount = itemCount;
            this.Page = page;
        }

        public static PagedResult<T> ApplyPaging(IQueryable<T> query, PagingInformation paging)
        {
            int count = query.Count();
            var page = query.Skip(paging.PageSize * paging.PageIndex).Take(paging.PageSize).ToList();
            return new PagedResult<T>(
                paging: paging,
                pageCount: (count + (paging.PageSize - 1)) / paging.PageSize,
                itemCount: count,
                page: page.AsReadOnly());
        }
    }
}
