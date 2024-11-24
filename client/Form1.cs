using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tcpclient.helpers;

namespace tcpclient
{
    public partial class Form1 : Form
    {
        tcpclientcon con;
        public Form1()
        {
            InitializeComponent();
            con = new tcpclientcon("alt.marciossupiais.shop", 1200);
        }

        private void conectarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Conectar");
            con.Connect();
            
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Fechando...");
            this.Close();
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Desconectando");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.SendMessage(textBox1.Text, button1);
        }
    }
}
