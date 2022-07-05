using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ProducsSearchViewModel
    {
        public string SearchKey { get; set; } = "";
        public int StartPrice { get; set; } = 0;
        public int EndPrice { get; set; } = 0;
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Enums.PagesFilter OrderBy { get; set; } = Enums.Enums.PagesFilter.Newest;
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Enums.PageFilterCategory SearchBy { get; set; } = Enums.Enums.PageFilterCategory.Name;
    }
}
