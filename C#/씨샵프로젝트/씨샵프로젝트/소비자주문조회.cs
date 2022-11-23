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
    public partial class 소비자주문조회 : Form
    {
        int money;
        public 소비자주문조회()
        {
            InitializeComponent();
            FileStream fs = new FileStream("C:/temp/" + 소비자메뉴.data.Id + ".txt", FileMode.OpenOrCreate);
            StreamReader rd = new StreamReader(fs, System.Text.Encoding.Default);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            while (true)
            {
                if (rd.Peek() == -1)
                {
                    break;
                }
                string str = rd.ReadLine();
                string[] data = str.Split('/');
                listBox1.Items.Add(data[0]);
                if (data[1].Equals("True"))
                {
                    str = rd.ReadLine();
                }
                if (data[3].Equals("True"))
                {
                    str = rd.ReadLine();
                }
            }
            rd.Close();
            fs.Close();
        }
        void input()
        {
            money = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            FileStream fs = new FileStream("C:/temp/" + 소비자메뉴.data.Id + ".txt", FileMode.OpenOrCreate);
            StreamReader rd = new StreamReader(fs, System.Text.Encoding.Default);
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            while (true)
            {
                if (rd.Peek() == -1)
                {
                    break;
                }
                string str = rd.ReadLine();
                string[] data = str.Split('/');

                if(data[0].Equals(listBox1.SelectedItem))
                {
                    if (data[1].Equals("True"))
                    {
                        str = rd.ReadLine();
                        if (!data[2].Equals("0"))
                        {
                            money += int.Parse(data[2]);
                            string[] s = str.Split('/');
                            for(int i = 0; i < s.Length; i++)
                            {
                                textBox2.Text += s[i] + "개"+ Environment.NewLine;
                            }
                        }                      
                    }
                    if (data[3].Equals("True"))
                    {
                        str = rd.ReadLine();
                        if (!data[4].Equals("0"))
                        {                           
                            money += int.Parse(data[4]);
                            string[] s = str.Split('/');
                            for (int i = 0; i < s.Length; i++)
                            {
                                textBox2.Text += s[i] + "개"+ Environment.NewLine;
                            }
                        }
                    }
                    break;
                }
                else
                {
                    if (data[1].Equals("True"))
                    {
                        str = rd.ReadLine();
                    }
                    if (data[3].Equals("True"))
                    {
                        str = rd.ReadLine();
                    }
                }
                
            }
            textBox1.Text = money + "원";
            rd.Close();
            fs.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            input();
        }
    }
}
