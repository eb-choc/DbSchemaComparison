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
    public partial class frmTK : Form
    {
        public frmTK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedItems.Count == 1 && checkedListBox1.SelectedItems[0].ToString() == "C"
                && checkedListBox2.SelectedItems.Count == 1 && checkedListBox2.SelectedItems[0].ToString() == "乙")
            {
                MessageBox.Show("智商很高，可以继续！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("答案错误！", "警示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            for (int i = 0; i < 4; i++)
            {
                if (i == index) continue;
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox2.SelectedIndex;
            for (int i = 0; i < 2; i++)
            {
                if (i == index) continue;
                checkedListBox2.SetItemChecked(i, false);
            }
        }
    }
}
