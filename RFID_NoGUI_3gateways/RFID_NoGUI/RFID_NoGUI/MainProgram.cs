using System;
using System.Text;
using Prism.Commands;
using RFID.Cores;
using RFIDReaderAPI;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Windows.Input;
using System.Collections.Generic;

namespace RFID_NoGUI
{
    public class MainProgram
    {
        public MainProgram()
        {
            ReceivedData = new List<DataDTO>();
        }


        #region properties
        public Program Log;
        //public Socket listener;

        //private Socket knownClient;
        //private bool EnableServer = true;

        private List<DataDTO> ReceivedData;


        #endregion




        #region boolean properties

        /// <summary>
        /// Is connected to a gateway
        /// </summary>
        /// 
        public bool IsConnected_01 = false;
        public bool IsConnected_02 = false;
        public bool IsConnected_03 = false;

        /// <summary>
        /// Is reading data from gateway
        /// </summary>
        /// 
        public bool IsReading_01 = false;
        public bool IsReading_02 = false;
        public bool IsReading_03 = false;

        private string GatewayIP_01 = "192.168.100.47";
        private string GatewayIP_02 = "192.168.100.48";
        private string GatewayIP_03 = "192.168.100.49";

        private int GatewayPort_01 = 9090;
        private int GatewayPort_02 = 9090;
        private int GatewayPort_03 = 9090;
        #endregion



        #region Commands

        //public ICommand ConnectCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(delegate ()
        //        {
        //            var c1 = ConnectGateway_01();
        //            var c2 = ConnectGateway_02();
        //            var c3 = ConnectGateway_03();
        //            IsConnected = c1 || c2 || c3;
        //            //MessageBox.Show($"connect button clicked, IsConnected: {IsConnected}");
        //        });
        //    }
        //}
        #endregion



        #region Methods
        public bool ConnectGateway_01()
        {
            try
            {
                var connectString = $@"{GatewayIP_01}:{GatewayPort_01}";
                var ret = RFIDReaderAPI.RFIDReader.CreateTcpConn(connectString, Log);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR when connecting gateway: {ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }
        public bool ConnectGateway_02()
        {
            try
            {
                var connectString = $@"{GatewayIP_02}:{GatewayPort_02}";
                var ret = RFIDReaderAPI.RFIDReader.CreateTcpConn(connectString, Log);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR when connecting gateway: {ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }
        public bool ConnectGateway_03()
        {
            try
            {
                var connectString = $@"{GatewayIP_03}:{GatewayPort_03}";
                var ret = RFIDReaderAPI.RFIDReader.CreateTcpConn(connectString, Log);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR when connecting gateway: {ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }

        public void DisConnectGateway_01()
        {
            if (ReceivedData != null)
            {
                ReceivedData.Clear();
            }
            var connectString_01 = $@"{GatewayIP_01}:{GatewayPort_01}";
            try
            {
                if (IsReading_01)
                {
                    RFIDReaderAPI.RFIDReader._RFIDConfig.Stop(connectString_01);
                }
                RFIDReaderAPI.RFIDReader.CloseConn(connectString_01);
                IsReading_01 = false;
                IsConnected_01 = false;
            }
            catch (Exception e)
            {
                IsReading_01 = false;
                IsConnected_01 = false;
                Console.WriteLine($"Error when trying to close RFID gateway connection: {e.Message}");
            }
        }

        public void DisConnectGateway_02()
        {
            if (ReceivedData != null)
            {
                ReceivedData.Clear();
            }
            var connectString_02 = $@"{GatewayIP_02}:{GatewayPort_02}";
            try
            {
                if (IsReading_02)
                {
                    RFIDReaderAPI.RFIDReader._RFIDConfig.Stop(connectString_02);
                }
                RFIDReaderAPI.RFIDReader.CloseConn(connectString_02);
                IsReading_02 = false;
                IsConnected_02 = false;
            }
            catch (Exception e)
            {
                IsReading_02 = false;
                IsConnected_02 = false;
                Console.WriteLine($"Error when trying to close RFID gateway connection: {e.Message}");
            }
        }

        public void DisConnectGateway_03()
        {
            if (ReceivedData != null)
            {
                ReceivedData.Clear();
            }
            var connectString_03 = $@"{GatewayIP_03}:{GatewayPort_03}";
            try
            {
                if (IsReading_03)
                {
                    RFIDReaderAPI.RFIDReader._RFIDConfig.Stop(connectString_03);
                }
                RFIDReaderAPI.RFIDReader.CloseConn(connectString_03);
                IsReading_03 = false;
                IsConnected_03 = false;
            }
            catch (Exception e)
            {
                IsReading_03 = false;
                IsConnected_03 = false;
                Console.WriteLine($"Error when trying to close RFID gateway connection: {e.Message}");
            }
        }


        public int Read6CTag_EPCTID_01()
        {
            var connectString = $@"{GatewayIP_01}:{GatewayPort_01}";
            var readType = eReadType.Inventory;
            var tag6c = RFIDReaderAPI.RFIDReader._Tag6C.GetEPC_TID(connectString, eAntennaNo._1 | eAntennaNo._2 | eAntennaNo._3 | eAntennaNo._4, readType);
            IsReading_01 = true;
            return tag6c;
            //RFIDReaderAPI.RFIDReader._Tag6C.GetEPC(ConnID:connectString, antNum: antenNo, readType: readType, matchType: eMatchCode.EPC);
        }
        public int Read6CTag_EPCTID_02()
        {
            var connectString = $@"{GatewayIP_02}:{GatewayPort_02}";
            var readType = eReadType.Inventory;
            var tag6c = RFIDReaderAPI.RFIDReader._Tag6C.GetEPC_TID(connectString, eAntennaNo._1 | eAntennaNo._2 | eAntennaNo._3 | eAntennaNo._4, readType);
            IsReading_02 = true;
            return tag6c;
            //RFIDReaderAPI.RFIDReader._Tag6C.GetEPC(ConnID:connectString, antNum: antenNo, readType: readType, matchType: eMatchCode.EPC);
        }
        public int Read6CTag_EPCTID_03()
        {
            var connectString = $@"{GatewayIP_03}:{GatewayPort_03}";
            var readType = eReadType.Inventory;
            var tag6c = RFIDReaderAPI.RFIDReader._Tag6C.GetEPC_TID(connectString, eAntennaNo._1 | eAntennaNo._2 | eAntennaNo._3 | eAntennaNo._4, readType);
            IsReading_03 = true;
            return tag6c;
            //RFIDReaderAPI.RFIDReader._Tag6C.GetEPC(ConnID:connectString, antNum: antenNo, readType: readType, matchType: eMatchCode.EPC);
        }

        ///// <summary>
        /////  send message to TCP clients
        ///// </summary>
        ///// <param name="data"></param>
        //private void SendMessage(string data)
        //{


        //    byte[] message = Encoding.ASCII.GetBytes(data);
        //    try
        //    {
        //        Console.WriteLine($"*** Sending message *** ");
        //        knownClient.Send(message);
        //        //knownClient.Shutdown(SocketShutdown.Both);
        //        //knownClient.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"now: {e.Message}\n{e.StackTrace}");
        //        knownClient = null;
        //        return;
        //    }
        //}
        #endregion
    }
}
