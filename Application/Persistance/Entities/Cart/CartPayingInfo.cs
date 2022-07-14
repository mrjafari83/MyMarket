using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Common;

namespace Application.Persistance.Entities.Cart
{
    public class CartPayingInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime PayDate { get; set; }
        public bool IsPayed { get; set; }
        public bool Sended { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<ProductInCart> Products { get; set; }
    }
}
