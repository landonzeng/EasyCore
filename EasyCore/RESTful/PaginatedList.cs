using System.Collections.Generic;

namespace EasyCore.Repository.RESTful
{
    public class PaginatedList<T> : List<T> where T : class
    {
        public PaginationBase PaginationBase { get; }

        public int TotalItemsCount { get; set; }
        public int PageCount => TotalItemsCount / PaginationBase.PageSize + (TotalItemsCount % PaginationBase.PageSize > 0 ? 1 : 0);

        public bool HasPrevious => PaginationBase.PageIndex > 0;
        public bool HasNext => PaginationBase.PageIndex < PageCount - 1;

        public PaginatedList(int pageIndex, int pageSize, int totalItemsCount, IEnumerable<T> data)
        {
            PaginationBase = new PaginationBase
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            TotalItemsCount = totalItemsCount;
            AddRange(data);
        }
    }
}
