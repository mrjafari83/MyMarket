using Application.Interfaces.FacadPatterns.Admin;
using Common.Enums;
using Microsoft.AspNetCore.Hosting;
using RabbitMQ.Client;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Market.EndPoint.Utilities.RabbitMQ
{
    public interface ISend
    {
        void SendToCreateExcel(int excelId, int searchId, string prefixFileName);
    }

    public class Send : ISend
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private IExcelFacade _excelFacade;
        private readonly IHostingEnvironment _environment;

        public Send(IExcelFacade excelFacade, IHostingEnvironment environment)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _excelFacade = excelFacade;
            _environment = environment;

            _channel.ExchangeDeclare("Excel.ex", "direct", true, false, null);
        }

        public void SendToCreateExcel(int excelId, int searchId,string prefixFileName)
        {
            try
            {
                _channel.QueueDeclare("ExcelCreate", true, false, false, null);
                _channel.QueueBind("ExcelCreate", "Excel.ex", "create", null);

                var message = excelId.ToString() + "_" + searchId.ToString() + "_" + _environment.WebRootPath +"_"+prefixFileName;

                var body = Encoding.UTF8.GetBytes(message);
                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish("Excel.ex", "create", properties, body);

                _excelFacade.UpdateStatus.Execute(Enums.Status.SendToQueue, excelId);
            }
            catch
            {
                _excelFacade.UpdateStatus.Execute(Enums.Status.ThrowExeption, excelId);
            }
        }
    }
}
