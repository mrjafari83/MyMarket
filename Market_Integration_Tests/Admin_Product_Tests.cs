using Application.Common.ViewModels;
using Market.EndPoint;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Market_Integration_Tests
{
    public class Admin_Product_Tests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private HttpClient _client;
        public Admin_Product_Tests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [MemberData(memberName: nameof(ProductData.CreateData) , MemberType = typeof(ProductData))]
        public async Task Create_Product_Test(CreateProductViewModel model)
        {
            var items = new Dictionary<string, string>()
            {
                { "Product.Name",model.Product.Name},
                { "Product.Brand",model.Product.Brand},
                { "Product.ShortDescription",model.Product.ShortDescription},
                { "Product.Description",model.Product.Description},
            };

            for(var i = 0; i < model.Keywords.Count; i++)
            {
                items.Add($"Keywords[{i}].KeywordValue" , model.Keywords[i].KeywordValue);
            }
            for (var i = 0; i < model.Colors.Count; i++)
            {
                items.Add($"Colors[{i}].Name", model.Colors[i].Name);
            }
            for (var i = 0; i < model.Sizes.Count; i++)
            {
                items.Add($"Sizes[{i}].SizeValue", model.Sizes[i].SizeValue);
            }
            for (var i = 0; i < model.Features.Count; i++)
            {
                items.Add($"Features[{i}].Displat", model.Features[i].Display);
                items.Add($"Features[{i}].FeatureValue", model.Features[i].FeatureValue);
            }
            for (var i = 0; i < model.InventoryAndPrice.Count; i++)
            {
                items.Add($"inventoryAndPrice[{i}].ColorName", model.InventoryAndPrice[i].ColorName);
                items.Add($"inventoryAndPrice[{i}].SizeName", model.InventoryAndPrice[i].SizeName);
                items.Add($"inventoryAndPrice[{i}].Inventory", model.InventoryAndPrice[i].Inventory.ToString());
                items.Add($"inventoryAndPrice[{i}].Price",model.InventoryAndPrice[i].Price.ToString());
            }

            var content = new FormUrlEncodedContent(items);
            var response = await _client.PostAsync("/Admin/Product/Create", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("true" ,responseString);
        }
    }

    public class ProductData
    {
        public static IEnumerable<object> CreateData() =>
            new List<object[]>
            {
                new object[]{ new CreateProductViewModel()
                {
                    Product = new ProductViewModel()
                    {
                        Name = "پیراهن",
                        Brand = "Zara",
                        ShortDescription = "عالی",
                        Description = "جنس خارجی",
                    },
                    Colors = new List<ColorViewModelCreate>()
                    {
                        new ColorViewModelCreate(){Name = "آبی"}
                    },
                    Sizes = new List<SizeViewModel>()
                    {
                        new SizeViewModel(){SizeValue = "لارج"}
                    },
                    Keywords = new List<KeywordViewModel>()
                    {
                        new KeywordViewModel(){KeywordValue = "پیراهن"}
                    },
                    Features = new List<FeatureViewModel>()
                    {
                        new FeatureViewModel(){Display = "جنس",FeatureValue = "کتان"}
                    },
                    InventoryAndPrice = new List<InventoryAndPriceViewModelCreate>()
                    {
                        new InventoryAndPriceViewModelCreate()
                        {
                            ColorName = "آبی",
                            SizeName = "لارج",
                            Inventory = 10,
                            Price = 300000
                        }
                    },
                    Images = new List<IFormFile>()
                }},
                new object[]{ new CreateProductViewModel()
                {
                    Product = new ProductViewModel()
                    {
                        Name = "کت",
                        Brand = "Armani",
                        ShortDescription = "عالی",
                        Description = "جنس خارجی",
                    },
                    Colors = new List<ColorViewModelCreate>()
                    {
                        new ColorViewModelCreate(){Name = "کرم"}
                    },
                    Sizes = new List<SizeViewModel>()
                    {
                        new SizeViewModel(){SizeValue = "ایکس لارج"}
                    },
                    Keywords = new List<KeywordViewModel>()
                    {
                        new KeywordViewModel(){KeywordValue = "کت"},
                        new KeywordViewModel(){KeywordValue = "کت تک"},
                    },
                    Features = new List<FeatureViewModel>()
                    {
                        new FeatureViewModel(){Display = "جنس",FeatureValue = "نخ پنبه"}
                    },
                    InventoryAndPrice = new List<InventoryAndPriceViewModelCreate>()
                    {
                        new InventoryAndPriceViewModelCreate()
                        {
                            ColorName = "کرم",
                            SizeName = "ایکس لارج",
                            Inventory = 5,
                            Price = 600000
                        }
                    },
                    Images = new List<IFormFile>()
                }},
            };
    }
}
