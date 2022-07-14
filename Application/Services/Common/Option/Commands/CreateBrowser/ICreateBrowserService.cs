using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Common.Option.Commands.CreateBrowser
{
    public interface ICreateBrowserService
    {
        ResultDto<string> Execute();
    }
}
