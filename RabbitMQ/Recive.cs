using Application.Interfaces.FacadPatterns.Admin;
using Common.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using RabbitMQ.Excel;
using Application.Services.Admin.Options.Queries.GetAllProductDetails;

namespace RabbitMQ
{
    public interface IRecive
    {
        void ReciveCreateExcel();
    }

    public class Recive : IRecive, IDisposable
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        public IServiceProvider Services { get; set; }

        public Recive(IServiceProvider service)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("Excel.ex", "direct", true, false, null);

            Services = service;
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public void ReciveCreateExcel()
        {
            int id = 0;

            try
            {
                _channel.QueueDeclare("ExcelCreate", true, false, false, null);
                _channel.QueueBind("ExcelCreate", "Excel.ex", "create", null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var messages = message.Split("_");

                    int id = Int32.Parse(messages[0]);
                    string address = messages[1];
                    updateStatus(id,Enums.Status.ReciveFromQueue);

                    getProductDetailsExcel(id,address);
                    updateStatus(id,Enums.Status.ExcelCreated);

                    _channel.BasicAck(args.DeliveryTag, false);
                };

                _channel.BasicConsume("ExcelCreate", false, consumer);
            }
            catch
            {
                updateStatus(id, Enums.Status.ThrowExeption);
            }
        }

        private void getProductDetailsExcel(int id,string address)
        {
            using(var scope = Services.CreateScope())
            {
                var worker = scope.ServiceProvider.GetRequiredService<IGetProductDetailsExcel>();
                var excelFacade = scope.ServiceProvider.GetRequiredService<IExcelFacade>();
                var products = scope.ServiceProvider.GetRequiredService<IOptionFacade>();

                var fileName = worker.GetProductDetails<GetAllProductDetailsDto>(products.GetAllProductDetailsService.Execute(id).Data,address,"محصولات");
                excelFacade.SetFileName.SetFileName(fileName, id);
            }
        }

        private void updateStatus(int id  , Enums.Status status)
        {
            using (var scope = Services.CreateScope())
            {
                var worker = scope.ServiceProvider.GetRequiredService<IExcelFacade>();
                worker.UpdateStatus.Execute(status, id);
            }
        }
    }
}
