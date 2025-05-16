using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusanRestaurantApp.Models
{
    internal class BusanItem
    {
        /*
         UC_SEQ: 70
        MAIN_TITLE: "만드리곤드레밥"
        GUGUN_NM: "강서구"
        LAT: 35.177387
        LNG: 128.95245
        PLACE: "만드리곤드레밥"
        TITLE: "만드리곤드레밥"
        SUBTITLE: ""
        ADDR1: "강서구 공항앞길 85번길 13"
        ADDR2: ""
        CNTCT_TEL: "051-941-3669"
        HOMEPAGE_URL: ""
        USAGE_DAY_WEEK_AND_TIME: "10:00-20:00 (19:50 라스트오더)"
        RPRSNTV_MENU: "돌솥곤드레정식, 단호박오리훈제"
        MAIN_IMG_NORMAL: "https://www.visitbusan.net/uploadImgs/files/cntnts/20191209162810545_ttiel"
        MAIN_IMG_THUMB: "https://www.visitbusan.net/uploadImgs/files/cntnts/20191209162810545_thumbL"
        ITEMCNTNTS: "곤드레밥에는 일반적으로 건조 곤드레나물이 사용되는데, 이곳은 생 곤드레나물을 사용하여 돌솥밥을 만든다. 된장찌개와 함께 열 가지가 넘는 반찬이 제공되는 돌솥곤드레정식이 인기있다 "
         */

        public int Uc_Seq { get; set; }
        public string Main_Title { get; set; }
        public string Gugun_Nm { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Place { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Cntct_Tel { get; set; }
        public string Homepage_Url { get; set; }
        public string Usage_Day_Week_And_Time { get; set; }
        public string Rprsntv_Menu { get; set; }
        public string Main_Img_Normal { get; set; }
        public string Main_Img_Thumb { get; set; }
        public string ItemCntnts { get; set; }
    }
}
