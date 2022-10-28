using Prism.Commands;
using Prism.Mvvm;
using RFID.Cores;
using RFIDReaderAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RFID
{
    public delegate void WriteDebug(string msg);
    public delegate void FlushState();
    public delegate void TCPPortConn(String connID);

    public class MainWindowViewModel : BindableBase
    {


        public MainWindowViewModel()
        {
            int tags;
            Log = new Program();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (!IsConnected)
                    {
                        DisConnectGateway();
                        IsConnected = ConnectGateway();
                    }
                    else
                    {

                        if (!IsReading)
                        {
                            tags = Read6CTag_EPCTID_Anten01();

                        }
                        else
                        {
                            ReceivedData = new ObservableCollection<DataDTO>(Log.OutPutTags_());

                            //// todo: save the received data to database
                            ///     1: create a tomcat server that deploy API to work with database
                            ///     2: using API to save to database
                        }
                    }

                    ///// remove inactive tags
                    for (int i = 0; i < ReceivedData.Count; i++)
                    {
                        if ((DateTime.Now - ReceivedData[i].ReadTime).TotalSeconds > 30)
                        {
                            if (Application.Current != null)
                            {
                                Application.Current.Dispatcher.Invoke(delegate
                                {
                                    ReceivedData.RemoveAt(i);
                                });
                            }

                        }
                    }
                    Thread.Sleep(100);
                }

            });
        }
        #region properties

        public Program Log;


        private ObservableCollection<DataDTO> m_ReceivedData;
        public ObservableCollection<DataDTO> ReceivedData
        {
            get
            {
                if (m_ReceivedData == null)
                {
                    m_ReceivedData = new ObservableCollection<DataDTO>();
                }
                return m_ReceivedData;
            }
            set
            {
                m_ReceivedData = value;
                RaisePropertyChanged("ReceivedData");
            }
        }


        /// <summary>
        /// gateway ip
        /// </summary>
        private string m_GatewayIP = "192.168.0.100";
        public string GatewayIP
        {
            get
            {
                return m_GatewayIP;
            }
            set
            {
                m_GatewayIP = value;
                RaisePropertyChanged("GatewayIP");
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
                RaisePropertyChanged("GatewayPort");
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
                RaisePropertyChanged("IsConnected");
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
                RaisePropertyChanged("IsReading");
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
            var connectString = $@"{GatewayIP}:{GatewayPort}";
            var ret = RFIDReaderAPI.RFIDReader.CreateTcpConn(connectString, Log);
            return ret;
        }

        public void DisConnectGateway()
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    if (ReceivedData != null)
                    {
                        ReceivedData.Clear();
                    }
                });
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
            var tag6c = RFIDReaderAPI.RFIDReader._Tag6C.GetEPC_TID(connectString, eAntennaNo._1 | eAntennaNo._2, readType);
            IsReading = true;
            return tag6c;
            //RFIDReaderAPI.RFIDReader._Tag6C.GetEPC(ConnID:connectString, antNum: antenNo, readType: readType, matchType: eMatchCode.EPC);
        }

        #endregion

    }
}
