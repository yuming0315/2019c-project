using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 씨샵프로젝트
{
    public partial class 레시피장바구니 : Form
    {
        public 레시피장바구니(string s)
        {
            InitializeComponent();
            label3.Text = s;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //확인
            if (int.Parse(textBox1.Text) > 0)
            {
                소비자레시피.num = int.Parse(textBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("잘못된 입력입니다.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //취소
            this.Close();
        }
    }
}
