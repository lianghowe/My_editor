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
    public partial class replace : Form
    {
        Form1 form1;
        public replace(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        //查找下一个
        private void button1_Click(object sender, EventArgs e)
        {
            form1.find(textBox1.Text, false, checkBox1.Checked);
        }

        //替换
        private void button2_Click(object sender, EventArgs e)
        {
            form1.replace(textBox2.Text);
        }

        //全部替换
        private void button3_Click(object sender, EventArgs e)
        {
            form1.replace_all(textBox1.Text, textBox2.Text, checkBox1.Checked);
        }

        //取消
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //button123的enabled 
        private void text_box_1_changed(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
                
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
                
        }
    }
}
