using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Options.Queries.GetEntitiesByFilter;
using Microsoft.Extensions.Logging;
using Application.Services.Admin.User.Queries.GetUsersByFilter;
using Common.Utilities;

namespace Application.FacadPatterns.Admin
{
    public class OptionFacade : IOptionFacade
    {
        private readonly IDataBaseContext db;
        private readonly SaveLogInFile _saveLogFile;
        private readonly IGetUserByFilter _getUserBySearch;
        public OptionFacade(IDataBaseContext context, SaveLogInFile saveLogInFile, IGetUserByFilter getUserBySearch)
        {
            db = context;
            _saveLogFile = saveLogInFile;
            _getUserBySearch = getUserBySearch;
        }

        private GetEntitiesByFilterService _getEntitiesByFilterService;
        public IGetEntitiesByFilterService GetEntitiesByFilter 
        {
            get => _getEntitiesByFilterService ?? new GetEntitiesByFilterService(db,_saveLogFile,_getUserBySearch);
        }
    }
}
