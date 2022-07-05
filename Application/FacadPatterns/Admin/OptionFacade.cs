using Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Options.Queries.GetEntitiesByFilter;
using Application.Services.Admin.Options.Commands.CreateSearchFilter;
using Microsoft.Extensions.Logging;

namespace Application.FacadPatterns.Admin
{
    public class OptionFacade : IOptionFacade
    {
        private readonly IDataBaseContext db;
        private readonly ILogger<GetEntitiesByFilterService> _getEntitiesByFilterServiceLogger;
        public OptionFacade(IDataBaseContext context)
        {
            db = context;
        }

        private GetEntitiesByFilterService _getEntitiesByFilterService;
        public IGetEntitiesByFilterService GetEntitiesByFilter 
        {
            get => _getEntitiesByFilterService ?? new GetEntitiesByFilterService(db, _getEntitiesByFilterServiceLogger);
        }

        private CreateSearchFilterService _createSearchFilterService;
        public ICreateSearchFilterService CreateSearchFilter
        {
            get => _createSearchFilterService ?? new CreateSearchFilterService(db);
        }
    }
}
