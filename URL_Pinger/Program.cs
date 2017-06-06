using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace URL_Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goodResponse = false;
            int refreshRate = 0;
            string URL;

            Console.WriteLine("Please Enter URL to ping");
            URL = Console.ReadLine();
            Console.WriteLine("Starting to ping: {0}", URL);

            do
            {
                System.Threading.Thread.Sleep(refreshRate);
                refreshRate = 60000;

                try
                {
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(URL);
                    if (reply.Status == IPStatus.Success)
                    {
                        SMTPMail.Send("URL is Responding", URL + " is Responding " + DateTime.Now);

                        goodResponse = true;
                    }
                    else
                    {
                        Console.WriteLine(
                            "Status: {0} | {1}",
                            reply.Status.ToString(),
                            DateTime.Now.ToString("HH:mm:ss"));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(
                        "Status: {0} | {1}",
                        "Error",
                        DateTime.Now.ToString("HH:mm:ss"));
                }


            } while (!goodResponse);

            //Console.ReadLine();
        }
    }
}
