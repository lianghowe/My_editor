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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        //确定 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
