using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace TcpListenerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!--TCP Listener");
            TcpListener server = null;

            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1"); //127.0.0.1 is a loopback address

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256]; //created a buffer waiting to receive data that client is going to send us
                String data = null; //a variable which will be converted the incoming bytes into string

                while (true) //server runs an infinitely loop (keep listening) until we tell it to stop
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    using TcpClient client = server.AcceptTcpClient(); //AcceptTcpClient() is a blocking method, same as Console.ReadLine, when run, the program
                                                                       //stops until someone type in something and hit enter. Here, the program stops until a client
                                                                       //is connected.

                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream(); //return network stream from the connected client

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) //put all data into buffer
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);//encoding the modified string data back into a byte array, which
                                                      //is necessary because the stream.Write method can only send byte data over the network.

                        // Send back a response by using stream.Write.
                        stream.Write(msg, 0, msg.Length); 
                        Console.WriteLine("Sent: {0}", data);
                    }
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e); //a common exception is caused from OS trying to stop us because of permission issue
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
