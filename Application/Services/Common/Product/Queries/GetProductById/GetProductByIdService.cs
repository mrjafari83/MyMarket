﻿using System.Linq;
using Common.Dto;
using Application.Interfaces.Context;
using Common.ViewModels;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Application.Services.Common.Comment.Queries.GetAllCommentsByPageId;

namespace Application.Services.Common.Product.Queries.GetProductById
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IDataBaseContext db;
        public GetProductByIdService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetProductByIdDto> Execute(int id)
        {
            var product = db.Products.Include(p => p.Images).Include(p => p.Features).Include(p => p.Category).Include(p=> p.Comments)
                .Include(p => p.Colors).ThenInclude(c => c.Color)
                .Include(p => p.Sizes).ThenInclude(s => s.Size)
                .Where(p => p.Id == id).Select(p => new GetProductByIdDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    ShortDescription = p.ShortDescription,
                    Description = p.Description,
                    Inventory = p.Inventory,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Price = p.Price,
                    Images = p.Images.Select(s=> new ImageViewModel { Src = s.Src}).ToList(),
                    Features = p.Features.Select(f => new FeatureViewModel { Display = f.Display, FeatureValue = f.Value }).ToList(),
                    Sizes = p.Sizes.Select(s => new SizeViewModel { SizeValue = s.Size.Value }).ToList(),
                    Colors = p.Colors.Select(c => new ColorViewModel { Name = c.Color.Name }).ToList(),
                }).FirstOrDefault();

            if (product != null)
                return new ResultDto<GetProductByIdDto>
                {
                    Data = product,
                    IsSuccess = true
                };
            else
                return new ResultDto<GetProductByIdDto>
                {
                    IsSuccess = false
                };
        }
    }
}
