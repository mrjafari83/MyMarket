using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Persistance.Entities.NewsBulletin
{
    public class News
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Text { get; set; }
    }
}
