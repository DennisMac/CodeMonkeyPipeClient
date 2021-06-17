using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Threading;
using UnityEngine;

public class UnityPipeClient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Thread clientWriteThread = new Thread(ClientThread_Write);
        clientWriteThread.Start();
    }

    private void ClientThread_Write()
    {
        Debug.Log("Client: Thread started");
        NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", "ServerRead_ClientWrite", PipeDirection.Out);
        namedPipeClientStream.Connect();
        Debug.Log("Client: connected");

        StreamString streamString = new StreamString(namedPipeClientStream);

        streamString.WriteString("Hello from the client");

        namedPipeClientStream.Close();

    }
}
