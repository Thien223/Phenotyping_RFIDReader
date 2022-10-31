using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<DataDTO>ReceivedData = new ObservableCollection<DataDTO>();
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
            byte[] raw = new byte[tag_Model.EPC.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(tag_Model.EPC.Substring(i * 2, 2), 16);
            }

            var row = new DataDTO
            {
                ReaderName = tag_Model.ReaderName,
                TagType = tag_Model.TagType,
                EPC = Encoding.ASCII.GetString(raw),
                TID = tag_Model.TID,
                ANT_IDX = tag_Model.ANT_NUM,
                ReadTime = DateTime.Now
            };


            //// check and update existant row
            if (ReceivedData.Count > 0)
            {
                var oldRow = ReceivedData.LastOrDefault(x => (x.TID == row.TID) || (x.EPC == row.EPC));

                if (oldRow != null)
                {
                    var idx = ReceivedData.IndexOf(oldRow);
                    ReceivedData[idx].ReadTime = DateTime.Now;
                    ReceivedData[idx].ANT_IDX = row.ANT_IDX;
                    switch (tag_Model.ANT_NUM)
                    {
                        case 1:
                            ReceivedData[idx].ANT1_COUNT += 1;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 2:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            ReceivedData[idx].ANT2_COUNT += 1;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 3:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            ReceivedData[idx].ANT3_COUNT += 1;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 4:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            ReceivedData[idx].ANT4_COUNT += 1;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 5:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            ReceivedData[idx].ANT5_COUNT += 1;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 6:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            ReceivedData[idx].ANT6_COUNT += 1;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 7:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            ReceivedData[idx].ANT7_COUNT += 1;
                            //ReceivedData[idx].ANT8_COUNT = false;
                            break;
                        case 8:
                            //ReceivedData[idx].ANT1_COUNT = false;
                            //ReceivedData[idx].ANT2_COUNT = false;
                            //ReceivedData[idx].ANT3_COUNT = false;
                            //ReceivedData[idx].ANT4_COUNT = false;
                            //ReceivedData[idx].ANT5_COUNT = false;
                            //ReceivedData[idx].ANT6_COUNT = false;
                            //ReceivedData[idx].ANT7_COUNT = false;
                            ReceivedData[idx].ANT8_COUNT += 1;
                            break;
                    }
                }
                else
                {
                    ReceivedData.Add(row);
                }
            }
            /// or add new one
            else
            {
                ReceivedData.Add(row);
            }///end iff

        }

        public ObservableCollection<DataDTO> OutPutTags_()
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
