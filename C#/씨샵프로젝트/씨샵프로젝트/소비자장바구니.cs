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
    public partial class 소비자장바구니 : Form
    {
        int tmoney = 0;
        int rmoney = 0;
        public 소비자장바구니()
        {
            InitializeComponent();
            inputData();          
        }
        void inputData()
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < 상품리스트.list.Count; i++)
                {
                    listView2.BeginUpdate();
                    ListViewItem item;
                    //레시피 이름, 수량 추가
                    item = new ListViewItem(상품리스트.list[i].name);
                    item.SubItems.Add(Convert.ToString(상품리스트.list[i].number));
                    tmoney += 상품리스트.list[i].money * 상품리스트.list[i].number;
                    listView2.Items.Add(item);
                    listView2.EndUpdate();
                }
                label4.Text = tmoney + "원";
            }
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < 레시피리스트.list.Count; i++)
                {
                    listView1.BeginUpdate();
                    ListViewItem item;
                    item = new ListViewItem(레시피리스트.list[i].name);
                    item.SubItems.Add(레시피리스트.list[i].상품들());
                    item.SubItems.Add(Convert.ToString(레시피리스트.list[i].num));
                    listView1.Items.Add(item);
                    listView1.EndUpdate();
                    rmoney += 레시피리스트.list[i].money;
                }
                label2.Text = rmoney + "원";
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("구매하시겠습니까?\n 확인을 누르시면 결제가됩니다.",
                "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //파일에 저장
                FileStream fs = new FileStream("C:/temp/"+소비자메뉴.data.Id+".txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString("yyyy년MM월dd일 HH:mm:ss") +"/"+checkBox1.Checked
                    +"/"+rmoney + "/" + checkBox2.Checked  + "/"+tmoney);

                //리스트목록 삭제
                if (checkBox1.Checked == true)
                {
                    string str = "";
                    for(int i = 0; i < 레시피리스트.list.Count; i++)
                    {
                        str += 레시피리스트.list[i].name + " " + 레시피리스트.list[i].num;
                        if (i < 레시피리스트.list.Count - 1)
                        {
                            str += "/";
                        }
                        FileStream data = File.OpenRead("C:/temp/things.txt");
                        StreamReader rd = new StreamReader(data, System.Text.Encoding.Default);
                        FileStream change = File.OpenWrite("C:/temp/change.txt");
                        StreamWriter cw = new StreamWriter(change, System.Text.Encoding.Default);
                        rd.BaseStream.Seek(0, SeekOrigin.Begin);
                        while (true)
                        {
                            if (rd.Peek() == -1)
                            {
                                break;
                            }
                            string d = rd.ReadLine();
                            string[] sr = d.Split('/');
                            string[] things = 레시피리스트.list[i].상품들().Split(',');
                 
                            for (int j = 0; j < things.Length; j++)
                            {
                                if (sr[0].Equals(things[j]))
                                {
                                    sr[3] = int.Parse(sr[3]) - 레시피리스트.list[i].num+"";
                                }                         
                            }
                            cw.WriteLine(sr[0] + "/" + sr[1] + "/" + sr[2] + "/" + sr[3]);
                        }
                        rd.Close();
                        cw.Close();
                        File.Delete("C:/temp/things.txt");
                        File.Move("C:/temp/change.txt", "C:/temp/things.txt");
                    }
                   
                    sw.WriteLine(str);
                    소비자메뉴.rlist.remove();
                    listView1.Clear();
                }              
                if (checkBox2.Checked == true)
                {
                    string str = "";
                    for (int i = 0; i < 상품리스트.list.Count; i++)
                    {
                        str += 상품리스트.list[i].name + " " + 상품리스트.list[i].number;
                        if (i < 상품리스트.list.Count - 1)
                        {
                            str += "/";
                        }
                        FileStream data = File.OpenRead("C:/temp/things.txt");
                        StreamReader rd = new StreamReader(data, System.Text.Encoding.Default);
                        FileStream change = File.OpenWrite("C:/temp/change.txt");
                        StreamWriter cw = new StreamWriter(change, System.Text.Encoding.Default);
                        rd.BaseStream.Seek(0, SeekOrigin.Begin);
                        while (true)
                        {
                            if (rd.Peek() == -1)
                            {
                                break;
                            }
                            string d = rd.ReadLine();
                            string[] sr = d.Split('/');

                            if (sr[0].Equals(상품리스트.list[i].name))
                            {
                                cw.WriteLine(sr[0] + "/" + sr[1] + "/" + sr[2] + "/" + (int.Parse(sr[3]) - 상품리스트.list[i].number));
                            }
                            else
                            {
                                cw.WriteLine(d);
                            }
                        }
                        rd.Close();
                        cw.Close();
                        File.Delete("C:/temp/things.txt");
                        File.Move("C:/temp/change.txt", "C:/temp/things.txt");
                    }
                   
                    sw.WriteLine(str);
                    소비자메뉴.tlist.remove();
                    listView2.Clear();
                }              
                inputData();
                checkBox1.Checked = true;
                checkBox2.Checked = true;

                sw.Flush();
                sw.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
