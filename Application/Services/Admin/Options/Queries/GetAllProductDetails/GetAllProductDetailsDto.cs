using System.ComponentModel.DataAnnotations;

namespace Application.Services.Admin.Options.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsDto
    {
        [Display(Name = "نام")]
        public string Name { get; set; } = "";
        [Display(Name = "نام دسته بندی")]
        public string CategoryName { get; set; } = "";
        [Display(Name = "برند")]
        public string Brand { get; set; } = "";
        [Display(Name = "تعداد فروخته شده")]
        public int SellsCount { get; set; } = 0;
        [Display(Name = "تعداد بازدید")]
        public int VisitNumber { get; set; } = 0;
    }
}
