using Application.Interfaces.Context;
using Common.Dto;
using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Options.Commands.CreateSearchFilter
{
    public interface ICreateSearchFilterService
    {
        Task<ResultDto<int>> Execute<Model>(Model model, Domain.Entities.Option.SearchItemType whichEntity) where Model : class;
    }

    public class CreateSearchFilterService : ICreateSearchFilterService
    {
        private readonly IDataBaseContext db;
        public CreateSearchFilterService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute<Model>(Model model, Domain.Entities.Option.SearchItemType whichEntity) where Model : class
        {
            var entity = await db.SearchFilter.AddAsync(new Domain.Entities.Option.SearchFilter
            {
                FilterJson = JsonConvertor<Model>.ToJson(model),
                SearchType = whichEntity
            });

            await db.SaveChangesAsync();

            return new ResultDto<int>
            {
                Data = entity.Entity.Id,
                IsSuccess = true
            };
        }
    }
}
