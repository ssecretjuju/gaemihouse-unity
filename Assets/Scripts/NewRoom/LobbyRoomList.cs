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

    //저장 경로
    //public string path = Application.dataPath + "/Data";

    public static List<RoomData> roomdata;

    //저장 경로
    //private string path;

    //방목록 정보
    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        print($"테스트: {array.data[1].roomCode}가 룸 코드다");
        string path = Path.Combine(Application.dataPath, "/RoomListJson.json");

        string json = JsonUtility.ToJson(array);
        
        //File.WriteAllText(Application.dataPath + "/RoomListJson.json", JsonUtility.ToJson(json));


        //저장하기 
        File.WriteAllText(path, json);


        //roomdata = new List<RoomData>();

        //string json = JsonUtility.FromJson<RoomData>(roomdata);

        //string json= JsonUtility.ToJson(array);
        
        


        //string json = JsonUtility.FromJson<RoomDataArray>(handler.text);
        

        //if (Directory.Exists(path) == false)
        //{
        //    Directory.CreateDirectory(path);
        //}


        //전역 변수에 저장
        //dataCount = array.data.Count;

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
            print("생성됨!");
        }
    }

    
    //public IEnumerator CreateRoomUI()
    //{
    //    yield return null;
    //    print("CreateRoomListUI 생성 함수 들어옴!");
    //    int count = 0;

    //    yield return null;

    //    print("dataCount : " + dataCount);

    //    yield return null;
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        print("for문 들어옴");
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //        print("생성됨!");
    //    }
    //}

    //void NormalCreateRoomListUI()
    //{
    //    print("CreateRoomListUI 생성 함수 들어옴!");
    //    int count = 0;

    //    yield return null;
    //    print("dataCount : " + dataCount);
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //    }

    //}




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
}
