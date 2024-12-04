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
        public static tcpclientcon con;
        public Form1()
        {
            InitializeComponent();
            con = new tcpclientcon("0.0.0.0", 1200);
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
            con.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " ") return;

            if (con.SendMessage(textBox1.Text, button1, textBox1)) textBox1.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Conectado: False";
        }

        private void conupdate_Tick(object sender, EventArgs e)
        {
            label1.Text = "Conectado: " + con.isConnected;
            button1.Enabled = con.isConnected;
        }
    }
}
