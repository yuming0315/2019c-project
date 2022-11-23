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
    public partial class 관리자레시피 : Form
    {
        레시피이름넘겨주기 name;
        레시피 r = new 레시피("없음");
        public 관리자레시피()
        {
            InitializeComponent();
            //레시피이름,상품들,이미지파일경로 순서
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
        }
        void inputData()
        {
            name = new 레시피이름넘겨주기(listView1.Items.Count);
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                name[i] = listView1.Items[i].Text;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            inputData();
            레시피추가 f = new 레시피추가(name,r);
            f.ShowDialog();
            if (r.name.Equals("없음")) ;
            else
            {
                listView1.BeginUpdate();
                ListViewItem item;
                item = new ListViewItem(r.name);
                item.SubItems.Add(r.상품들());
                item.SubItems.Add(r.image);
                listView1.Items.Add(item);
                listView1.EndUpdate();
                r = new 레시피("없음");
                saveData();
            }
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(listView1.FocusedItem.Text+"를 삭제하시겠습니까?","레시피삭제",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                    int index = listView1.FocusedItem.Index;
                    listView1.Items.RemoveAt(index);
                    saveData();
            }
        }
        void saveData()
        {
            FileStream fs = new FileStream("C:/temp/recipe.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string s = listView1.Items[i].Text + "/"
                    + listView1.Items[i].SubItems[1].Text + "/" + listView1.Items[i].SubItems[2].Text;
                sw.WriteLine(s);
            }
            sw.Close();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
                this.Close();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Color c = Color.FromArgb(255, 255, 255);
            g.FillRectangle(new SolidBrush(c), panel1.ClientRectangle);
            Image i = Image.FromFile(listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text);
            g.DrawImage(i, 0, 0);
        }
    }
}
