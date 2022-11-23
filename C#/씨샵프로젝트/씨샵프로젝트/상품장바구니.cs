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
    public partial class 상품장바구니 : Form
    {
        int n;
        public 상품장바구니(string s,int num)
        {
            InitializeComponent();
            label3.Text = s;
            n = num;
        }
        class UEE : ApplicationException
        {
            public UEE(string s) : base(s) { }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(textBox1.Text) <= 0)
                {
                    throw new UEE("0이하의 개수는 입력 불가능합니다.");
                }
                else if (int.Parse(textBox1.Text) > n)
                {
                    throw new UEE("재고수량인 " + n + "개 초과는 입력하실 수 없습니다.");
                }
                else
                {
                    소비자상품.num = int.Parse(textBox1.Text);
                    this.Close();
                }
            }
            catch(UEE e1)
            {
                MessageBox.Show(e1.Message);
            }
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
