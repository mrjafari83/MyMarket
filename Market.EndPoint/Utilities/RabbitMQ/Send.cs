using Application.Interfaces.FacadPatterns.Admin;
using Application.Common.Enums;
using Microsoft.AspNetCore.Hosting;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Market.EndPoint.Utilities.RabbitMQ
{
    public interface ISend
    {
        void SendToCreateExcel(int excelId, string prefixFileName);
    }

    public class Send : ISend
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private IExcelFacade _excelFacade;

        public Send(IExcelFacade excelFacade)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _excelFacade = excelFacade;

            _channel.ExchangeDeclare("Excel.ex", "direct", true, false, null);
            _channel.ExchangeDeclare("Web.Stat", "direct", true, false, null);
        }

        public void SendToCreateExcel(int excelId, string prefixFileName)
        {
            try
            {
                _channel.QueueDeclare("ExcelCreate", true, false, false, null);
                _channel.QueueBind("ExcelCreate", "Excel.ex", "create", null);

                var fileName = $"{prefixFileName}-" + DateTime.Now.ToString("yyyy-M-d-H-m-ss") + ".xlsx";
                var message = excelId.ToString();
                _excelFacade.SetFileName.SetFileName(fileName , excelId);

                var body = Encoding.UTF8.GetBytes(message);
                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish("Excel.ex", "create", properties, body);

                _excelFacade.UpdateStatus.Execute(Enums.Status.SendToQueue, excelId);
                _excelFacade.SetFileName.SetFileName(fileName, excelId);
            }
            catch
            {
                _excelFacade.UpdateStatus.Execute(Enums.Status.ThrowExeption, excelId);
            }
        }
    }
}
