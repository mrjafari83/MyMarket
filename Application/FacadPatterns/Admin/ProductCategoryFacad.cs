using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.Categories.Commands.CreateCategory;
using Application.Services.Admin.Categories.Commands.EditCategory;
using Application.Services.Admin.Categories.Commands.DeleteCategory;
using Application.Services.Admin.Categories.Queries.GetCategoryById;

namespace Application.FacadPatterns.Admin
{
    public class ProductCategoryFacad : IProductCategoryFacad
    {
        private readonly IDataBaseContext db;
        public ProductCategoryFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetProductCategoryByIdService _getProductCategoryByIdService;
        public IGetCategoryByIdService GetById
        {
            get
            {
                return _getProductCategoryByIdService == null
                    ? new GetProductCategoryByIdService(db)
                    : _getProductCategoryByIdService;
            }
        }

        private CreateProductCategoryService _createProductCategoryService;
        public ICreateCategoryService Create
        {
            get
            {
                return _createProductCategoryService == null
                    ? new CreateProductCategoryService(db)
                    : _createProductCategoryService;
            }
        }

        private EditProductCategoryService _editProductCategoryService;
        public IEditCategoryService Edit
        {
            get
            {
                return _editProductCategoryService == null
                    ? new EditProductCategoryService(db)
                    : _editProductCategoryService;
            }
        }

        private DeleteProductCategoryService _deleteProductCategoryService;
        public IDeleteCategoryService Delete
        {
            get
            {
                return _deleteProductCategoryService == null
                    ? new DeleteProductCategoryService(db)
                    : _deleteProductCategoryService;
            }
        }
    }
}
