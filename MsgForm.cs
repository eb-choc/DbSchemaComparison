using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public partial class MsgForm : Form
    {
        public MsgForm()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            if (this.InvokeRequired)
            {
                Action<string> act = SetText;
                this.Invoke(act, text);
            }
            else
            {
                if (this.Visible == false)
                {
                    this.Visible = true;                    
                }
                richTextBox1.Text = richTextBox1.Text + text + Environment.NewLine;
                this.richTextBox1.Select(this.richTextBox1.TextLength, 0);
                //滚动到控件光标处 
                this.richTextBox1.ScrollToCaret();
            }
        }

        public void ClearText()
        {
            if(richTextBox1.InvokeRequired)
            {
                Action act = ClearText;
                richTextBox1.Invoke(act);
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MsgForm_Load(object sender, EventArgs e)
        {
            this.Top = Screen.AllScreens[0].WorkingArea.Height - this.Height;
            this.Left = Screen.AllScreens[0].WorkingArea.Width - this.Width;
        }
    }
}
