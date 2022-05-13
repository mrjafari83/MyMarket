using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewsBulletin
{
    public class News
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string ImageSrc { get; set; }
    }
}
