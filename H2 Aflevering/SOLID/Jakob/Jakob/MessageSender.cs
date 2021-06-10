using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakob
{
    class MessageSender
    {

        //herinde sendes der en email ud til modtageren
        public void sendMessage(MessageCarrier type, Message m)
        {
            if (type.Equals(MessageCarrier.Smtp))
                Smtp(m);


            if (type.Equals(MessageCarrier.VMessage))
                VMessage(m);
        }

        //herinde sendes der en email ud til alle modtagere
        public void sendMessageToAll(MessageCarrier type, Message m)
        {
            if (type.Equals(MessageCarrier.Smtp))
                Smtp(m);


            if (type.Equals(MessageCarrier.VMessage))
                VMessage(m);
        }


        void Smtp(Message m)
        {
            //her implementeres alt koden til at sende via Smtp
        }

        void VMessage(Message m)
        {
            //her implementeres alt koden til at sende via VMessage
        }


        
    }
}
