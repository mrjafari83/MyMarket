using Application.Services.Admin.User.Queries.GetUsersByFilter;
using Common.Classes;
using Common.Enums;
using Common.ViewModels.SearchViewModels;
using Persistance.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Market.EndPoint.Repositories.User
{
    public class GetUsersByFilter : IGetUserByFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetUsersByFilter(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable<ApplicationUser> GetUsers(UserSearchVIewModel searchModel)
        {
            IQueryable<ApplicationUser> data;
            var role = searchModel.UserRole switch
            {
                Enums.RolesWithAll.Customer => RoleNames.Customer,
                Enums.RolesWithAll.Admin => RoleNames.Admin,
                Enums.RolesWithAll.Owner => RoleNames.Owner,
                Enums.RolesWithAll.All => ""
            };

            if (role == "")
                data = _userManager.Users.AsQueryable();
            else
                data = _userManager.GetUsersInRoleAsync(role).Result.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.SearchKey))
                data = searchModel.SearchBy switch
                {
                    Enums.UserSearchFilter.Name => data.Where(u => u.Name.Contains(searchModel.SearchKey)),
                    Enums.UserSearchFilter.Family => data.Where(u => u.Family.Contains(searchModel.SearchKey)),
                    Enums.UserSearchFilter.Email => data.Where(u => u.Email.Contains(searchModel.SearchKey)),
                    Enums.UserSearchFilter.UserName => data.Where(u => u.UserName.Contains(searchModel.SearchKey)),
                    _ => data
                };

            return data;
        }
    }
}
