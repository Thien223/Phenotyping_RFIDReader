using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace RFID_NoGUI
{
    public class Run
    {
        public static Socket listener;

        private static List<Socket> Clients;

        //private static RFID.Cores.DataDTO row = null;

        private static List<RFID.Cores.DataDTO> rows = new List<RFID.Cores.DataDTO>();

        /// <summary>
        ///  send message to TCP clients
        /// </summary>
        /// <param name="data"></param>
        private static void SendMessage(string data)
        {
            //Console.WriteLine($"*** Sending message *** ");
            byte[] message = Encoding.ASCII.GetBytes(data);
            for (int i = 0; i < Clients.Count; i++)
            {
                var client = Clients[i];
                if(client == null) continue;
                try
                {
                    client.Send(message);
                    Console.WriteLine($"*** {data} ***");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"now: {e.Message}\n{e.StackTrace}");
                    Clients.RemoveAt(i);
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            Clients = new List<Socket>();
            int interval = 17;
            var main = new MainProgram();
            int max = 1000;
            int port = 3394;
            int countdown_01 = 0;
            int countdown_02 = 0;
            int countdown_03 = 0;
            int countdown_04 = 0;
            int countdown_05 = 0;
            int countdown_06 = 0;
            int countdown_07 = 0;
            int countdown_08 = 0;
            int tags;
            main.Log = new Program();

            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint clients = new IPEndPoint(IPAddress.Any, port);
            listener.Bind(clients);
            listener.Listen(max);
            Task worker = Task.Run(() => AddClient());

            while (true)
            {

                //Console.WriteLine($"running..");

                if (!main.IsConnected_01)
                {
                    main.DisConnectGateway_01();
                    main.IsConnected_01 = main.ConnectGateway_01();
                }
                if (!main.IsConnected_02)
                {
                    main.DisConnectGateway_02();
                    main.IsConnected_02 = main.ConnectGateway_02();
                }
                if (!main.IsConnected_03)
                {
                    main.DisConnectGateway_03();
                    main.IsConnected_03 = main.ConnectGateway_03();
                }

                //Console.WriteLine($"main.IsConnected_01: {main.IsConnected_01}..");
                //Console.WriteLine($"main.IsConnected_02: {main.IsConnected_02}..");
                //Console.WriteLine($"main.IsConnected_03: {main.IsConnected_03}..");
                if (main.IsConnected_01|| main.IsConnected_02|| main.IsConnected_03)
                {
                    if (!main.IsReading_01)
                    {
                        tags = main.Read6CTag_EPCTID_01();
                    }
                    if (!main.IsReading_02)
                    {
                        tags = main.Read6CTag_EPCTID_02();
                    }
                    if (!main.IsReading_03)
                    {
                        tags = main.Read6CTag_EPCTID_03();
                    }
                    if (main.IsReading_01 || main.IsReading_02|| main.IsReading_03)
                    {
                        var r = main.Log.OutPutTags_();
                        var temp = rows.Where(x => x.ANT_IDX == r.ANT_IDX).FirstOrDefault();
                        if (temp == null)
                        {
                            rows.Add(r);
                        }
                        else
                        {
                            rows.Remove(temp);
                            rows.Add(r);
                        }
                        /// send message to TCP clients
                        
                        //Console.WriteLine($"*** {sam.JsonHelper.SerializeObject(row)} ***");
                        for(int i = 0; i < rows.Count; i++)
                        {
                            var row = rows[i];
                            var lastReadTime = (DateTime.Now - row.ReadTime).TotalSeconds;
                            if (lastReadTime > 2)
                            {
                                rows.RemoveAt(i);
                            }
                            try
                            {
                                //Console.WriteLine($"Clients.Count {Clients.Count}");
                                //Console.WriteLine($"Clients.Count {Clients.Count}");
                                //Console.WriteLine($"row  == null: {row == null}");
                                //Console.WriteLine($"row.EPC == null: {row.EPC == null}");
                                //Console.WriteLine($"lastReadTime: {lastReadTime}");
                                if (!(Clients.Count < 1
                                    || row == null
                                    || row.EPC == null))
                                {
                                    switch (row.ANT_IDX)
                                    {
                                        case 1:
                                            if (countdown_01 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_01 = 500;
                                            }
                                            else
                                            {
                                                countdown_01 -= interval;
                                            }
                                            break;
                                        case 2:
                                            if (countdown_02 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_02 = 500;
                                            }
                                            else
                                            {
                                                countdown_02 -= interval;
                                            }
                                            break;
                                        case 3:
                                            if (countdown_03 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_03 = 500;
                                            }
                                            else
                                            {
                                                countdown_03 -= interval;
                                            }
                                            break;
                                        case 4:
                                            if (countdown_04 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_04 = 500;
                                            }
                                            else
                                            {
                                                countdown_04 -= interval;
                                            }
                                            break;
                                        case 5:
                                            if (countdown_05 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_05 = 500;
                                            }
                                            else
                                            {
                                                countdown_05 -= interval;
                                            }
                                            break;
                                        case 6:
                                            if (countdown_06 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_06 = 500;
                                            }
                                            else
                                            {
                                                countdown_06 -= interval;
                                            }
                                            break;
                                        case 7:
                                            if (countdown_07 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_07 = 500;
                                            }
                                            else
                                            {
                                                countdown_07 -= interval;
                                            }
                                            break;
                                        case 8:
                                            if (countdown_08 <= 0)
                                            {
                                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                                countdown_08 = 500;
                                            }
                                            else
                                            {
                                                countdown_08 -= interval;
                                            }
                                            break;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"ERROR: {e.Message}\n{e.StackTrace}");
                            }
                        }
                        //// todo: save the received data to database
                        ///     1: create a tomcat server that deploy API to work with database
                        ///     2: using API to save to database
                    }
                }

                Thread.Sleep(interval);
            }
        }

        private static void AddClient()
        {
            while (true)
            {
                var client = listener.Accept();
                if (!Clients.Contains(client))
                {
                    Clients.Add(client);
                }
                Thread.Sleep(5000);
            }
        }
    }
}
