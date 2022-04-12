using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.BlogPages.Queries.GetBlogPageById;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Client;

namespace Application.FacadPatterns.Client
{
    public class ClientBlogPagesFacad : IClientBlogPageFacad
    {
        private readonly IDataBaseContext db;
        public ClientBlogPagesFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetBlogPageByIdService _getBlogPageByIdService;
        public IGetBlogPageByIdService GetBlogPageByIdService
        {
            get
            {
                return _getBlogPageByIdService == null ? new GetBlogPageByIdService(db) : _getBlogPageByIdService;
            }
        }
    }
}
