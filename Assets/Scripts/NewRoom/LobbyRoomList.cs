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


//GetRoomAll로 방 목록 정보 받아오기부터 하고,
//CreateRoomListUI를 해준다 
//->코루틴 사용 !! 
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

    // 1. 방 정보 받아오기

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
        //print("조회 완료");
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
        print("CreateRoomListUI 생성 함수 시작");
    }


    //public static List<RoomData> roomdata;
    public RoomData roomdata;

    //저장 경로
    //private string path;

    public int dataCount;

    public List<RoomData> roomList = new List<RoomData>();

    public List<string> roomTitles = new List<string>();
    public List<double> roomYields = new List<double>();

    //방목록 정보
    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        print($"테스트: {array.data[1].roomCode}가 룸 코드다");

        foreach (RoomData rData in array.data)
        {
            roomTitles.Add(rData.roomTitle);

            roomYields.Add(rData.roomYield);
        }

       

            //전역 변수에 저장
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
        //    //print("조회 완료");
        //}
    }

    // 2. 방 만들기
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    public List<Transform> spawnPos;

    public Array NameArray;


    //방의 정보들
    private Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    //방 UI 만들기 
    public void CreateRoom()
    {
        print("CreateRoom 실행!!!!!!!!");
        int count = 0;

        //foreach (RoomInfo info in roomCache.Values)
        {
            for (int i = 0; i < dataCount; i++)
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
        }
    }

    public IEnumerator CreateRoomUI()
    {
        yield return null;
        print("CreateRoomListUI 생성 함수 들어옴!");
        int count = 0;

        yield return null;

        print("dataCount : " + dataCount);

        yield return null;
        for (int i = 0; i < dataCount; i++)
        {
            print("for문 들어옴");
            GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
            count++;
            print("생성됨!");
        }
    }


    //우선 룸 이름으로만! < 원래 : roomName (currPlayer / maxPlayer) >
    public void NormalSetInfo(string roomName)
    {
        //이름을 지정해준다 : 어느 정보의 룸네임으로! 
        //NormalSetInfo();

        //수익률 설정 
        //string sreturn = double정보.ToString();
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
            //Building 레이어만 충돌 체크 
            int mask = (1 << 3);
            if (Physics.Raycast(ray, out hit, 125f, mask))
            {
                Debug.Log(hit.transform.gameObject);
                string clickRoomName = hit.collider.gameObject.name.ToString();
                Debug.Log(clickRoomName);
                //클릭한 물체의 태그가 House라면 
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
