using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OverridenNetworkDiscovery : NetworkDiscovery
{
    public GameObject leapPrefab;

    void Start()
    {
        startClient();
    }

    public void startClient()
    {
        Initialize();
        StartAsClient();
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        Debug.Log("I work");
        Debug.Log(fromAddress);
        NetworkManager.singleton.networkAddress = fromAddress;
        NetworkManager.singleton.StartClient();
        StopBroadcast();
        
    }
}
