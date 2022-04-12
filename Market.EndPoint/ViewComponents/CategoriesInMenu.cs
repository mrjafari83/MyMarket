using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Application.Services.Common.Category.Queries.GetAllCategories;

namespace Market.EndPoint.ViewComponents
{
    public class CategoriesInMenu : ViewComponent
    {
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public CategoriesInMenu(ICommonCategorisFacad commonCategorisFacad)
        {
            _commonCategorisFacad = commonCategorisFacad;
        }

        public IViewComponentResult Invoke(Enums.CategoryType categoryType)
        {
            ViewBag.CategoryType = categoryType;
            var categories = new List<GetAllCategoriesDto>();

            switch (categoryType)
            {
                case Enums.CategoryType.Product:
                    {
                        categories = _commonCategorisFacad.GetAllProductCategories.Execute(true,Enums.CategoriesFilter.Menu).Data;
                        break;
                    }
                case Enums.CategoryType.BlogPage:
                    {
                        categories = _commonCategorisFacad.GetAllBlogCategories.Execute(true, Enums.CategoriesFilter.Menu).Data;
                        break;
                    }
            }

            return View("CategoriesInMenu" , categories.OrderByDescending(c=> c.Children.Count()).ToList());
        } 
    }
}
