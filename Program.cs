using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_QM_winform.Helper;
using VP_QM_winform.Service;
using VP_QM_winform.VO;

namespace VP_QM_winform
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Dapper Snake Case Mapper 등록
            DapperExtensions.RegisterSnakeCaseMappers(Assembly.GetExecutingAssembly(), "VP_QM_winform.VO");
            //멀티쓰레드 상태관리 
            ProcessState.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
