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
    public partial class find : Form
    {
        Form1 form1;
        public find(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        //查找下一个
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Enabled)
                form1.find(textBox1.Text, radioButton1.Checked, checkBox1.Checked);
            else
                form1.find(textBox1.Text, radioButton1.Checked, false);
        }

        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //向上不支持大小写
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                checkBox1.Enabled = false;
            else
                checkBox1.Enabled = true;
        }

        //查找功能的enabled 
        private void text_box_1_changed(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
