using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 씨샵프로젝트
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 로그인());

            //Form2 f2 = new Form2();
            //Application.Run(f2);
            //Form3 f3 = new Form3();
            //Application.Run(f3);
        }
    }
}
