using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class TimelogSummaryRepository: RepositoryBase<TimelogSummary>, ITimelogSummaryRepository
    {
        public TimelogSummaryRepository(TimelogDBContext context): base(context)
        {

        }


    }
}
