using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickConnectLobby()
    {
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }
}
