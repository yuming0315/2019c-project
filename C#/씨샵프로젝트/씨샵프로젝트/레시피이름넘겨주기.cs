using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 씨샵프로젝트
{
    public class 레시피이름넘겨주기
    {
        public string[] name;
        public 레시피이름넘겨주기(int i)
        {
            name = new string[i];
        }
        public string this[int i] {
            get {
                return name[i];
            }
            set {
                name[i] = value;
            }
        } 
    }
}
