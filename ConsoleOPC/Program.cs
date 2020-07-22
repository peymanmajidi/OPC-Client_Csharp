using OPC_UA_ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var endpoints = tmpOpcUaClient.GetEndpoints(ip);
            Console.WriteLine("#\tEndpointDescription\tSecurityLevel\tSecurityMode\t");
            int i = 0;
            foreach (var endpoint in endpoints)
            {
                Console.WriteLine($"{++i}\t{endpoint.EndpointDescription}\t{endpoint.SecurityLevel}\t{endpoint.SecurityMode}");
                Console.WriteLine(endpoint.SecurityPolicyUri);
            }

            // READ
            var strNodeIds = new string[]
            {
                "ns=3;s=\"TestData\".\"Static_1\""
            };
            var values = tmpOpcUaClient.ReadValues(strNodeIds);
            Console.WriteLine($"Read {strNodeIds[0]}:");
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }

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
