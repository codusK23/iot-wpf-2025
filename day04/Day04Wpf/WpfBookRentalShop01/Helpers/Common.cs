using MahApps.Metro.Controls.Dialogs;
using NLog;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBookRentalShop01.Helpers
{
    /// <summary>
    /// 프로젝트 내에서 같이 쓸 수 있는 공통클래스
    /// </summary>
    internal class Common
    {
        // NLog 인스턴스
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        
        // DB연결 문자열을 한 군데 저장
        public static readonly string CONNSTR = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";

        // MahApps.Metro 다이얼로그 코디네이터
        public static IDialogCoordinator DIALOGCOORDINATOR;
    }
}
