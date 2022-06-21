using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Common.Enums;
using Common.Utilities;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public class GetAllBlogPagesService : IGetAllBlogPagesService
    {
        private readonly IDataBaseContext db;
        public GetAllBlogPagesService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetAllBlogPagesResult> Execute(Enums.PagesFilter filter = Enums.PagesFilter.Newest
            , int pageNumber = 1, int pageSize = 10 , string searchKey ="" , int categoryId = 0)
        {
            int totalRows = 0;
            var blogPages = db.BlogPages.AsQueryable();

            switch (filter)
            {
                case Enums.PagesFilter.Newest:
                    {
                        blogPages.OrderByDescending(b => b.CreateDate);
                        break;
                    }
                case Enums.PagesFilter.MostViewed:
                    {
                        blogPages.OrderByDescending(b => b.Visits.Count());
                        break;
                    }
            }

            if (searchKey != "")
                blogPages = blogPages.Where(b => b.Title.Contains(searchKey) || b.ShortDescription.Contains(searchKey)).AsQueryable();

            if (categoryId != 0)
                blogPages = blogPages.Where(b => b.Category.Id == categoryId).AsQueryable();

            var finallyBlogPages = blogPages.Select(b => new GetAllBlogPagesDto
            {
                Id = b.Id,
                Title = b.Title,
                ShortDescription = b.ShortDescription,
                Image = b.Image,
                CategoryName = b.Category.Name,
                CreateDate = b.CreateDate.ToShamsi(),
                VisitNumber = b.Visits.Count(),
            }).ToPaged(out totalRows, pageNumber, pageSize).ToList();

            if (blogPages != null)
                return new ResultDto<GetAllBlogPagesResult>
                {
                    Data = new GetAllBlogPagesResult
                    {
                        BlogPages = finallyBlogPages,
                        TotalRows = totalRows
                    },
                    IsSuccess = true
                };
            else
                return new ResultDto<GetAllBlogPagesResult>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
