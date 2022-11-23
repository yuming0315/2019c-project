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
    public partial class 소비자메뉴 : Form
    {
        public static person data;
        public static 레시피리스트 rlist = new 레시피리스트();
        public static 상품리스트 tlist = new 상품리스트();
        public 소비자메뉴(person p)
        {
            InitializeComponent();
            data = p;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "팝업", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            소비자상품 f = new 소비자상품();
            this.Hide();
            f.ShowDialog();

            this.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //레시피메뉴
            소비자레시피 fw = new 소비자레시피();
            this.Hide();
            fw.ShowDialog();

            this.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            소비자장바구니 fw = new 소비자장바구니();
            this.Hide();
            fw.ShowDialog();

            this.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            소비자주문조회 fw = new 소비자주문조회();
            this.Hide();
            fw.ShowDialog();

            this.Show();
        }
    }
}
