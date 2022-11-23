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
    public partial class 관리자상품 : Form
    {
        상품 p = new 상품();
        public 관리자상품()
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
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //상품삭제
            if (MessageBox.Show(listView1.FocusedItem.Text + "를 삭제하시겠습니까?", "상품삭제",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = listView1.FocusedItem.Index;
                listView1.Items.RemoveAt(index);
                update();
            }
        }
        void update()
        {
            FileStream fs = new FileStream("C:/temp/things.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string s = listView1.Items[i].Text + "/"
                    + listView1.Items[i].SubItems[1].Text + "/"
                    + listView1.Items[i].SubItems[2].Text + "/"
                    + listView1.Items[i].SubItems[3].Text;
                sw.WriteLine(s);
            }
            sw.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //상품추가
            p.name = "추가";
            using (상품추가수정 fs = new 상품추가수정(p))
            {
                fs.ShowDialog();
                this.Hide();
                if (p.name.Equals("추가")) ;
                else
                {
                    listView1.BeginUpdate();
                    ListViewItem item;
                    item = new ListViewItem(p.name);
                    item.SubItems.Add(p.money + "");
                    item.SubItems.Add(p.weight);
                    item.SubItems.Add(p.number + "");
                    listView1.Items.Add(item);
                    listView1.EndUpdate();
                    update();
                }
                fs.Dispose();
            }
            this.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //상품수정
            int index = listView1.FocusedItem.Index;
            p.name = listView1.Items[index].SubItems[0].Text;
            p.money = int.Parse(listView1.Items[index].SubItems[1].Text);
            p.weight = listView1.Items[index].SubItems[2].Text;
            p.number = int.Parse(listView1.Items[index].SubItems[3].Text);
            using (상품추가수정 f = new 상품추가수정(p))
            {
                f.ShowDialog();
                this.Hide();
                listView1.Items[index].Text = p.name;
                listView1.Items[index].SubItems[1].Text = p.money + "";
                listView1.Items[index].SubItems[2].Text = p.weight;
                listView1.Items[index].SubItems[3].Text = p.number + "";
                update();
                f.Dispose();
            }
            this.Show();
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
                    listView1.Items[i].Selected = true;
            }
        }
        int findText()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Selected = false;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text.Equals(textBox1.Text))
                    return i;
            }
            return -1;
        }
    }
}
