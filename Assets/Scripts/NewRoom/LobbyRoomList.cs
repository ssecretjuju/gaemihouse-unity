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
    public static LobbyRoomList instance;

    public Camera cam;

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


    //public static List<RoomData> roomdata;
    public RoomData roomdata;

    //���� ���
    //private string path;

    public int dataCount;

    public List<RoomData> roomList = new List<RoomData>();

    public List<string> roomTitles = new List<string>();
    public List<double> roomYields = new List<double>();

    //���� ����
    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        print($"�׽�Ʈ: {array.data[1].roomCode}�� �� �ڵ��");

        foreach (RoomData rData in array.data)
        {
            roomTitles.Add(rData.roomTitle);

            roomYields.Add(rData.roomYield);
        }

       

            //���� ������ ����
            dataCount = array.data.Length;

            //File.WriteAllText(Application.dataPath + "/RoomListJson.json", JsonUtility.ToJson(json));
        //File.WriteAllText(Application.dataPath + "/RoomListJson.json", array.data[0]);
        //string path = Path.Combine(Application.dataPath, "/RoomListJson.json");

        //File.WriteAllText(Application.dataPath + "/RoomListJson.json", JsonUtility.ToJson(json));

        //if (Directory.Exists(path) == false)
        //{
        //    Directory.CreateDirectory(path);
        //}


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

    public Array NameArray;


    //���� ������
    private Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    //�� UI ����� 
    public void CreateRoom()
    {
        print("CreateRoom ����!!!!!!!!");
        int count = 0;

        //foreach (RoomInfo info in roomCache.Values)
        {
            for (int i = 0; i < dataCount; i++)
            {
                GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
                LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                //�ǹ� �� <- �� �̸�
                item.SetInfoName(roomTitles[i]);
                //�ǹ� �� <- �� ���ͷ�
                item.SetInfoYield(roomYields[i]);

                //�ǹ� ������Ʈ �̸� = �� �̸�
                go.name = roomTitles[i];

                count++;
                print("������!");
            }
        }
    }

    public IEnumerator CreateRoomUI()
    {
        yield return null;
        print("CreateRoomListUI ���� �Լ� ����!");
        int count = 0;

        yield return null;

        print("dataCount : " + dataCount);

        yield return null;
        for (int i = 0; i < dataCount; i++)
        {
            print("for�� ����");
            GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
            count++;
            print("������!");
        }
    }


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


    public void ClickRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Building ���̾ �浹 üũ 
            int mask = (1 << 3);
            if (Physics.Raycast(ray, out hit, 125f, mask))
            {
                Debug.Log(hit.transform.gameObject);
                string clickRoomName = hit.collider.gameObject.name.ToString();
                Debug.Log(clickRoomName);
                //Ŭ���� ��ü�� �±װ� House��� 
                if (hit.collider.tag == "House")
                {
                    //PhotonNetwork.JoinOrCreateRoom(clickRoomName);
                }
                else
                {
                    return;
                }
            }
        }
    }

}
