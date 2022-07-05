using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Options.Queries.GetEntitiesByFilter;
using Application.Services.Admin.Options.Commands.CreateSearchFilter;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IOptionFacade
    {
        IGetEntitiesByFilterService GetEntitiesByFilter { get; }
        ICreateSearchFilterService CreateSearchFilter { get; }
    }
}
