using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CAJ_LobbyBtn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLobby()
    {
        PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LoadLevel("CAJ_CreateScene");
        //PhotonNetwork.LoadLevel("Test)CAJ_LobbyScene");
        PhotonNetwork.Disconnect();
        //SceneManager.LoadScene("Test)CAJ_LobbyScene");
    }
}
