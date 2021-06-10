using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakob
{
    class MessageController
    {
        public MessageSender sender = new MessageSender();
        public MessageConverter converter = new MessageConverter();

        public void Send(MessageCarrier type, Message m, bool isHTML)
        {
            if (isHTML)
                m.Body = converter.ConvertBodyToHTML(m.Body);


            if (m.To.Length >= 2) //If there's more than one recipiant
            {
                sender.sendMessageToAll(type, m);
            }
            else
            {
                sender.sendMessage(type, m);
            }
        }

    }
}
