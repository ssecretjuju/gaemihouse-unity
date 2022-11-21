using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//HTTP
using UnityEngine.Networking;
using System.IO;
using Photon.Realtime;


//GetRoomAll�� �� ��� ���� �޾ƿ������ �ϰ�,
//CreateRoomListUI�� ���ش� 
//->�ڷ�ƾ ��� !! 
public class LobbyRoomList : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine("Test");
        //GetRoom();
        GetRoomAll();
    }

    // 1. �� ���� �޾ƿ���

    public void GetRoom()
    {
        HttpRequester requester = new HttpRequester();

        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = CompleteGetRoomList;

        HttpManager.instance.SendRequest(requester);
    }

    public void CompleteGetRoomList(DownloadHandler handler)
    { 
        RoomData roomData = JsonUtility.FromJson<RoomData>(handler.text);
        //print("��ȸ �Ϸ�");
    }

    public void GetRoomAll()
    {
        HttpRequester requester = new HttpRequester();

        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = CompleteGetRoomListAll;

        HttpManager.instance.SendRequest(requester);

        //NormalCreateRoomListUI();
        //CreateRoomUI();
        print("CreateRoomListUI ���� �Լ� ����");
    }

    //���� ���
    //public string path = Application.dataPath + "/Data";

    public static List<RoomData> roomdata;

    //���� ���
    //private string path;

    //���� ����
    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        print($"�׽�Ʈ: {array.data[1].roomCode}�� �� �ڵ��");
        string path = Path.Combine(Application.dataPath, "/RoomListJson.json");

        string json = JsonUtility.ToJson(array);
        
        //File.WriteAllText(Application.dataPath + "/RoomListJson.json", JsonUtility.ToJson(json));


        //�����ϱ� 
        File.WriteAllText(path, json);


        //roomdata = new List<RoomData>();

        //string json = JsonUtility.FromJson<RoomData>(roomdata);

        //string json= JsonUtility.ToJson(array);
        
        


        //string json = JsonUtility.FromJson<RoomDataArray>(handler.text);
        

        //if (Directory.Exists(path) == false)
        //{
        //    Directory.CreateDirectory(path);
        //}


        //���� ������ ����
        //dataCount = array.data.Count;

        //print("dataCount: " + dataCount);


        CreateRoom();

        //for (int i = 0; i < array.data.Count; i++)
        //{
        //    //print(array.data[i].roomTitle);
        //    //print(array.data[i].roomYield);
        //    //print("��ȸ �Ϸ�");
        //}
    }

    // 2. �� �����
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    public List<Transform> spawnPos;

    public int dataCount;

    public Array NameArray;


    public void CreateRoom()
    {

        int count = 0;

        for (int i = 0; i < dataCount; i++)
        {
            GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
            //go.name = array;
            count++;
            print("������!");
        }
    }

    
    //public IEnumerator CreateRoomUI()
    //{
    //    yield return null;
    //    print("CreateRoomListUI ���� �Լ� ����!");
    //    int count = 0;

    //    yield return null;

    //    print("dataCount : " + dataCount);

    //    yield return null;
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        print("for�� ����");
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //        print("������!");
    //    }
    //}

    //void NormalCreateRoomListUI()
    //{
    //    print("CreateRoomListUI ���� �Լ� ����!");
    //    int count = 0;

    //    yield return null;
    //    print("dataCount : " + dataCount);
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //    }

    //}




    //�켱 �� �̸����θ�! < ���� : roomName (currPlayer / maxPlayer) >
    public void NormalSetInfo(string roomName)
    {
        //�̸��� �������ش� : ��� ������ ���������! 
        //NormalSetInfo();

        //���ͷ� ���� 
        //string sreturn = double����.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
