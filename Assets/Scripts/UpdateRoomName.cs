using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class UpdateRoomName : MonoBehaviourPunCallbacks
{
    public InputField NameInput;
    public Button RenameBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NameChange()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        NameInput.text = PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        //hash["room_name"] = NameInput.text;
    }
}
