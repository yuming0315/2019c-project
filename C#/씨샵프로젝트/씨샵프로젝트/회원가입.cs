using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 씨샵프로젝트
{
    public partial class 회원가입 : Form
    {
        public 회원가입()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("회원정보를 모두 입력해 주세요", "확인");
            }
            else
            {
                if (textBox1.Text.Contains('/') || textBox2.Text.Contains('/') || textBox3.Text.Contains('/') || textBox4.Text.Contains('/'))
                {
                    MessageBox.Show("특수문자 /는 입력할 수 없습니다.","확인");
                }
                else
                {
                    FileStream fs = new FileStream("C:/temp/user.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(textBox1.Text + '/' + textBox2.Text + '/' + "false" + '/' + textBox3.Text + '/' + textBox4.Text);
                    sw.Flush();
                    sw.Close();
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
