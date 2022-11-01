using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InRoomName : MonoBehaviour
{
    //내용 
    public Text roomInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoomName();
    }
    
    public void RoomName()
    {
        //roomInfo = string(PhotonNetwork.CurrentRoom.Name);
        //roomDesc = PhotonNetwork.CurrentRoom.;
        roomInfo.text = PhotonNetwork.CurrentRoom.Name;
    }
}
