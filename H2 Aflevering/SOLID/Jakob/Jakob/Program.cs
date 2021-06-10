using System;

namespace Jakob
{
    class Program
    {
        static void Main(string[] args)
        {
            //Changed Message.To to be a string[] from a string.
            //Then it can automatically check up on it to determine how many it should send to

            MessageController controller = new MessageController();

            Message message = new Message(new string[] { "Recipiant" }, "Mads", "Hello recipiant", "Test Message", "image0812.png");

            controller.Send(MessageCarrier.Smtp, message, false);

        }
    }

}
