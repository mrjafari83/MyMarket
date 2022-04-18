using System.Collections.Generic;

namespace Application.Services.Admin.CartPaying.Queries.GetAllCartPayings
{
    public class ResultGetAllCartPayingsDto
    {
        public int TotalRows { get; set; }
        public List<GetAllCartPayingsDto> CartPayings { get; set; }
    }
}
