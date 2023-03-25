using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ukolBin1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ShowIcon = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
       

            FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs, Encoding.GetEncoding("Windows-1250"));

            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                if (br.ReadChar() == '?')
                {
                    label3.Text = br.BaseStream.Position.ToString();
                    fs.Seek(-sizeof(char), SeekOrigin.Current);
                    label4.Text = br.ReadChar().ToString();
                    break;
                }               
            }
            if (br.BaseStream.Position == br.BaseStream.Length) MessageBox.Show("Soubor neobsahuje otaznik!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fs.Close();

        }
    }
}
