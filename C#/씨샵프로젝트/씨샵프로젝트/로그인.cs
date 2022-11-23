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
    public partial class 로그인 : Form
    {
        person p = new person();
        public 로그인()
        {
            InitializeComponent();
        }
        //파일처리로 읽어오는 로그인. 관리자 or 회원 정보 일치시 true 일치하지 않을시 false
        bool loginRun()
        {
            p.Id = textBox1.Text;
            p.Pw = textBox2.Text;

            FileStream fs = File.OpenRead("C:/temp/user.txt");
            StreamReader r = new StreamReader(fs, System.Text.Encoding.Default);
            r.BaseStream.Seek(0, SeekOrigin.Begin);
            while (true) {
                string s = r.ReadLine();
                string[] sr = s.Split('/');
                if (p.Id.Equals(sr[0]))
                {
                    if (p.Pw.Equals(sr[1]))
                    {
                        if (sr[2].Equals("true"))
                        {
                            p.login = true;
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        return true;
                    }
                    MessageBox.Show("잘못된 유저정보 입니다.", "확인");
                    return false;
                }
                else if (r.Peek() == -1)
                {
                    return false;
                }
            }
            r.Close();
            fs.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //회원 혹은 관리자 로그인
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("아이디를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("비밀번호를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }    
            }
            else if (loginRun())
            {
                //관리자임
                if (p.login)
                {
                    this.Hide();
                    관리자메뉴 f = new 관리자메뉴(p);
                    f.ShowDialog();
                    this.Show();
                    p.login = false;
                }
                //회원임
                else
                {
                    this.Hide();
                    소비자메뉴 f = new 소비자메뉴(p);
                    f.ShowDialog();
                    this.Show();
                }
            }
            //없는 유저
            else
            {
                MessageBox.Show("일치하는 유저정보가 없습니다.", "확인");
            }
        }
        //회원가입
        private void button2_Click(object sender, EventArgs e)
        {
            회원가입 addUser = new 회원가입();
            addUser.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //정보찾기
        }
    }
}
