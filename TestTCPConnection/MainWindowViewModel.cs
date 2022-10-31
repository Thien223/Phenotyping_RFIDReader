using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using RFID.Cores;
using RFIDReaderAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            Log = new Program();


            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    DateTime lastHeartBeatTime = DateTime.Now;
                    if (Application.Current != null)
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            AddOrUpdate();
                        });
                    }
                    if (me == null)
                    {
                        CreateClient();
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }
                    CheckRead();

                    if ((DateTime.Now - lastHeartBeatTime).TotalSeconds > 60 && me != null)
                    {
                        lastHeartBeatTime = DateTime.Now;
                        var sent = SendHeartBeat(me);
                        if (!sent)
                        {
                            CloseClient();
                        }
                    } // end if
                    
                    System.Threading.Thread.Sleep(10);
                }
            });
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        if (Application.Current != null)
            //        {
            //            Application.Current.Dispatcher.Invoke(delegate
            //            {
            //                Update();
            //                ReceivedData = result;

            //            });
            //        }
            //        ///// remove inactive tags
            //for (int i = 0; i < ReceivedData.Count; i++)
            //{
            //    if ((DateTime.Now - ReceivedData[i].ReadTime).TotalSeconds > 10)
            //    {
            //        ReceivedData.RemoveAt(i);
            //    }
            //}
            //        System.Threading.Thread.Sleep(30);
            //    }
            //});
        }
        #region properties

        TcpClient me = new TcpClient();
        private string m_ServerIP = "127.0.0.1";
        public string ServerIP
        {
            get { return m_ServerIP; }
            set { m_ServerIP = value; RaisePropertyChanged("ServerIP"); }
        }

        private int m_ServerPort= 3333;
        public int ServerPort
        {
            get { return m_ServerPort; }
            set { m_ServerPort = value; RaisePropertyChanged("ServerPort"); }
        }


        public Program Log;
        private string m_Data="No Data.."; 
        public string Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
                RaisePropertyChanged("Data");
            }
        }
        

        public int SendHeartBeatCount { get; set; }

        
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
                    CreateClient(); 
                });
            }
        }
        #endregion



        #region Methods


        void TimerTick(object state)
        {
            var who = state as string;
        }
        private void AddOrUpdate()
        {
            if (!(Data == null || Data.Length < 1))
            {
                //Console.WriteLine(Data);
                //DataDTO row = new DataDTO();
                //try
                //{
                //    var sec_json = JObject.Parse(Data);
                //    row = JsonConvert.DeserializeObject<DataDTO>(sec_json.ToString());
                //}

                //catch
                //{
                //    Console.WriteLine($"Error parsing: {Data}");
                //    return ;
                //}

                //if (ReceivedData.Count > 0)
                //{
                //    var oldRow = ReceivedData.LastOrDefault(x => (x.TID == row.TID) || (x.EPC == row.EPC));

                //    if (oldRow != null)
                //    {
                //        var idx = ReceivedData.IndexOf(oldRow);

                //        ReceivedData.RemoveAt(idx);
                //        ReceivedData.Insert(idx, row);
                //    }
                //    else
                //    {
                //        ReceivedData.Insert(0, row);
                //    }
                //}
                //else
                //{
                //    ReceivedData.Insert(0, row);
                //}

                //if (ReceivedData.Count > 0)
                //{
                //    var oldRow = ReceivedData.LastOrDefault(x => (x.TID == row.TID) || (x.EPC == row.EPC));

                //    if (oldRow != null)
                //    {
                //        var idx = ReceivedData.IndexOf(oldRow);
                //        ReceivedData[idx].ReaderName = row.ReaderName;
                //        ReceivedData[idx].TagType = row.TagType;
                //        ReceivedData[idx].EPC = row.EPC;
                //        ReceivedData[idx].TID = row.TID;
                //        ReceivedData[idx].ANT_IDX = row.ANT_IDX;
                //        ReceivedData[idx].ReadTime = row.ReadTime;

                //        switch (row.ANT_IDX)
                //        {
                //            case 1:
                //                ReceivedData[idx].ANT1_COUNT += 1;
                //                break;
                //            case 2:
                //                ReceivedData[idx].ANT2_COUNT += 1;
                //                break;
                //            case 3:
                //                ReceivedData[idx].ANT3_COUNT += 1;
                //                break;
                //            case 4:
                //                ReceivedData[idx].ANT4_COUNT += 1;
                //                break;
                //            case 5:
                //                ReceivedData[idx].ANT5_COUNT += 1;
                //                break;
                //            case 6:
                //                ReceivedData[idx].ANT6_COUNT += 1;
                //                break;
                //            case 7:
                //                ReceivedData[idx].ANT7_COUNT += 1;
                //                break;
                //            case 8:
                //                ReceivedData[idx].ANT8_COUNT += 1;
                //                break;
                //        }
                //    }
                //    else
                //    {
                //        ReceivedData.Add(row);
                //    }
                //}
                ///// or add new one
                //else
                //{
                //    ReceivedData.Add(row);
                //}///end iff
            }
        }

        
        /// <summary>
        /// read bytes from tcp stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private byte[] ReadBytes(NetworkStream stream, int len)
        {
            try
            {
                byte[] buffer = new byte[len];
                int sum = 0;

                int cnt = stream.Read(buffer, sum, len - sum);
                if (cnt <= 0)
                {
                    return null; ;
                }
                else
                {
                    return buffer;
                }
                //while (len > sum)
                //{
                //    int cnt = stream.Read(buffer, sum, len - sum);
                //    if (cnt <= 0)
                //    {
                //        break;
                //    }
                //    else
                //    {
                //        sum += cnt;
                //    }
                //} // end while
                //return buffer;
            }
            catch
            {
                return null;
            }
        }
        private void CheckRead()
        {
            if (me.Client.Poll(1 * 500 * 1000, SelectMode.SelectRead))
            {
                byte[] stream = ReadBytes(me.GetStream(), 400);

                if (stream == null)
                {
                    CloseClient();
                }
                else
                {
                    int len = stream.Length;
                    for (int i = stream.Length - 1; i > 0; i--)
                    {
                        if (stream[i] == 0)
                        {
                            len--;
                        }
                    }
                    //var newStream = new byte[len];
                    Array.Resize(ref stream, len);

                    Data = Encoding.ASCII.GetString(stream);
                }
                Task.Delay(50);
            } // end if
        }


        /// <summary>
        /// wait for a while
        /// </summary>
        /// <param name="MS"></param>
        /// <returns></returns>
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        /// <summary>
        /// keep in touch with TCP server
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private bool SendHeartBeat(TcpClient client)
        {
            try
            {
                byte[] stream = new byte[12];
                int offset = 0;
                offset = sam.ArrayHelper2.Concat(ref stream, offset, 1);

                client.GetStream().Write(stream, 0, stream.Length);
                Console.WriteLine($"Heartbeat sent....");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error {ex.Message}\n{ex.StackTrace}....");
                return false;
            }
        }


        private void CreateClient()
        {
            try
            {
                me = new TcpClient();
                me.Connect(ServerIP, ServerPort);
                SendHeartBeatCount = 1;
                IsConnected = true;
                Console.WriteLine($"Connected to {ServerIP}:{ServerPort}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not connect to {ServerIP}:{ServerPort}");
                Console.WriteLine($"error: {ex.Message}\n{ex.StackTrace}....");
                IsConnected = false;
                CloseClient();
            }
        }
        private void CloseClient()
        {
            if (me != null)
            {
                me.Close();
                me = null;
            }
        }


        #endregion

    }


    /// <summary>
    /// writer for logging
    /// </summary>
    public class TextBoxOutputter : TextWriter
    {
        TextBox textBox = null;

        public TextBoxOutputter(TextBox output)
        {
            textBox = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(value.ToString());
            }));
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
