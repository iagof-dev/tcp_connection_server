using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpclient.events
{
    public class tcpevents
    {
        public void Connected(object sender, ConnectionEventArgs e)
        {
            Debug.WriteLine($"*** Server {e.IpPort} connected");
        }

        public void Disconnected(object sender, ConnectionEventArgs e)
        {
            Debug.WriteLine($"*** Server {e.IpPort} disconnected");
            Form1.con.isConnected = false;
        }

        public void DataReceived(object sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            Debug.WriteLine($"[{e.IpPort}] {Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count)}");
        }
    }
}
