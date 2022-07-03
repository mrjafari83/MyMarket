using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RabbitMQ_Test
{
    [TestClass]
    public class Excel
    {
        [TestMethod]
        public void GetExcelTest()
        {
            List<Sample> samples = new List<Sample>(); 
            Random random = new Random();

            for(var i = 0;i<100; i++)
                samples.Add(new Sample() { Id = random.Next()});

            IGetExcel get = new GetExcel();
            var actual = get.GetProductDetails<Sample>(samples, "/Excel/", "Sample");

            Assert.AreNotEqual(actual, "");
        }
    }

    public class Sample
    {
        [Display(Name ="آیدی")]
        public int Id { get; set; }
    }
}