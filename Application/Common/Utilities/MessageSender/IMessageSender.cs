using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities.MessageSender
{
    public interface IMessageSender
    {
        public Task SendAsync(string toMail , string subject , string message , bool isMessageHtml = false);
    }
}
