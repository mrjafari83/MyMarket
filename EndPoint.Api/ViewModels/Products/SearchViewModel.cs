using Common.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EndPoint.Api.ViewModels.Products
{
    public class SearchViewModel
    {
        ///<summary>جستوجو کنید...</summary>
        public string SearchKey { get; set; } = "";

        ///<summary>از قیمت : </summary>
        public int StartPrice { get; set; } = 0;

        ///<summary>تا قیمت : </summary>
        public int EndPrice { get; set; } = 0;

        ///<summary>مرتب سازی بر اساس : </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PagesFilter OrderBy { get; set; } = Enums.PagesFilter.Newest;

        ///<summary>جستوجو بر اساس : </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PageFilterCategory SearchBy { get; set; } = Enums.PageFilterCategory.Name;
    }
}
