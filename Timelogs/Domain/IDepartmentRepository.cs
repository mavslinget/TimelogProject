using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IDepartmentRepository : IRepository<Departments>
    {
        PaginationResult<Departments> RetrieveDepartmentWithPagination(int page, int itemsPerPage, string filter);

    }
}
