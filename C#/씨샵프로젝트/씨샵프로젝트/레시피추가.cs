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
    public partial class 레시피추가 : Form
    {
        레시피이름넘겨주기 n;
        레시피 r;
        public 레시피추가(레시피이름넘겨주기 name,레시피 recipe)
        {
            n = name;
            r = recipe;
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //취소
            if(MessageBox.Show("취소하시겠습니까?","레시피추가 닫기",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                r.name = "없음";
                this.Close();
            }
        }
        bool checkName()
        {
            for (int i = 0; i < n.name.Length; i++)
            {
                if (n[i].Equals(textBox1.Text))
                    return true;
            }
            return false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //확인 레시피뷰에 데이터 확인 및 레시피이름 중복 아닐 시 넣어주기.
            if (checkName())//중복임
            {
                MessageBox.Show("이미 등록된 레시피 입니다.");
            }
            else//중복아님
            {
                //레시피 값 변경시켜주기
                r.setIndex(listBox1.Items.Count);
                r.name = textBox1.Text;
                for(int i = 0; i < listBox1.Items.Count; i++)
                {
                    r[i].name = (string)listBox1.Items[i];
                }
                r.image = textBox2.Text;
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //추가
            if (textBox3.Text != string.Empty)
            {
                int index = listBox1.FindString(textBox3.Text);
                if (index != -1)
                {
                    listBox1.SetSelected(index, true);
                    MessageBox.Show("이미 등록된 상품입니다.","오류" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    listBox1.Items.Add(textBox3.Text);
                    textBox3.Text = "";
                }
                   
            }
            else
            {
                MessageBox.Show("추가할 항목을 입력해 주세요");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //이미지 불러오기
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "PNG 파일(*.PNG)|*.PNG|JPEG 파일(*.JPG)|*.JPG|GIF 파일(*.GIF)|*.GIF";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //삭제
            if (listBox1.SelectedIndex > -1)
            {
                if (MessageBox.Show(listBox1.SelectedItem + "을 삭제하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            } 
            else
                MessageBox.Show("항목을 선택해 주세요.");
        }
    }
}
