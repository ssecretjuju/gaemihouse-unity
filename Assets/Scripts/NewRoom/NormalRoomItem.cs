using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//HTTP
using UnityEngine.Networking;


//포톤없이, 받아온 정보로 제목 + 수익률 배정해주기!! 

//GetRoomAll로 방 목록 정보 받아오기부터 하고,
//CreateRoomListUI를 해준다 
//->코루틴 사용 !! 
public class NormalRoomItem : MonoBehaviour
{
    //방 제목
    //public TMP_Text roomName;

    //방 수익률
    //public TMP_Text roomYield;


    //IEnumerator Test()
    //{
    //    //이 안에, GetRoomAll이랑, NormalCreateRoomListUI 둘 다 들어가야함 ! 

    //    HttpRequester requester = new HttpRequester();

    //    requester.url = "http://3.34.133.115:8080/shareholder-room";
    //    requester.requestType = RequestType.GET;
    //    requester.onComplete = CompleteGetRoomListAll;


    //    print("CreateRoomListUI 생성 함수 들어옴!");


    //    int count = 0;

    //    print("dataCount : " + dataCount);
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //    }
    //    HttpManager.instance.SendRequest(requester);

    //    //NormalCreateRoomListUI();
    //    print("CreateRoomListUI 생성 함수 시작");

    //    //yield return StartCoroutine(GetRoomAll());
    //    //yield return StartCoroutine(NormalCreateRoomListUI());

    //}

    void Start()
    {
        //StartCoroutine("Test");
       // print("코루틴 함수 시작");
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

    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        RoomDataArray array = JsonUtility.FromJson<RoomDataArray>(handler.text);

        //전역 변수에 저장
        dataCount = array.data.Count;
        //print("dataCount: " + dataCount);

        
        CreateRoom();

        //for (int i = 0; i < dataCount; i++)
        //{
        //    int count = 0;
        //    GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
        //    print("생성됨!");
        //}

        for (int i = 0; i < array.data.Count; i++)
        {
            //print(array.data[i].roomTitle);
            //print(array.data[i].roomYield);
            //print("조회 완료");
        }
    }

    public void CreateRoom()
    {

        int count = 0;
        for (int i = 0; i < dataCount; i++)
        {
            GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
            count++;
            print("생성됨!");
        }
    }

    public int dataCount;


    // 2. 방 만들기
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    public List<Transform> spawnPos;

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
