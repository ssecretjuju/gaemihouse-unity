using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

//�������� ������ �޾ƿͼ�, ������ �� �� ������ֱ� (�ڵ�)
//�� Ŭ���ؼ� �����ϱ�

//�� �����
[Serializable]
public class RoomPostInfo
{
    public string roomTitle;
    public int roomLimitedNumber;
    public string memberId;
}

//�� ����
[Serializable]
public class RoomDeleteInfo
{
    public string roomTitle;
}

//�� ������ ��
[Serializable]
public class RoomJoinInfo
{
    public string roomTitle;
    public string memberId;
}

//�� Ŭ������ �� �޴� ������ (0, 1, -1)
[Serializable]
public class RoomEntranceInfo
{
    public int data;
}

//���� ���� ��û�� : �����ϰڴٰ� �ϸ�, ������ ���� 
[Serializable]
public class RoomApplicationInfo
{
    public string roomTitle;
    public string memberId;
}

//����, �� �ִ��ο� �Է��ؼ� �� ����� (����)
public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager instance;

    //���� ��� ���� ���� ī�޶�
    public Camera cam;

    // �� ����
    public RoomData roomdata;

    // ������ ���� 
    public int dataCount;


    [Header("�� �ǹ� �� : �� �̸� ")]
    public List<RoomData> roomList = new List<RoomData>();

    public List<string> roomTitles = new List<string>();
    public List<double> roomYields = new List<double>();

    [Header("�� ����� - ����, ��ġ")]
    //�ǹ� ���� ������Ʈ
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    //�ǹ� ���� ��ġ ����Ʈ
    public List<Transform> spawnPos;

    //���� ������
    private Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    [Header("�� ����� - �Է� ����")]
    //���̸� InputField
    public InputField inputRoomName;
    //���ο� InputField
    public InputField inputMaxPlayer;

    //����� Button
    public Button btnCreate;


    void Start()
    {
        //������ �� �� ��� �޾ƿ��� + �ݹ� : ��UI ������ֱ�
        GetRoomAll();
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

    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        //print($"�׽�Ʈ: {array.data[1].roomCode}�� �� �ڵ��");

        foreach (RoomData rData in array.data)
        {
            roomTitles.Add(rData.roomTitle);

            roomYields.Add(rData.roomYield);
        }

        //���� ������ ����
        dataCount = array.data.Length;

        LobbyRoomUI();

        //�迭 �����͸� Ű���� �ִ´�.
        //string s = "{\"data\":" + handler.text + "}";
        string s = "{\"data\":" + handler.text + "}";
        //print(s);


        string a = handler.text;
        //print("a : " + a);

        ////List<PostData>
        //RoomDataArray array = JsonUtility.FromJson<RoomDataArray>(s);
        //for (int i = 0; i < array.data.Count; i++)
        //{

        //    print(array.data[i].roomTitle + "\n" + array.data[i].roomRegistedNumber + "\n" + array.data[i].roomCode + array.data[i].roomYield + array.data[i].roomLimitedNumber);
        //    //print(array);
        //}


        print("��ȸ �Ϸ�");
    }

    //�� UI ����� 
    public void LobbyRoomUI()
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

                    ClickRoomJoin();
                }
                else
                {
                    return;
                }
            }
        }
    }


    public void ClickRoomJoin()
    {
        RoomJoinInfo joinroomdata = new RoomJoinInfo();
        joinroomdata.memberId = LoginManager.Instance.playerData.memberId;
        joinroomdata.roomTitle = clickRoomName;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room/entrance";
        requester.requestType = RequestType.POST;
        print("test");

        requester.postData = JsonUtility.ToJson(joinroomdata, true);
        print(requester.postData);

        requester.onComplete = OnEntranceData;
        print("�� �̸�,�Ƶ� ������ �Ϸ�");
        ///////////
        /// 
        HttpManager.instance.SendRequest(requester);
    }

    public int entranceCode;
    public GameObject applicationUI;

    public GameObject NoUI;


    public void OnEntranceData(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);

        RoomEntranceInfo entrance = JsonUtility.FromJson<RoomEntranceInfo>(data);

        entranceCode = entrance.data;
        print(entranceCode);

        //0. ����â �� ����
        if (entranceCode == 0)
        {
            //����â 
            applicationUI.SetActive(true);
            
        }

        //1 : �ٷ� ����
        else if (entranceCode == 1)
        {
            //1. ���� ���� ��û
            OnClickConnectLobby();
            //2. �κ� ���� ��û
        }

        //-1 : ���� x (�ٸ� �濡 ���Ե�����)
        else
        {
            //���� �� �ȴٴ� ���â
            NoUI.SetActive(true);
        }
    }

    //���� : ����� Ŭ���� ��� 
    public void ClickJoinYes()
    {
        OnClickConnectLobby();
    }

    public void ClickApplication()
    {
        RoomApplicationInfo roomApplicationInfo = new RoomApplicationInfo();
        
        roomApplicationInfo.memberId = LoginManager.Instance.playerData.memberId;
        roomApplicationInfo.roomTitle = clickRoomName;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room/join";
        requester.requestType = RequestType.POST;
        print("test");

        requester.postData = JsonUtility.ToJson(roomApplicationInfo, true);
        print(requester.postData);

        requester.onComplete = OnEntranceData;
        print("�� �̸�,�Ƶ� ������ �Ϸ�");
        /////////////
        ///// 
        HttpManager.instance.SendRequest(requester);

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

        //print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //PhotonNetwork.JoinLobby();
        print("3333333333333333");
        //print("������ ���� ���� �Ϸ� -> �κ�� �̵�!");

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

        CreateRoom();

        //if (inputRoomName.text != null)
        //{
        //    //RoomOptions roomOptions = new RoomOptions();
        //    //roomOptions.IsVisible = false;
        //    //roomOptions.MaxPlayers = 20;

        //    PhotonNetwork.JoinOrCreateRoom(inputRoomName.text, roomOptions, TypedLobby.Default);
        //    print(inputRoomName.text);
        //}

        //else
        //{
        //    //CreateRoom();
        //    //ClickRoomJoin();
        //    return;
        //}

        //if (clickRoomName != null)
        //{
        //PhotonNetwork.JoinOrCreateRoom(clickRoomName, roomOptions, TypedLobby.Default);
        //}
        //else
        //{
        //    PhotonNetwork.JoinOrCreateRoom(inputRoomName.text, roomOptions, TypedLobby.Default);
        //}


        //if (clickRoomName != null)
        //{
        //}
        //else
        //{
        //    PhotonNetwork.LoadLevel("Test)CAJ_LobbyScene");
        //}
    }

    //�� ������ �Ϸ� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        print("4444444");
        //��ü ���� ���� �ٸ��� �̵� !! 
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
        print("2222222222");
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
        print(inputRoomname);
        print("33333333333");
    }


    //�� ������ ���� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

    public void PostRoomInfoClick()
    {
        roomPostInfo data = new roomPostInfo();
        data.roomTitle = inputRoomName.text;
        //data.roomYield = float.Parse(inputReturn.text);
        data.roomLimitedNumber = int.Parse(inputMaxPlayer.text);
        // data.isOpen = true;
        // List<string> roomMember = new List<string>();
        string id = LoginManager.Instance.playerData.memberId;

        data.memberId = id;
        print(id);
        print(LoginManager.Instance.playerData.memberId);
        //print(LoginManager.Instance.playerData.username);
        //print(LoginManager.Instance.playerData);



        HttpRequester requester = new HttpRequester();
        //requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.POST;
        print("Post test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);
        print("Post �Ϸ�!");
    }


    public string inputRoom;
    //�� ����� Ŭ���ϸ� ����Ǵ� �Լ� ! 
    public void CreateRoom()
    {
        // �� �ɼ��� ����
        RoomOptions roomOptions = new RoomOptions();
        // �ִ� �ο� (0�̸� �ִ��ο�)
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        // �� ����Ʈ�� ������ �ʰ�? ���̰�?
        roomOptions.IsVisible = true;
        // custom ������ ����
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        //hash["desc"] = float.Parse(inputReturn.text);

        hash["room_name"] = inputRoomName.text;
        print("��ǲ �̸�: " + inputRoomName.text);
        print("���̸�:" + hash["room_name"]);
        //hash["desc"] = float.Parse(inputReturn.text);
        hash["desc"] = 0f;
        //hash["desc"] = 0;
        //hash["password"] = float.Parse(inputReturn.text);
        roomOptions.CustomRoomProperties = hash;
        // custom ������ �����ϴ� ����
        // roomOptions.CustomRoomPropertiesForLobby = new string[] {
        //     "desc", "map_id", "room_name", "password"
        // };
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "desc", "map_id", "room_name"
        };

        print(roomOptions);

        inputRoom = inputRoomName.text;

        // �� ���� ��û (�ش� �ɼ��� �̿��ؼ�)
        print("111111111111111");

        OnClickConnect();

        //PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
        //print(PhotonNetwork.CurrentRoom.Name);
    }

    public void OnClickConnect()
    {
        //���� ���� ��û
        PhotonNetwork.ConnectUsingSettings();
        print("2222222222");
    }


    public void ClickLobbyBtn()
    {
        PhotonNetwork.LeaveRoom();
        //OnConnected();
    }

    //DeleteRoom

    public InputField roomName;
    public void OnClickDelete()
    {
        roomDeleteInfo data = new roomDeleteInfo();
        data.roomTitle = roomName.text;
        print("�����Ϸ��� �� �̸� : " + roomName.text);


        HttpRequester requester = new HttpRequester();
        //requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room/" + roomdata.roomTitle;
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        print(requester.url);
        requester.requestType = RequestType.DELETE;
        
        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        requester.onComplete = OnCilckDownload;

        HttpManager.instance.SendRequest(requester);
    }

    public void OnCilckDownload(DownloadHandler handler)
    {
        print("��ȸ �Ϸ�");
    }


}
