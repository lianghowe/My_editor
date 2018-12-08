using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        string filename = "";

        //新建
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filename = "";
            this.Text = "无标题 - My_editor";
        }

        //打开
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //过滤器
            openFileDialog1.Filter = "文本文件|*.txt|所有文件|*.*";
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                filename = openFileDialog1.FileName;

                //加载文件
                richTextBox1.LoadFile(filename, RichTextBoxStreamType.PlainText);
                // 路径只剩文件名
                this.Text = filename.Substring(filename.LastIndexOf("\\") + 1) + " - My_editor";
            }
        }

        //保存
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (filename.Length > 0)
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);

            //新文件另存 
            else
                toolStripMenuItem5_Click(sender, e);
        }

        //另存为
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件|*.txt|所有文件|*.*";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {

                filename = saveFileDialog1.FileName;
                // 路径只剩文件名
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);

                this.Text = filename + " - My_editor";
            }
        }

        //页面设置
        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        //打印
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        //退出
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //撤销
        //剪切
        //复制
        //粘帖
        //删除
        //查找
        //查找下一个
        //替换
        //转到
        //全选
        //时间/日期
        //从右到左的阅读顺序

        //撤销
        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        //剪切
        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        //复制
        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        //粘帖
        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        //删除
        private void 删除LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        //位置
        int position = 0;

        //查找_click
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new find(this).Show();
        }

        //查找功能
        public void find(string find_string, bool is_up, bool is_upper)
        {
            //已经查找到文本底部，弹出用户提示
            if (position>=richTextBox1.Text.Length)
            {
                MessageBox.Show("已到文本底部，再次查找将回到顶部", "提示");
                position = 0;
                return;
            }

            //向上 
            if(is_up)
            {   
                // 此处反转一下 0 为终点，position 为起点
                position = richTextBox1.Find(find_string, 0, position, RichTextBoxFinds.Reverse);

                //找不到
                if (position == -1)
                {
                    MessageBox.Show("找不到 " + find_string);
                    position = richTextBox1.TextLength;
                }

                else
                {
                    richTextBox1.Focus();
                }
            }

            //向下 
            else
            {
                //区分大小写
                if(is_upper)
                {
                    position = richTextBox1.Find(find_string, position, RichTextBoxFinds.MatchCase);
                }

                // 不分大小写
                else
                {
                    position = richTextBox1.Find(find_string, position, RichTextBoxFinds.None);
                }

                //找不到
                if (position == -1)
                {
                    MessageBox.Show("找不到 " + find_string);
                    position = 0;
                }

                else
                {
                    richTextBox1.Focus();
                    position += find_string.Length;
                }
            }
        }

        //查找下一个
        private void 查找下一个NToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            position = richTextBox1.SelectionStart+richTextBox1.SelectedText.Length;
            position = richTextBox1.Find(richTextBox1.SelectedText, position, RichTextBoxFinds.None);

            //找不到
            if (position == -1)
            {
                MessageBox.Show("找不到 " + richTextBox1.SelectedText);
                position = 0;
            }
        }

        //替换-click
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            new replace(this).Show();
        }

        //替换功能
        public void replace(string replace_string)
        {
            if (richTextBox1.SelectedText.Length != 0)
            {
                richTextBox1.SelectedText = replace_string;
            }
        }

        //全部替换 
        public void replace_all(string find_string,string replace_string,bool is_upper_lower)
        {
            // 此处用 Regex 进行替换，RegexOptions.None 为不忽略大小写，RegexOptions.IgnoreCase 为忽略大小写
            if(is_upper_lower)
                richTextBox1.Text=Regex.Replace(richTextBox1.Text, find_string, replace_string, RegexOptions.None);
            else
                richTextBox1.Text=Regex.Replace(richTextBox1.Text, find_string, replace_string, RegexOptions.IgnoreCase);
        }

        //转到
        private void 转到GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new turn(this)).Show();
        }

        public void trun_row(int row)
        {
            if (richTextBox1.Lines.Length > row)
            {
                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(row-1);
                richTextBox1.SelectionLength = 0;
                richTextBox1.Focus();
                richTextBox1.ScrollToCaret();
            }

            else
                MessageBox.Show("超出最大行数", "提示");
        }

        //全选
        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        //时间/日期
        private void 时间日期DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = DateTime.Now.ToString();
        }

        //从右到左的阅读顺序
        private void 从右到左的阅读顺序RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.RightToLeft==RightToLeft.Yes)
            {
                richTextBox1.RightToLeft = RightToLeft.No;

                从右到左的阅读顺序RToolStripMenuItem.Image = null;
            }

            else
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
                
                从右到左的阅读顺序RToolStripMenuItem.Image = Properties.Resources.ok;
            }
        }

        //自动换行
        //字体
        //颜色

        //自动换行
        private void 自动换行WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.WordWrap)
            {
                richTextBox1.WordWrap = false;
                自动换行WToolStripMenuItem.Image = null;

                //设置状态栏不可用
                状态栏ToolStripMenuItem.Enabled = true;
                label2.Visible = true;
            }

            else
            {
                richTextBox1.WordWrap = true;
                自动换行WToolStripMenuItem.Image = Properties.Resources.ok;

                //设置状态栏可用
                状态栏ToolStripMenuItem.Enabled = false;
                label2.Visible = false;

            }
        }

        //字体
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        //颜色
        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        //状态栏
        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.WordWrap)
                if (状态栏ToolStripMenuItem.Image==null)
                {
                    状态栏ToolStripMenuItem.Image =                Properties.Resources.ok;
                    label2.Visible = true;
                }

                else
                {
                    状态栏ToolStripMenuItem.Image = null;
                    label2.Visible = false;
                }

        }

        //获得行列
        private void row_line(object sender, EventArgs e)
        {
            // richTextBox 对所有内容建立了索引。
            int index = richTextBox1.GetFirstCharIndexOfCurrentLine();
            
            int line = richTextBox1.GetLineFromCharIndex(index) + 1;
           
            int column = richTextBox1.SelectionStart - index + 1;
            this.label2.Text = string.Format("第 {0}行, {1}列", line.ToString(), column.ToString());
        }

        //帮助
        //关于

        //帮助
        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            // 浏览器打开链接
            System.Diagnostics.Process.Start("https://blog.csdn.net/welcom_/article/details/84898056");
        }

        //关于
        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            (new about()).Show();
        }
        
    }
}
