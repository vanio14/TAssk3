using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using BookLibrary.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Server
{

    class Program

    {
        public static List<Book> Mybooks = new List<Book>()
    {
        new Book("My first book","Me Myself and I","thisisISBN!##",111),
        new Book("My second book","Me Myself and I again","thisisISBN!22",222)
    };
        public static readonly int Port = 7777;

        static void Main()
        {
            //IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPAddress localAddress = IPAddress.Loopback;

            // string hostName = Dns.GetHostName();
            // IPHostEntry s = Dns.GetHostEntry(hostName);
            // LocalAddress = s.AddressList[0];

            TcpListener serverSocket = new TcpListener(localAddress, Port);
            serverSocket.Start();
            Console.WriteLine("Echo server started on " + localAddress + " port " + Port);
            while (true)
            {
                try
                {
                    System.Threading.Thread.Sleep(8000);
                    Task.Run(() =>
                    {

                        TcpClient tempSocket = serverSocket.AcceptTcpClient();
                        DoIt(tempSocket);
                    });
                }
                catch (SocketException)
                {
                    Console.WriteLine("Socket exception: Will continue working");
                }
            }
        }

        private static void DoIt(TcpClient clientConnection)
        {
            Console.WriteLine("Incoming client " + clientConnection.Client);
            NetworkStream stream = clientConnection.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            while (true)
            {
                string response;
                string request = reader.ReadLine();
                if (string.IsNullOrEmpty(request)) { break; }
                string[] requestModified = request.Split(' ');
                if (requestModified[0] == "getall")
                {
                    string response1 = JsonConvert.SerializeObject(Mybooks);
                    writer.WriteLine(response1);
                    Console.WriteLine("Request: " + response1);
                    writer.Flush();
                }
                if (requestModified[0] == "get")
                {
                    string response2 = JsonConvert.SerializeObject(Mybooks.Find(i => i.ISBN13 == requestModified[1]));
                    writer.WriteLine(response2);
                    Console.WriteLine("Request: " + response2);
                    writer.Flush();
                }
                if (requestModified[0] == "save")
                {
                    string stringish = request;
                    Console.WriteLine(stringish.Replace("save", ""));
                    Mybooks.Add(JsonConvert.DeserializeObject<Book>(stringish));
                    writer.Flush();

                }
                if (requestModified[0] == "STOP")
                {
                    clientConnection.Close();
                    Console.WriteLine("Socket closed");
                    writer.Flush();
                }
                else
                {
                    string response3 = "Invalid command try:" +
                        "   getall or " +
                        "   get {ISBM13} or " +
                        "   save {jsonFormat} or " +
                        "   STOP to close the socet";
                    writer.WriteLine(response3);
                    Console.WriteLine("Request: " + response3);
                    writer.Flush();

                }

                // Console.WriteLine("Request: " + response);

                //writer.WriteLine(response);
                writer.Flush();
            }

            //clientConnection.Close();
            //Console.WriteLine("Socket closed");
        }
    }
}
