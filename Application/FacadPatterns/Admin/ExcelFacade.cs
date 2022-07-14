using Persistance.Context;
using Application.Interfaces.FacadPatterns.Admin;
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
using Application.Services.Admin.Excel.Queries.GetFileName;
using Application.Services.Admin.Excel.Queries.GetExcelType;

namespace Application.FacadPatterns.Admin
{
    public class ExcelFacade : IExcelFacade
    {
        private readonly IDataBaseContext db;
        public ExcelFacade(IDataBaseContext context)
        {
            db = context;
        }

        private CreateExcelKeyService _createExcelKeyService;
        public ICreateExcelKeyService CreateExcelKey
        {
            get => _createExcelKeyService ?? new CreateExcelKeyService(db);
        }

        private UpdateStatusService _updateStatusService;
        public IUpdateStatusService UpdateStatus
        {
            get => _updateStatusService ?? new UpdateStatusService(db);
        }

        private SetFileNameService _setFileNameService;
        public ISetFileNameService SetFileName
        {
            get => _setFileNameService ?? new SetFileNameService(db);
        }

        private DeleteAllService _deleteAllService;
        public IDeleteAllService DeleteAll
        {
            get => _deleteAllService ?? new DeleteAllService(db);
        }

        private GetAllExcelsService _getAllExcelsService;
        public IGetAllExcelsService GetAllExcels
        {
            get => _getAllExcelsService ?? new GetAllExcelsService(db);
        }

        private GetFileNameService  _getFileNameService;
        public IGetFileNameService GetFileName
        {
            get => _getFileNameService ?? new GetFileNameService(db);
        }

        private GetExcelTypeService _getExcelTypeService;
        public IGetExcelTypeService GetExcelType
        {
            get => _getExcelTypeService ?? new GetExcelTypeService(db);
        }
    }
}
