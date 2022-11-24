using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//HTTP
using UnityEngine.Networking;
using System.IO;
using Photon.Pun;
using Photon.Realtime;


//GetRoomAll�� �� ��� ���� �޾ƿ������ �ϰ�,
//CreateRoomListUI�� ���ش� 
//->�ڷ�ƾ ��� !! 
public class LobbyRoomList : MonoBehaviourPunCallbacks
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

        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
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

        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
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
        int count = 0;

        //foreach (RoomInfo info in roomCache.Values)
        {
            //for (int i = dataCount; i > 0; i++)
            for (int i = 0; i < dataCount; i++)
            {
                double yield = roomYields[i];
                //double roomYields[i] = yield;

                // 1. ���ͷ� < -10
                if (yield <= -10)
                {
                    GameObject go = Instantiate(roomItemFactory1, spawnPos[count]);
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

                // 2.-10 < ���ͷ� < -3
                else if (yield > -10 && yield <= -3)
                {
                    GameObject go = Instantiate(roomItemFactory2, spawnPos[count]);
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

                // 3. -3 < ���ͷ� < 3
                else if (yield > -3 && yield <= 3)
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

                // 4. 3 < ���ͷ� < 20
                else if (yield > 3 && yield <= 20)
                {
                    GameObject go = Instantiate(roomItemFactory4, spawnPos[count]);
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

                // 5. 20 < ���ͷ� 
                else
                {
                    GameObject go = Instantiate(roomItemFactory5, spawnPos[count]);
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
    //        count++;
    //        print("������!");
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
        ClickRay();
    }

    public string clickRoomName;

    public void ClickRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            print("click");
            RaycastHit hit;
            print("hit");
            //int mask = (1 << 3);
            int mask = 1 << LayerMask.NameToLayer("Building");
            if (Physics.Raycast(ray, out hit, 150f, mask))
            {
                clickRoomName = hit.collider.gameObject.name.ToString();
                //Ŭ���� ��ü�� �±װ� House��� 
                if (hit.collider.tag == "House")
                {
                    //RoomOptions roomOptions = new RoomOptions();
                    ////roomOptions.IsVisible = false;
                    //roomOptions.MaxPlayers = 20;

                    Debug.Log(clickRoomName);
                    Debug.Log("House Ŭ��!");

                    //1. ���� ���� ��û
                    OnClickConnectLobby();

                    //2. �κ� ���� ��û
                    print("LobbyJoin�Ϸ�?");
                }
                else
                {
                    return;
                }
            }
        }
    }


    public void OnClickConnectLobby()
    {
        //���� ���� ��û
        PhotonNetwork.ConnectUsingSettings();
    }

    //������ ���� ���Ӽ����� ȣ��(Lobby�� ������ �� ���� ����)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //������ ���� ���Ӽ����� ȣ��(Lobby�� ������ �� �ִ� ����)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);


        //�� �г��� ����
        //PhotonNetwork.NickName = inputNickName.text;
        //�κ� ���� ��û
        PhotonNetwork.JoinLobby();
    }

    //�κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene���� �̵�
        //PhotonNetwork.LoadLevel("CAJ_LobbyScene");
        //PhotonNetwork.LoadLevel("CAJ_CreateScene");
        //print("�г��� : " + PhotonNetwork.NickName);]

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.JoinOrCreateRoom(clickRoomName, roomOptions, TypedLobby.Default);
    }

    //�� ������ �Ϸ� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        if (PhotonNetwork.CurrentRoom.Name == "��ü")
        {
            PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("CAJ_RoomScene");
        }
        print("�� ���� �Ϸ�, �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
    }

    //���� �����Ǹ� ȣ�� �Ǵ� �Լ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //�� ������ ���� �ɶ� ȣ�� �Ǵ� �Լ�
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed , " + returnCode + ", " + message);
    }

    //�� ���� ��û (�� �̸�����)
    public void JoinRoom(string inputRoomname)
    {
        PhotonNetwork.JoinRoom(inputRoomname);
    }


    //�� ������ ���� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

}



