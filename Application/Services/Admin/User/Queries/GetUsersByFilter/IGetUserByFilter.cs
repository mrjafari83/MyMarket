using Application.Common.ViewModels.SearchViewModels;
using Application.Persistance.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.User.Queries.GetUsersByFilter
{
    public interface IGetUserByFilter
    {
        IQueryable<ApplicationUser> GetUsers(UserSearchVIewModel searchModel);
    }
}
