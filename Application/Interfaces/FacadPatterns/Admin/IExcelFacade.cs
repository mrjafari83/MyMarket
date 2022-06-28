using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Excel.Commands.CreateExcelKey;
using Application.Services.Admin.Excel.Commands.UpdateStatus;
using Application.Services.Admin.Excel.Commands.SetFileName;
using Application.Services.Admin.Excel.Commands.DeleteAll;
using Application.Services.Admin.Excel.Queries.GetAllExcels;
using Common.Enums;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IExcelFacade
    {
        ICreateExcelKeyService CreateExcelKey { get; }
        IUpdateStatusService UpdateStatus { get; }
        ISetFileNameService SetFileName { get; }
        IDeleteAllService DeleteAll { get; }
        IGetAllExcelsService GetAllExcels { get; }
    }
}
