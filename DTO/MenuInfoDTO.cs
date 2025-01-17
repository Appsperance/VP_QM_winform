using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public static class MenuInfoDTO
    {
        private static string _lineId = "vi01";
        private static string _partId;
        private static string _lotId;
        private static DateTime _start;
        private static DateTime _end;

        // 이벤트 선언
        public static event Action<string> LineIdChanged;
        public static event Action<string> PartIdChanged;
        public static event Action<string> LotIdChanged;
        public static event Action<DateTime> StartChanged;
        public static event Action<DateTime> EndChanged;

        public static string LineId
        {
            get => _lineId;
            set
            {
                _lineId = value;
                LineIdChanged?.Invoke(value); // 이벤트 발생
            }
        }

        public static string PartId
        {
            get => _partId;
            set
            {
                _partId = value;
                PartIdChanged?.Invoke(value); // 이벤트 발생
            }
        }

        public static string LotId
        {
            get => _lotId;
            set
            {
                _lotId = value;
                LotIdChanged?.Invoke(value); // 이벤트 발생
            }
        }

        public static DateTime Start
        {
            get => _start;
            set
            {
                _start = value;
                StartChanged?.Invoke(value); // 이벤트 발생
            }
        }

        public static DateTime End
        {
            get => _end;
            set
            {
                _end = value;
                EndChanged?.Invoke(value); // 이벤트 발생
            }
        }

    }
}
