using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class EmployeeRepository : RepositoryBase<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(TimelogDBContext context) : base(context)
        {

        }

        public PaginationResult<Employees> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Employees> result = new PaginationResult<Employees>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Employees>().OrderBy(x => x.LastName).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employees>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Employees>()
                  .Where(x => x.LastName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.LastName)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employees>()
                         .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()) || x.LastName.ToLower().Contains(filter.ToLower())
                  || x.FullName.ToLower().Contains(filter.ToLower())).Count();
                }
            }

            return result;
        }
    }
}