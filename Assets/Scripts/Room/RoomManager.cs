using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public static RoomManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //OnPhotonSerializeView ȣ�� ��
        PhotonNetwork.SerializationRate = 60;
        //Rpc ȣ�� ��
        PhotonNetwork.SendRate = 60;

        //�÷��̾ �����Ѵ�.
        //PhotonNetwork.Instantiate("Player", spawnPos[idx], Quaternion.identity);
        PhotonNetwork.Instantiate("AntPlayer", new Vector3(58, 4, -109), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
