using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//HTTP
using UnityEngine.Networking;


//�������, �޾ƿ� ������ ���� + ���ͷ� �������ֱ�!! 

//GetRoomAll�� �� ��� ���� �޾ƿ������ �ϰ�,
//CreateRoomListUI�� ���ش� 
//->�ڷ�ƾ ��� !! 
public class NormalRoomItem : MonoBehaviour
{
    //�� ����
    //public TMP_Text roomName;

    //�� ���ͷ�
    //public TMP_Text roomYield;


    //IEnumerator Test()
    //{
    //    //�� �ȿ�, GetRoomAll�̶�, NormalCreateRoomListUI �� �� ������ ! 

    //    HttpRequester requester = new HttpRequester();

    //    requester.url = "http://3.34.133.115:8080/shareholder-room";
    //    requester.requestType = RequestType.GET;
    //    requester.onComplete = CompleteGetRoomListAll;


    //    print("CreateRoomListUI ���� �Լ� ����!");


    //    int count = 0;

    //    print("dataCount : " + dataCount);
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //    }
    //    HttpManager.instance.SendRequest(requester);

    //    //NormalCreateRoomListUI();
    //    print("CreateRoomListUI ���� �Լ� ����");

    //    //yield return StartCoroutine(GetRoomAll());
    //    //yield return StartCoroutine(NormalCreateRoomListUI());

    //}

    void Start()
    {
        //StartCoroutine("Test");
       // print("�ڷ�ƾ �Լ� ����");
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

    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        RoomDataArray array = JsonUtility.FromJson<RoomDataArray>(handler.text);

        //���� ������ ����
        dataCount = array.data.Count;
        //print("dataCount: " + dataCount);

        
        CreateRoom();

        //for (int i = 0; i < dataCount; i++)
        //{
        //    int count = 0;
        //    GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
        //    print("������!");
        //}

        for (int i = 0; i < array.data.Count; i++)
        {
            //print(array.data[i].roomTitle);
            //print(array.data[i].roomYield);
            //print("��ȸ �Ϸ�");
        }
    }

    public void CreateRoom()
    {

        int count = 0;
        for (int i = 0; i < dataCount; i++)
        {
            GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
            count++;
            print("������!");
        }
    }

    public int dataCount;


    // 2. �� �����
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    public List<Transform> spawnPos;

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
