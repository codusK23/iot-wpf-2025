using MahApps.Metro.Controls.Dialogs;
using NLog;

namespace MovieFinder2025.Helpers
{
    public class Common
    {
        // NLog 인스턴스
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        // DB연결문자열을 한군데 저장
        public static readonly string CONNSTR = "Server=localhost;Database=moviefinder;Uid=root;Pwd=12345;Charset=utf8;";

        // MahApps.Metro 다이얼로그
        public static IDialogCoordinator DIALOGCOORDINATOR;
    }
}
