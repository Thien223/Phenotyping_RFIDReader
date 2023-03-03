using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Cores
{
    public class DataDTO
    {
        public string ReaderName { get; set; }
        public string TagType { get; set; }
        public string EPC { get; set; }
        public string TID { get; set; }
        public long TotalCount { get; set; }
        public long ANT1_COUNT { get; set; }
        public long ANT2_COUNT { get; set; }
        public long ANT3_COUNT { get; set; }
        public long ANT4_COUNT { get; set; }
        public long ANT5_COUNT { get; set; }
        public long ANT6_COUNT { get; set; }
        public long ANT7_COUNT { get; set; }
        public long ANT8_COUNT { get; set; }
        public DateTime ReadTime { get; set; }

        public int CountDown = 1000;
        public uint Frequency=0;
    }
}
