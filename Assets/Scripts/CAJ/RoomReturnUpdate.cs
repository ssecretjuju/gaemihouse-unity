using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomReturnUpdate : MonoBehaviourPunCallbacks
{
    public InputField ReturnInput;

    public Button ReturnBtn;


    // Start is called before the first frame update
    void Start()
    {
        print("���� �� CustomProperties : " + PhotonNetwork.CurrentRoom.CustomProperties);
    }

    public void ReturnChange()
    {
        //1. ���� ���¸� ���
        //Room room = PhotonNetwork.CurrentRoom;
        print("���� �� ���� : " + PhotonNetwork.CurrentRoom);

        // 2. ���� Ŀ���� ������Ƽ ���
        float newReturn = float.Parse(ReturnInput.text);

        print("1. �Է¹��� newReturn : " + newReturn + " null�� �ƴ��� Ȯ��!");

        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        setValue["desc"] = newReturn;

        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

        print("Ŀ���� ������Ƽ ����Ǿ���? : " + PhotonNetwork.CurrentRoom.CustomProperties);

        //if (newReturn < 0)
        //{
        //    PhotonNetwork.LoadLevel("GameScene");
        //}

        //else if (newReturn == 0)
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Igloo");

        //}

        //else if (newReturn > 0 && newReturn < 100)
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Fire");
        //}

        ////else  (newReturn >= 100)
        //else
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Gold");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
