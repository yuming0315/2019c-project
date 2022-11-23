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
    public partial class 관리자메뉴 : Form
    {
        public 관리자메뉴(person p)
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            관리자레시피 f = new 관리자레시피();
            f.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            관리자상품 f = new 관리자상품();
            f.ShowDialog();
            this.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("로그아웃 하시겠습니까?", "팝업",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
