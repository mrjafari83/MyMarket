using Market.EndPoint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistance.Context;
using Xunit;
using System.Security.Claims;
using System.Security.Principal;
using Market.EndPoint.Areas.Admin.Controllers;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using AutoMapper;
using Market.EndPoint.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Hosting;
using Common.Utilities;
using Microsoft.Extensions.Configuration;
using Domain.Entities.User;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Market_Integration_Tests
{
    public class Excel_Integration_Tests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private HttpClient _client;

        public Excel_Integration_Tests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateExcelTest()
        {
            var response = await _client.GetAsync("/Admin/Product/CreateExcelConfirmed");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("پنل مدیریت", responseString);
            Assert.Contains("محصولات", responseString);
        }
    }
}
