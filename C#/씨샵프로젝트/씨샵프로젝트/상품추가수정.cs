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
    
    public partial class 상품추가수정 : Form
    {
        상품 price;
        public 상품추가수정(상품 p)
        {
            InitializeComponent();
            price = p;
            if (price.name.Equals("추가")) ;
            else
            {
                textBox1.Text = p.name;
                textBox2.Text = p.money + "";
                textBox3.Text = p.weight;
                textBox4.Text = p.number + "";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //확인
            if(textBox1.Text.Equals("")|| textBox2.Text.Equals("") || 
                textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("상품정보를 입력해 주세요");
            }
            else
            {
                price.name = textBox1.Text;
                price.money = int.Parse(textBox2.Text);
                price.weight = textBox3.Text;
                price.number = int.Parse(textBox4.Text);
            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //취소
            if(price.name.Equals(textBox1.Text)||price.money==int.Parse(textBox2.Text)||
                price.number == int.Parse(textBox4.Text) || price.weight.Equals(textBox3.Text))
            {
                if (MessageBox.Show("상품수정을 취소하시겠습니까?", "",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("상품추가를 취소하시겠습니까?", "",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
