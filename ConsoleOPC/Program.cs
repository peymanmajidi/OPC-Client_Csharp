using OPC_UA_ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ConsoleOPC
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmpOpcUaClient = new OpcUaClient();
            var ip = "opc.tcp://192.168.2.179";
            Console.Write($"Try to connect '{ip}'...");

            // CONNECT
            var endpoints = tmpOpcUaClient.GetEndpoints(ip);
            Console.WriteLine($"\r\nConnected.");

            // LIST ALL OF POSSIBLE END POINTS
            Console.WriteLine("\r\n#\tEndpointDescription\tSecurityLevel\tSecurityMode\t");
            Console.WriteLine("---------------------------------------------------------------");
            int i = 0;
            foreach (var endpoint in endpoints)
            {
                Console.WriteLine($"{++i}\t{endpoint.EndpointDescription}\t{endpoint.SecurityLevel}\t{endpoint.SecurityMode}");
                Console.WriteLine(endpoint.SecurityPolicyUri);
            }


            var is_connected = tmpOpcUaClient.Connect(endpoints[0], false, "", "");
            Console.WriteLine("\r\nConnection Status: " + (is_connected ? "OK" : "Failed"));


            // READ
            var strNodeIds = new string[]
            {
                "ns=4;i=3",
                //"ns=4;i=4"
            };
            var values = tmpOpcUaClient.ReadValues(strNodeIds);

            Console.WriteLine($"{values.Count()} items(s) found");
            Console.WriteLine();
            while (true)
            {

                values = tmpOpcUaClient.ReadValues(strNodeIds);
                foreach (var value in values)
                {
                    Console.Write("\r" + strNodeIds[0] + ": " + value);
                }

            }



            return;
            // WRITE
            strNodeIds = new string[]
            {
                "ns=3;s=\"DataStatic\".\"myInt\""
            };
            var vals_to_write = new string[]
            {
                "100"
            };
            tmpOpcUaClient.WriteValues(vals_to_write, strNodeIds);



        }
    }
}
