﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Cqrs.Paging
{
    public sealed class PagingResult<T>
    {
        public PagingInformation Paging { get; private set; }
        public int PageCount { get; private set; }
        public int ItemCount { get; private set; }
        public ReadOnlyCollection<T> Data { get; private set; }

        public PagingResult(PagingInformation paging, 
            int pageCount, int itemCount, ReadOnlyCollection<T> page)
        {
            this.Paging = paging;
            this.PageCount = pageCount;
            this.ItemCount = itemCount;
            this.Data = page;
        }

        public static PagingResult<T> ApplyPaging(IQueryable<T> query, PagingInformation paging)
        {
            int count = query.Count();
            var page = query.Skip(paging.PageSize * paging.PageIndex).Take(paging.PageSize).ToList();
            return new PagingResult<T>(
                paging: paging,
                pageCount: (count + (paging.PageSize - 1)) / paging.PageSize,
                itemCount: count,
                page: page.AsReadOnly());
        }
    }
}
