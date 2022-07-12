﻿using Application.Interfaces.Context;
using Common.Enums;
using Common.ViewModels.SearchViewModels;
using Domain.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Message.Queries.GetMessagesBySearch
{
    public class GetMessagesBySearch
    {
        public static IQueryable<CriticismMessage> GetMessages(IDataBaseContext db , MessageSearchViewModel searchModel)
        {
            var data = db.CriticismMessages.AsQueryable();

            data = searchModel.SearchBy switch
            {
                Enums.MesssagesFilter.Name => data.Where(m => m.Name.Contains(searchModel.SearchKey)),
                Enums.MesssagesFilter.Email => data.Where(m => m.Email.Contains(searchModel.SearchKey)),
                Enums.MesssagesFilter.Website => data.Where(m => m.Website.Contains(searchModel.SearchKey)),
                Enums.MesssagesFilter.Text => data.Where(m => m.Message.Contains(searchModel.SearchKey)),
            };

            return data;
        }
    }
}
