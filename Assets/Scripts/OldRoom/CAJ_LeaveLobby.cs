using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAJ_LeaveLobby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LoadLevel("Test)CAJ_LobbyScene");
        PhotonNetwork.Disconnect();
        //PhotonNetwork.LeaveRoom();
        //OnConnectedToMaster();
    }

    //public override void O


}
