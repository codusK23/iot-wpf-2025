using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBasicApp02.Models
{
    public class Book : INotifyPropertyChanged
    {
        public int Idx {  get; set; }
        public string Division { get; set; }
        public string DNames { get; set; }
        public string Names { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }

        // 위의 여덟개의 값이 기존상태에서 변경이 되면 발생하는 이벤트
        // 사용자가 클릭같은거로 발생하는 이벤트가 아님
        public event PropertyChangedEventHandler? PropertyChanged; 
    }
}
