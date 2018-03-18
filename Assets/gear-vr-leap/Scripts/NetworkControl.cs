using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkControl : NetworkBehaviour
{
    public GameObject leapEventSystem;
     [Command]
   public void CmdSpaen()
    {
            GameObject connBlockFromObject = (GameObject)GameObject.Instantiate (leapEventSystem, Vector3.zero, Quaternion.identity);
                NetworkServer.Spawn(connBlockFromObject);

    }
}
