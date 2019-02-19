using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        PaginationResult<Employees> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter);

    }

}
