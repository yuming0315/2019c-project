using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 씨샵프로젝트
{
    public class 상품리스트
    {
        public static List<상품> list = new List<상품>();
        public void remove()
        {
            list.Clear();
        }
        public static 상품리스트 operator +(상품리스트 l, 상품 r)
        {
            list.Add(r);
            return l;
        }
        public static 상품리스트 operator -(상품리스트 l, string name)
        {
            for (int i = 0; i < list.Count; i++)
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

    public class 상품
    {
        public string name {
            get; set;
        }
        public string weight {
            get;set;
        }
        public int money {
            get;set;
        }
        public int number {
            get;set;
        }
    }
}
