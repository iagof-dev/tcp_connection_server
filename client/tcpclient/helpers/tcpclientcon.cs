using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tcpclient.events;

namespace tcpclient.helpers
{

    public class tcpclientcon
    {
        SimpleTcpClient client;
        events.tcpevents events = new events.tcpevents();

        public tcpclientcon(String address, int port)
        {
            client = new SimpleTcpClient(address + ":" + port.ToString());
            client.Events.Connected += events.Connected;
            client.Events.Disconnected += events.Disconnected;
            client.Events.DataReceived += events.DataReceived;
        }

        public void Connect()
        {
            try
            {
                client.Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Erro!");
            }
        }
        public void Disconnect()
        {
            client.Disconnect();
        }
        public void SendMessage(String message)
        {
            client.Send(message);
        }
    }
}
