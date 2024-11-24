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

        public bool isConnected = false;
        SimpleTcpClient client;
        events.tcpevents events = new events.tcpevents();

        public tcpclientcon(String address, int port)
        {
            client = new SimpleTcpClient(address + ":" + port.ToString());
            client.Keepalive.EnableTcpKeepAlives = true;
            client.Events.Connected += events.Connected;
            client.Events.Disconnected += events.Disconnected;
            client.Events.DataReceived += events.DataReceived;
        }

        public void Connect()
        {
            try
            {
                client.Connect();
                isConnected = true;
            }
            catch (Exception e)
            {
                isConnected = false;
                MessageBox.Show(e.Message,"Erro!");
            }
        }
        public void Disconnect()
        {
            client.Disconnect();
            isConnected = false;
        }
        public bool SendMessage(String message, Button btn, TextBox txtbox)
        {
            btn.Enabled = false;
            txtbox.Enabled = false;
            try {
                client.Send(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro!");
                return false;

            }
            btn.Enabled = true;
            txtbox.Enabled = true;
            return true;
        }
    }
}
