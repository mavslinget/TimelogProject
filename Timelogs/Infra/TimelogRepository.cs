using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class TimelogRepository : RepositoryBase<Timelog>, ITimelogRepository
    {
        public TimelogRepository(TimelogDBContext context) : base(context)
        {

        }

        //public PaginationResult<Timelog> RetrieveTimelogWithPagination(int page, int itemsPerPage, string filter)
        //{
        //    PaginationResult<Timelog> result = new PaginationResult<Timelog>();
        //    if (string.IsNullOrEmpty(filter))
        //    {
        //        result.Results = context.Set<Timelog>().OrderBy(x => x.Time).Skip(page).Take(itemsPerPage).ToList();

        //        if (result.Results.Count > 0)
        //        {
        //            result.TotalRecords = context.Set<Timelog>().Count();
        //        }
        //    }
        //    else
        //    {
        //        result.Results = context.Set<Timelog>()
        //          .Where(x => x.Time.ToLower().Contains(filter.ToLower()))
        //          .OrderBy(x => x.Time)
        //          .Skip(page)
        //          .Take(itemsPerPage).ToList();

        //        if (result.Results.Count > 0)
        //        {
        //            result.TotalRecords = context.Set<Timelog>()
        //                .Where(x => x.Time.Contains(filter.Time()))
        //                .Count();
        //        }
        //    }

        //    return result;
        //}
    }
}
