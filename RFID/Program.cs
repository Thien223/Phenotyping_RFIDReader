using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Cores;
using RFIDReaderAPI.Models;

namespace RFID
{
    public class Program : RFIDReaderAPI.Interface.IAsynchronousMessage
    {
        //static void Main(string[] args)
        //{
        //    // RFIDReaderAPI.RFIDReader.CreateSerialConn("COM1:115200",new Program());
        //    // use serial port to connect RFID reader
        //    if (RFIDReaderAPI.RFIDReader.CreateTcpConn("192.168.0.100:9090", new Program()))
        //    // use TCP to connect RFID reader
        //    {

        //        RFIDReaderAPI.RFIDReader._Tag6C.GetEPC("192.168.0.100:9090", eAntennaNo._1 | eAntennaNo._2 |
        //        eAntennaNo._3 | eAntennaNo._4, eReadType.Inventory);
        //        // send reading EPC instruction to the reader using Ant1+ Ant2+Ant3+Ant4 at the same time
        //    }
        //    else
        //    {
        //    }
        //    Console.ReadKey();
        //    RFIDReaderAPI.RFIDReader._RFIDConfig.Stop("192.168.0.100:9090");//send stop instruction
        //    RFIDReaderAPI.RFIDReader.CloseConn("192.168.0.100:9090"); // close connection
        //}
        #region interface implement

        public List<DataDTO> ReceivedData = new List<DataDTO>();
        public void WriteDebugMsg(string msg)
        { }
        public void WriteLog(string msg)
        { }
        public void PortConnecting(string connID)
        { }
        public void PortClosing(string connID)
        { }

        public void OutPutTags(Tag_Model tag_Model)
        {
            if (tag_Model == null || tag_Model.Result != 0x00) return;
            var row = new DataDTO
            {
                ReaderName = tag_Model.ReaderName,
                TagType = tag_Model.TagType,
                EPC = tag_Model.EPC,
                TID = tag_Model.TID,
                TotalCount = tag_Model.TotalCount,
                ANT1_COUNT = tag_Model.ANT1_COUNT,
                ANT2_COUNT = tag_Model.ANT2_COUNT,
                ANT3_COUNT = tag_Model.ANT3_COUNT,
                ANT4_COUNT = tag_Model.ANT4_COUNT,
                ANT5_COUNT = tag_Model.ANT5_COUNT,
                ANT6_COUNT = tag_Model.ANT6_COUNT,
                ANT7_COUNT = tag_Model.ANT7_COUNT,
                ANT8_COUNT = tag_Model.ANT8_COUNT,
                ReadTime = DateTime.Now,
                Frequency = tag_Model.Frequency
            };
            if (ReceivedData.Count > 0)
            {
                var oldRow = ReceivedData.LastOrDefault(x => (x.TID == row.TID) || (x.EPC == row.EPC));

                if (oldRow != null)
                {
                    var idx = ReceivedData.IndexOf(oldRow);
                    switch (tag_Model.ANT_NUM)
                    {
                        case 1:
                            ReceivedData[idx].ANT1_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 2:
                            ReceivedData[idx].ANT2_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 3:
                            ReceivedData[idx].ANT3_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 4:
                            ReceivedData[idx].ANT4_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 5:
                            ReceivedData[idx].ANT5_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 6:
                            ReceivedData[idx].ANT6_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 7:
                            ReceivedData[idx].ANT7_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                        case 8:
                            ReceivedData[idx].ANT8_COUNT += 1;
                            ReceivedData[idx].ReadTime = DateTime.Now;
                            break;
                    }
                }
                else
                {
                    ReceivedData.Add(row);
                }
            }
            else
            {
                ReceivedData.Add(row);
            }

        }

        public List<DataDTO> OutPutTags_()
        {
            return ReceivedData;

        }

        // read operation finished callback function
        public void OutPutTagsOver()
        {
            Console.WriteLine("read operation finished");
        }

        public void GPIControlMsg(GPI_Model gpiModel)
        { }
        #endregion
    }
}
