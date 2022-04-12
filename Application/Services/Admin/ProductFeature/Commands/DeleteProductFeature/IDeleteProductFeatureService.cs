using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.ProductFeature.Commands.DeleteProductFeature
{
    public interface IDeleteProductFeatureService
    {
        ResultDto Execute(int id);
    }
}
