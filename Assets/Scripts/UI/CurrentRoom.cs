using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class CurrentRoom : MonoBehaviour
{
    public Text RoomText;
    // Start is called before the first frame update
    void Start()
    {
        // 앗... 이게 아닌가ㅠ
        //RoomText.text = LobbyManager.instance.clickRoomName;
        //RoomText.text = PhotonNetwork.CurrentRoom.Name;
        //print(LobbyManager.instance.clickRoomName);
        //print(PhotonNetwork.CurrentRoom.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
