using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

//서버에서 데이터 받아와서, 입장할 때 방 만들어주기 (자동)
//방 클릭해서 입장하기

//제목, 방 최대인원 입력해서 방 만들기 (유저)
public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager instance;

    //레이 쏘기 위한 메인 카메라
    public Camera cam;

    // 방 정보
    public RoomData roomdata;

    // 데이터 개수 
    public int dataCount;


    [Header("방 건물 밖 : 방 이름 ")]
    public List<RoomData> roomList = new List<RoomData>();

    public List<string> roomTitles = new List<string>();
    public List<double> roomYields = new List<double>();

    [Header("방 만들기 - 외형, 위치")]
    //건물 외형 오브젝트
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    //건물 생성 위치 리스트
    public List<Transform> spawnPos;

    //방의 정보들
    private Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    [Header("방 만들기 - 입력 정보")]
    //방이름 InputField
    public InputField inputRoomName;
    //총인원 InputField
    public InputField inputMaxPlayer;

    //방생성 Button
    public Button btnCreate;

    [Serializable]
    public class roomPostInfo
    {
        public string roomTitle;
        public int roomLimitedNumber;
        public string memberId;
    }

    [Serializable]
    public class roomDeleteInfo
    {
        public string roomTitle;
    }

    void Start()
    {
        //입장할 때 방 목록 받아오기 + 콜백 : 방UI 만들어주기
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
        print("CreateRoomListUI 생성 함수 시작");
    }

    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        //print($"테스트: {array.data[1].roomCode}가 룸 코드다");

        foreach (RoomData rData in array.data)
        {
            roomTitles.Add(rData.roomTitle);

            roomYields.Add(rData.roomYield);
        }

        //전역 변수에 저장
        dataCount = array.data.Length;

        LobbyRoomUI();

        //배열 데이터를 키값에 넣는다.
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


        print("조회 완료");
    }

    //방 UI 만들기 
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

                // 1. 수익률 < -10
                if (yield <= -10)
                {
                    GameObject go = Instantiate(roomItemFactory1, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 2.-10 < 수익률 < -3
                else if (yield > -10 && yield <= -3)
                {
                    GameObject go = Instantiate(roomItemFactory2, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 3. -3 < 수익률 < 3
                else if (yield > -3 && yield <= 3)
                {
                    GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 4. 3 < 수익률 < 20
                else if (yield > 3 && yield <= 20)
                {
                    GameObject go = Instantiate(roomItemFactory4, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 5. 20 < 수익률 
                else
                {
                    GameObject go = Instantiate(roomItemFactory5, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
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
                //클릭한 물체의 태그가 House라면 
                if (hit.collider.tag == "House")
                {
                    //RoomOptions roomOptions = new RoomOptions();
                    ////roomOptions.IsVisible = false;
                    //roomOptions.MaxPlayers = 20;

                    Debug.Log(clickRoomName);
                    Debug.Log("House 클릭!");

                    //1. 서버 접속 요청
                    OnClickConnectLobby();

                    //2. 로비 접속 요청
                    print("LobbyJoin완료?");
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
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 없는 상태)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);


        //내 닉네임 설정
        //PhotonNetwork.NickName = inputNickName.text;
        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    //로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene으로 이동
        //PhotonNetwork.LoadLevel("CAJ_LobbyScene");
        //PhotonNetwork.LoadLevel("CAJ_CreateScene");
        //print("닉네임 : " + PhotonNetwork.NickName);]

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.JoinOrCreateRoom(clickRoomName, roomOptions, TypedLobby.Default);
    }

    //방 참가가 완료 되었을 때 호출 되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        //전체 방일 때만 다르게 이동 !! 
        if (PhotonNetwork.CurrentRoom.Name == "전체")
        {
            PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("CAJ_RoomScene");
        }
        print("방 참가 완료, 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
    }

    //방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //방 생성이 실패 될때 호출 되는 함수
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed , " + returnCode + ", " + message);
    }

    //방 참가 요청 (방 이름으로)
    public void JoinRoom(string inputRoomname)
    {
        PhotonNetwork.JoinRoom(inputRoomname);
    }


    //방 참가가 실패 되었을 때 호출 되는 함수
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
        print("Post 완료!");
    }

    public void CreateRoom()
    {
        // 방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        // 최대 인원 (0이면 최대인원)
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        // 룸 리스트에 보이지 않게? 보이게?
        roomOptions.IsVisible = true;
        // custom 정보를 셋팅
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        //hash["desc"] = int.Parse(inputReturn.text);
        //hash["desc"] = float.Parse(inputReturn.text);

        hash["room_name"] = inputRoomName.text;
        print("인풋 이름: " + inputRoomName.text);
        print("방이름:" + hash["room_name"]);
        //inputReturn = 0;
        //hash["desc"] = float.Parse(inputReturn.text);
        hash["desc"] = 0f;
        //hash["desc"] = 0;
        //hash["password"] = float.Parse(inputReturn.text);
        roomOptions.CustomRoomProperties = hash;
        // custom 정보를 공개하는 설정
        // roomOptions.CustomRoomPropertiesForLobby = new string[] {
        //     "desc", "map_id", "room_name", "password"
        // };
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "desc", "map_id", "room_name"
        };
        print(roomOptions);

        // 방 생성 요청 (해당 옵션을 이용해서)
        print(2222222);

        OnClickConnect();


        //PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
        //print(PhotonNetwork.CurrentRoom.Name);
    }

    public void OnClickConnect()
    {
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }
}
