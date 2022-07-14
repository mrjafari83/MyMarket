using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.BlogPages.Queries.GetBlogPageById;
using Application.Services.Client.BlogPages.Commands.AddNewVisit;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Client;
using AutoMapper;

namespace Application.FacadPatterns.Client
{
    public class ClientBlogPagesFacad : IClientBlogPageFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public ClientBlogPagesFacad(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetBlogPageByIdService _getBlogPageByIdService;
        public IGetBlogPageByIdService GetBlogPageByIdService
        {
            get
            {
                return _getBlogPageByIdService ?? new GetBlogPageByIdService(db,_mapper);
            }
        }

        private AddNewVisitService _addNewVisitService;
        public IAddNewVisitService AddNewVisit
        {
            get
            {
                return _addNewVisitService ?? new AddNewVisitService(db);
            }
        }
    }
}
