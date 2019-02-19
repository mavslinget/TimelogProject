using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class DepartmentRepository : RepositoryBase<Departments>, IDepartmentRepository
    {
        public DepartmentRepository(TimelogDBContext context) : base(context)
        {

        }

        public PaginationResult<Departments> RetrieveDepartmentWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Departments> result = new PaginationResult<Departments>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Departments>().OrderBy(x => x.DepartmentName).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Departments>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Departments>()
                  .Where(x => x.DepartmentName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.DepartmentName)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Departments>()
                        .Where(x => x.DepartmentName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
