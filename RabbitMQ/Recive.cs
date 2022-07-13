using Application.Interfaces.FacadPatterns.Admin;
using Common.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using RabbitMQ.Excel;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Common.ViewModels.SearchViewModels;
using Common.Classes;

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
            int excelId = 0;
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

                    excelId = Int32.Parse(messages[0]);
                    int searchId = Int32.Parse(messages[1]);
                    string address = messages[2];
                    string prefixFileName = messages[3];
                    updateStatus(excelId, Enums.Status.ReciveFromQueue);

                    getExcel(excelId, searchId, address, prefixFileName);
                    updateStatus(excelId, Enums.Status.ExcelCreated);

                    _channel.BasicAck(args.DeliveryTag, false);
                };

                _channel.BasicConsume("ExcelCreate", false, consumer);
            }
            catch
            {
                updateStatus(excelId, Enums.Status.ThrowExeption);
            }
        }

        private void getExcel(int excelId, int searachId, string address, string prefixFileName)
        {
            using (var scope = Services.CreateScope())
            {
                var worker = scope.ServiceProvider.GetRequiredService<IGetExcel>();
                var excelFacade = scope.ServiceProvider.GetRequiredService<IExcelFacade>();
                var optionFacad = scope.ServiceProvider.GetRequiredService<IOptionFacade>();

                var fileName = worker.GetExcelFile<object>(optionFacad.GetEntitiesByFilter.Execute(searachId).Data.ToList(), address, prefixFileName);
                if (!String.IsNullOrEmpty(fileName))
                    excelFacade.SetFileName.SetFileName(fileName, excelId);
            }
        }

        private void updateStatus(int excelId, Enums.Status status)
        {
            using (var scope = Services.CreateScope())
            {
                var worker = scope.ServiceProvider.GetRequiredService<IExcelFacade>();
                worker.UpdateStatus.Execute(status, excelId);
            }
        }
    }
}
