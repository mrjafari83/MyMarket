using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.ViewModels
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
        public Enums.Enums.PagesFilter OrderBy { get; set; } = Enums.Enums.PagesFilter.Newest;

        ///<summary>جستوجو بر اساس : </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Enums.PageFilterCategory SearchBy { get; set; } = Enums.Enums.PageFilterCategory.Name;
    }
}
