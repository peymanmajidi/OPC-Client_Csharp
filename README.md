# OPC Client
OPC is a software interface standard that allows Windows programs to communicate with industrial hardware devices.

![shot](csharp_opc_client_03_e.png)

```csharp
// READ
var strNodeIds = new string[]
{
    "ns=4;i=3",
    "ns=4;i=4"
};
var values = tmpOpcUaClient.ReadValues(strNodeIds);
```

![shot2](opc.jpeg)

The OPC client software is any program that needs to connect to the hardware, such as an HMI . The OPC client uses the OPC server to get data from or send commands to the hardware.
