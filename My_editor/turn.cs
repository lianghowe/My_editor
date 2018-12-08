using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_editor
{
    public partial class turn : Form
    {
        Form1 form1;
        public turn(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        //转到
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                form1.trun_row(int.Parse(textBox1.Text));
            else
                MessageBox.Show("请输入行号", "提示");
        }

        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //检测按键 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = textBox1.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }

            }
        }
    }
}
