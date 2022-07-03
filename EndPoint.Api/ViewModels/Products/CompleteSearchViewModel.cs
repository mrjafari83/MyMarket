using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels.Products
{
    public class CompleteSearchViewModel
    {
        public SearchViewModel Search { get; set; } = new SearchViewModel();

        /// <summary>شماره صفحه</summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>تعداد صفحه</summary>
        public int PageSize { get; set; } = 10;
    }
}
