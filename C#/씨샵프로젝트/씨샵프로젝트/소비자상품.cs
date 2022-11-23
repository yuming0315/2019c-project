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
    public partial class 소비자상품 : Form
    {
        public static int num;
        int money = 0;
        public 소비자상품()
        {
            InitializeComponent();
            FileStream fs = File.OpenRead("C:/temp/things.txt");
            StreamReader r = new StreamReader(fs, System.Text.Encoding.Default);
            r.BaseStream.Seek(0, SeekOrigin.Begin);
            while (true)
            {
                if (r.Peek() == -1)
                {
                    break;
                }
                string s = r.ReadLine();
                string[] sr = s.Split('/');

                listView1.BeginUpdate();
                ListViewItem item;
                item = new ListViewItem(sr[0]);
                item.SubItems.Add(sr[1]);
                item.SubItems.Add(sr[2]);
                item.SubItems.Add(sr[3]);
                listView1.Items.Add(item);
                listView1.EndUpdate();

            }
            r.Close();
            fs.Close();

            for (int i = 0; i < 상품리스트.list.Count; i++)
            {
                listView2.BeginUpdate();
                ListViewItem item;
                //레시피 이름, 수량 추가
                item = new ListViewItem(상품리스트.list[i].name);
                item.SubItems.Add(Convert.ToString(상품리스트.list[i].number));
                money += 상품리스트.list[i].money*상품리스트.list[i].number;
                listView2.Items.Add(item);
                listView2.EndUpdate();
            }
            label3.Text = money + "원";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //검색하기
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("검색할 상품의 이름을 입력해 주세요.");
            }
            else
            {
                int i = findText();
                if (i == -1)
                {
                    MessageBox.Show("검색한 상품이 없습니다.");
                }
                else
                {
                    listView1.Items[i].Focused = true;
                    listView1.Items[i].Selected = true;
                }
            }
        }
        int findText()
        {
            int count = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text.Equals(textBox1.Text))
                    count = i;
                else
                    listView1.Items[i].Selected = false;
            }
            return count;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            //뒤로가깅           
            this.Close();          
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            bool count = true;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView1.Items[listView1.FocusedItem.Index].Text.Equals(listView2.Items[i].Text))
                {
                    count = false;
                }
            }
            if (count)
            {
                //추가 전용 폼
                num = 0;
                string s = listView1.Items[listView1.FocusedItem.Index].Text;

                상품장바구니 f = new 상품장바구니(s,int.Parse(listView1.Items[listView1.FocusedItem.Index].SubItems[3].Text));
                f.ShowDialog();

                if (num > 0)
                {
                    listView2.BeginUpdate();
                    ListViewItem item;
                    //레시피 이름, 수량 추가
                    item = new ListViewItem(s);
                    item.SubItems.Add(Convert.ToString(num));
                    listView2.Items.Add(item);
                    listView2.EndUpdate();

                    상품 r = new 상품();
                    r.name = listView1.Items[listView1.FocusedItem.Index].Text;
                    r.number = num;
                    r.money = int.Parse(listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text);
                    소비자메뉴.tlist += r;
                    money += r.money*r.number;
                    label3.Text = money + "원";
                }
            }
            else
            {
                MessageBox.Show("이미 추가된 상품입니다.\n삭제 후 수정해주세요.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(listView2.FocusedItem.Text + "를 삭제하시겠습니까?", "",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for(int i = 0; i < 상품리스트.list.Count; i++)
                {
                    if (상품리스트.list[i].name.Equals(listView2.FocusedItem.Text))
                    {
                        money -= 상품리스트.list[i].money * 상품리스트.list[i].number;
                        break;
                    }
                }
                label3.Text = money + "원";
                소비자메뉴.tlist -= listView2.FocusedItem.Text;
                int index = listView2.FocusedItem.Index;
                listView2.Items.RemoveAt(index);
            }
        }
        
    }
}
