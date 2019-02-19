using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ITimelogRepository : IRepository<Timelog>
    {
        //PaginationResult<Timelog> RetrieveTimetWithPagination(int page, int itemsPerPage, string filter);

    }
}
