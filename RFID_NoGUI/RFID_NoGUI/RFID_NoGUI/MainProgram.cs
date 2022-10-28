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

        private List<DataDTO> m_ReceivedData;
        public List<DataDTO> ReceivedData
        {
            get
            {
                if (m_ReceivedData == null)
                {
                    m_ReceivedData = new List<DataDTO>();
                }
                return m_ReceivedData;
            }
            set
            {
                m_ReceivedData = value;
            }
        }


        /// <summary>
        /// gateway ip
        /// </summary>
        private string m_GatewayIP = "192.168.0.3";
        public string GatewayIP
        {
            get
            {
                return m_GatewayIP;
            }
            set
            {
                m_GatewayIP = value;
            }
        }


        /// <summary>
        /// gateway port
        /// </summary>
        /// 
        private string m_GatewayPort = "9090";
        public string GatewayPort
        {
            get
            {
                return m_GatewayPort;
            }
            set
            {
                m_GatewayPort = value;
            }
        }

        #endregion




        #region boolean properties

        /// <summary>
        /// Is connected to a gateway
        /// </summary>
        /// 
        private bool m_IsConnected = false;
        public bool IsConnected
        {
            get
            {
                return m_IsConnected;
            }
            set
            {
                m_IsConnected = value;
            }
        }

        /// <summary>
        /// Is reading data from gateway
        /// </summary>
        /// 
        private bool m_IsReading = false;
        public bool IsReading
        {
            get
            {
                return m_IsReading;
            }
            set
            {
                m_IsReading = value;
            }
        }

        #endregion



        #region Commands

        public ICommand ConnectCommand
        {
            get
            {
                return new DelegateCommand(delegate ()
                {
                    if (!IsConnected)
                    {
                        IsConnected = ConnectGateway();
                    }
                    else
                    {
                        DisConnectGateway();
                    }
                    //MessageBox.Show($"connect button clicked, IsConnected: {IsConnected}");
                });
            }
        }
        #endregion



        #region Methods
        public bool ConnectGateway()
        {
            try
            {
                var connectString = $@"{GatewayIP}:{GatewayPort}";
                var ret = RFIDReaderAPI.RFIDReader.CreateTcpConn(connectString, Log);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR when connecting gateway: {ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }

        public void DisConnectGateway()
        {
            if (ReceivedData != null)
            {
                ReceivedData.Clear();
            }
            var connectString = $@"{GatewayIP}:{GatewayPort}";
            try
            {
                if (IsReading)
                {
                    RFIDReaderAPI.RFIDReader._RFIDConfig.Stop(connectString);
                }
                RFIDReaderAPI.RFIDReader.CloseConn(connectString);
                IsReading = false;
                IsConnected = false;
            }
            catch (Exception e)
            {
                IsReading = false;
                IsConnected = false;
                Console.WriteLine($"Error when trying to close RFID gateway connection: {e.Message}");
            }
        }



        public int Read6CTag_EPCTID_Anten01()
        {
            var connectString = $@"{GatewayIP}:{GatewayPort}";
            var readType = eReadType.Inventory;
            var tag6c = RFIDReaderAPI.RFIDReader._Tag6C.GetEPC_TID(connectString, eAntennaNo._1 | eAntennaNo._2 | eAntennaNo._3 | eAntennaNo._4, readType);
            IsReading = true;
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
