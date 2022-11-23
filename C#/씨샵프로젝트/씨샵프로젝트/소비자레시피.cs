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
    public partial class 소비자레시피 : Form
    {
        int money;
        public static int num;
        public 소비자레시피()
        {
            InitializeComponent();
            FileStream fs = File.OpenRead("C:/temp/recipe.txt");
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
                listView1.Items.Add(item);
                listView1.EndUpdate();

            }
            r.Close();
            fs.Close();

            for (int i = 0; i < 레시피리스트.list.Count; i++)
            {
                listView2.BeginUpdate();
                ListViewItem item;
                //레시피 이름, 수량 추가
                item = new ListViewItem(레시피리스트.list[i].name);
                item.SubItems.Add(Convert.ToString(레시피리스트.list[i].num));
                listView2.Items.Add(item);
                listView2.EndUpdate();
                money += 레시피리스트.list[i].money * 레시피리스트.list[i].num;
            }
            label3.Text = money + "원";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("검색할 레시피 이름을 입력해 주세요.");
            }
            else
            {
                int i = findText();
                if (i == -1)
                {
                    MessageBox.Show("검색한 레시피가 없습니다.");
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

                레시피장바구니 f = new 레시피장바구니(s);
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
                    레시피 r = new 레시피(listView1.Items[listView1.FocusedItem.Index].Text);
                    r.num = num;
                    string str = listView1.FocusedItem.SubItems[1].Text;
                    string[] things = str.Split(',');
                    r.setIndex(things.Length);
                    for(int i = 0; i < things.Length; i++)
                    {
                        r[i].name = things[i];
                    }
                    소비자메뉴.rlist += r;

                    FileStream fs = File.OpenRead("C:/temp/things.txt");
                    StreamReader rs = new StreamReader(fs, System.Text.Encoding.Default);
                    rs.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (true)
                    {
                        if (rs.Peek() == -1)
                        {
                            break;
                        }
                        string data = rs.ReadLine();
                        string[] sr = data.Split('/');

                        for (int j = 0; j < things.Length; j++)
                        {
                            if (sr[0].Equals(things[j]))
                            {
                                r.money += int.Parse(sr[1]) * r.num;
                            }
                        }
                    }
                    money += r.money;
                    label3.Text = money+"원";
                    rs.Close();
                    fs.Close();
                }
            }
            else
            {
                MessageBox.Show("이미 추가된 상품입니다.\n삭제 후 수정해주세요.");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show(listView2.FocusedItem.Text + "를 삭제하시겠습니까?", "",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                for (int i = 0; i < 레시피리스트.list.Count; i++)
                {
                    if (레시피리스트.list[i].name.Equals(listView2.FocusedItem.Text))
                    {
                        money -= 레시피리스트.list[i].money;
                        break;
                    }
                }
                소비자메뉴.rlist -= listView2.FocusedItem.Text;
                    int index = listView2.FocusedItem.Index;
                    listView2.Items.RemoveAt(index);
                }
                label3.Text = money + "원";
        }
       
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Color c = Color.FromArgb(255, 255, 255);
            g.FillRectangle(new SolidBrush(c), panel1.ClientRectangle);
            Image i = Image.FromFile(listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text);
            g.DrawImage(i, 0, 0);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
