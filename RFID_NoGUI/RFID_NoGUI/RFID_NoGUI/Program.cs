using System;
using System.Text;
using RFID.Cores;
using RFIDReaderAPI.Models;

namespace RFID_NoGUI
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

        public DataDTO ReceivedData = new DataDTO();
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

            Console.WriteLine($"tag_Model == null: {tag_Model == null}");
            Console.WriteLine($"tag_Model.Result: {tag_Model.Result}");
            Console.WriteLine($"tag_Model.ReaderName: {tag_Model.ReaderName}");
            Console.WriteLine($"tag_Model.EPC: {tag_Model.EPC}");
            if (tag_Model == null
                || tag_Model.Result != 0x00
                || tag_Model.ReaderName == null
                || tag_Model.EPC == null)
            {
                return;
            }
            byte[] raw = new byte[tag_Model.EPC.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(tag_Model.EPC.Substring(i * 2, 2), 16);
            }
            ReceivedData = new DataDTO
            {
                ReaderName = tag_Model.ReaderName,
                TagType = tag_Model.TagType,
                EPC = Encoding.ASCII.GetString(raw),
                TID = tag_Model.TID,
                ANT_IDX = tag_Model.ANT_NUM,
                ReadTime = DateTime.Now
            };

        }

        public DataDTO OutPutTags_()
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
