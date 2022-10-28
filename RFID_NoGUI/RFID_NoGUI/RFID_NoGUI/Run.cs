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

        private static Socket knownClient1;
        private static Socket knownClient2;
        private static List<Socket> Clients;

        private static RFID.Cores.DataDTO row = null;

        /// <summary>
        ///  send message to TCP clients
        /// </summary>
        /// <param name="data"></param>
        private static void SendMessage(string data)
        {
            Console.WriteLine($"*** Sending message *** ");
            byte[] message = Encoding.ASCII.GetBytes(data);
            for (int i = 0; i < Clients.Count; i++)
            {
                var client = Clients[i];
                if(client == null) continue;
                try
                {
                    client.Send(message);
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
            var main = new MainProgram();
            int max = 1000;
            int port = 3394;

            int tags;
            main.Log = new Program();

            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint clients = new IPEndPoint(IPAddress.Any, port);
            listener.Bind(clients);
            listener.Listen(max);

            Clients.Add(listener.Accept());
            Task worker = Task.Run(() => AddClient());

            while (true)
            {
                //Console.WriteLine($"client 2: {knownClient2 == null}");
                row = null;
                //if (listener != null )
                //{
                //    //if (Clients.Count < 2)
                //    //{

                //    //    Console.WriteLine($"count < 1...");
                //    //    var client = listener.Accept();
                //    //    Clients.Add(client);

                //    //    Console.WriteLine($"added...");
                //    //}
                //    //else
                //    //{
                //    //    if (Clients.Count < 2)
                //    //    {

                //    //        Console.WriteLine($"count < 2...");
                //    //        try
                //    //        {
                //    //            var client = listener.Accept(); 
                //    //            if (!Clients.Contains(client))
                //    //            {
                //    //                Clients.Add(client);
                //    //                Console.WriteLine($"added...");
                //    //            }
                //    //        }
                //    //        catch
                //    //        {
                //    //            Console.WriteLine($"failed...");
                //    //        }
                            
                //    //    }
                //    //}
                //}
                if (!main.IsConnected)
                {
                    main.DisConnectGateway();
                    main.IsConnected = main.ConnectGateway();
                }
                else
                {
                    if (!main.IsReading)
                    {
                        tags = main.Read6CTag_EPCTID_Anten01();
                    }
                    else
                    {
                        //Console.WriteLine($"Reading...");
                        row = main.Log.OutPutTags_();
                        /// send message to TCP clients
                        var lastReadTime = (DateTime.Now - row.ReadTime).TotalSeconds;
                        //Console.WriteLine($"knownClient1 == null: {knownClient1 == null}");
                        //Console.WriteLine($"row  == null: {row == null}");
                        //Console.WriteLine($"row.EPC == null: {row.EPC == null}");
                        //Console.WriteLine($"lastReadTime: {lastReadTime}");
                        //Console.WriteLine($"*** {sam.JsonHelper.SerializeObject(row)} ***");
                        try
                        {
                            //Console.WriteLine($"Clients.Count {Clients.Count}");
                            
                            if (!(Clients.Count<1
                                || row == null
                                || row.EPC == null
                                || lastReadTime > 2))
                            {

                                SendMessage(sam.JsonHelper.SerializeObject(row));
                                Console.WriteLine(sam.JsonHelper.SerializeObject(row));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"ERROR: {e.Message}\n{e.StackTrace}");
                        }
                        //// todo: save the received data to database
                        ///     1: create a tomcat server that deploy API to work with database
                        ///     2: using API to save to database
                    }
                }

                Thread.Sleep(125);
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
                    Console.WriteLine($"added...");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
