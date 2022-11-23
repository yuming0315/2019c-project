using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 씨샵프로젝트
{
    public class 레시피리스트
    {
        public static List<레시피> list = new List<레시피>();
        public void remove()
        {
            list.Clear();
        }
        public static 레시피리스트 operator+(레시피리스트 l, 레시피 r)
        {
            list.Add(r);
            return l;
        }
        public static 레시피리스트 operator- (레시피리스트 l, string name)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].name.Equals(name))
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            return l;
        }
    }
    public class 레시피:상품
    {
        public string name;
        public 상품[] things;
        public string image;
        public int num;
        public int money;
        public 상품 this[int i] {
            get {
                return things[i];
            }
            set {
                things[i] = value;
            }
        }
        public string 상품들()
        {
            string s="";
            for(int i = 0; i < things.Length; i++)
            {
                s += things[i].name;
                if (i < things.Length - 1)
                    s += ",";
            }
            return s;
        }
        public 레시피()
        {

        }
        public 레시피(string name)
        {
            this.name = name;
        }
        public void setIndex(int i)
        {
            things = new 상품[i];
            for(int j = 0; j < i; j++)
            {
                things[j] = new 상품();
            }
        }
        public 레시피(string name, int i)
        {
            this.name = name;
            this.things = new 상품[i];
            for(int j = 0; j < things.Length; i++)
            {
                things[j] = new 상품();
            }
        }
       
    }
}
