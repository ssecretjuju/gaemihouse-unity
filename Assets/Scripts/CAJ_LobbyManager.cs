using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CAJ_LobbyManager : MonoBehaviourPunCallbacks
{
    //수익률 InputField
    public InputField inputReturn;

    //최대 방 개수 (0~10)
    public int LimitMaxRoom = 10;
    
    //방이름 InputField
    public InputField inputRoomName;
    //총인원 InputField
    public InputField inputMaxPlayer;
    //방참가 Button
    public Button btnJoin;
    //방생성 Button
    public Button btnCreate;

    //방의 정보들   
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    //룸 리스트 Content
    public List<Transform> PosList;
    
    
    public Transform trListContent;

    //map Thumbnail
    public GameObject[] mapThumbs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //방 생성
    public void CreateRoom()
    {
        // 방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        // 최대 인원 (0이면 최대인원)
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        // 룸 리스트에 보이지 않게? 보이게?
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        // custom 정보를 셋팅
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        
        hash["room_name"] = inputRoomName.text;
        hash["room_return"] = inputReturn.text;
        hash["max_player"] = inputMaxPlayer.text;
        
        roomOptions.CustomRoomProperties = hash;
        // custom 정보를 공개하는 설정
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "room_name", "room_return", "max_player"
        };
                
        // 방 생성 요청 (해당 옵션을 이용해서)
        //PhotonNetwork.CreateRoom(inputRoomName.text + inputPassword.text, roomOptions);
        PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
        print("roomOptions : " + roomOptions);
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

    //방 참가 요청
    public void JoinRoom()
    {
        //PhotonNetwork.JoinRoom(inputRoomName.text + inputPassword.text);
        PhotonNetwork.JoinRoom(inputRoomName.text);
    }

    //방 참가가 완료 되었을 때 호출 되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("CAJ_RoomScene");
    }

    //방 참가가 실패 되었을 때 호출 되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

    //방에 대한 정보가 변경되면 호출 되는 함수(추가/삭제/수정)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        //룸리스트 UI 를 전체삭제
        DeleteRoomListUI();
        //룸리스트 정보를 업데이트
        UpdateRoomCache(roomList);
        //룸리스트 UI 전체 생성
        CreateRoomListUI(roomList);
    }

    void DeleteRoomListUI()
    {
        foreach(Transform tr in trListContent)
        {
            Destroy(tr.gameObject);
        }
    }

    void UpdateRoomCache(List<RoomInfo> roomList)
    {

        for (int i = 0; i < roomList.Count; i++)
        {
            // 수정, 삭제
            if (roomCache.ContainsKey(roomList[i].Name))
            {
                //만약에 해당 룸이 삭제된것이라면
                if (roomList[i].RemovedFromList)
                {
                    //roomCache 에서 해당 정보를 삭제
                    roomCache.Remove(roomList[i].Name);
                }
                //그렇지 않다면
                else
                {
                    //정보 수정
                    roomCache[roomList[i].Name] = roomList[i];
                }
            }
            //추가
            else
            {
                roomCache[roomList[i].Name] = roomList[i];
            }
        }
    }

    public GameObject roomItemFactory;
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    void CreateRoomListUI(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomCache.Values)
        {
            print("roomName : " + (string)info.CustomProperties["room_name"]);
            for (int i = 0; i < LimitMaxRoom; i++)
            {
                GameObject go = Instantiate(roomItemFactory, PosList[i]);
                //룸아이템 정보를 셋팅(방제목(0/0))
                CAJ_RoomItem item = go.GetComponent<CAJ_RoomItem>();
                item.SetInfo(info);
            
                //roomItem 버튼이 클릭되면 호출되는 함수 등록
                item.onClickAction = SetRoomName;
                //람다식
                //item.onClickAction = (string room) => {
                //    inputRoomName.text = room;
                //};
            
                //string desc = (string)info.CustomProperties["desc"];
                //int map_id = (int)info.CustomProperties["map_id"];

                float room_return = (float)info.CustomProperties["room_return"];
                int max_player = (int)info.CustomProperties["max_player"];
                
                print("info.CustomProperties : " + info.CustomProperties);
                print("room_return , max_player" + room_return + ", " + max_player);
            }
        }
    }


    //이전 Thumbnail id
    int prevMapId = -1;
    void SetRoomName(string room, int map_id)
    {
        //룸이름 설정
        inputRoomName.text = room;

        //만약에 이전 맵 Thumbnail이 활성화가 되어있다면
        if(prevMapId > -1)
        {
            //이전 맵 Thumbnail을 비활성화
            mapThumbs[prevMapId].SetActive(false);
        }

        //맵 Thumbnail 설정
        mapThumbs[map_id].SetActive(true);

        //이전 맵 id 저장
        prevMapId = map_id;
    }

}
