using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    //���̸� InputField
    public InputField inputRoomName;
    //��й�ȣ InputField
    public InputField inputPassword;
    //���ο� InputField
    public InputField inputMaxPlayer;
    //������ Button
    public Button btnJoin;
    //����� Button
    public Button btnCreate;

    //���� ������   
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    //�� ����Ʈ Content
    public Transform trListContent;
    public Transform trListContent1;
    public Transform trListContent2;
    //public Transform trListContent;
    //pblic Transform FirstPosition;

    public GameObject roomItemFactory;
    public GameObject roomItemFactory2;
    //public GameObject HouseFactory;
    
    //map Thumbnail
    public GameObject[] mapThumbs;
   
    

    void Start()
    {        
        // ���̸�(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
        inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
        // ���ο�(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
        inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);


        //string[] s = Microphone.devices;


    }

    public void OnRoomNameValueChanged(string s)
    {
        //����
        btnJoin.interactable = s.Length > 0;
        //����
        btnCreate.interactable = s.Length > 0 && inputMaxPlayer.text.Length > 0;
    }

    public void OnMaxPlayerValueChanged(string s)
    {
        //����
        btnCreate.interactable = s.Length > 0 && inputRoomName.text.Length > 0;
    }
   

    //�� ����
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
        hash["desc"] = "���ͷ� : " + Random.Range(-100, 100) + "%";
        hash["map_id"] = Random.Range(0, mapThumbs.Length);
        hash["room_name"] = inputRoomName.text;
        hash["password"] = inputPassword.text;
        roomOptions.CustomRoomProperties = hash;
        // custom ������ �����ϴ� ����
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "desc", "map_id", "room_name", "password"
        };
                
        // �� ���� ��û (�ش� �ɼ��� �̿��ؼ�)
        PhotonNetwork.CreateRoom(inputRoomName.text + inputPassword.text, roomOptions);
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

    //�� ���� ��û
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(inputRoomName.text + inputPassword.text);
    }

    //�� ������ �Ϸ� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("GameScene");
    }

    //�� ������ ���� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

    //�濡 ���� ������ ����Ǹ� ȣ�� �Ǵ� �Լ�(�߰�/����/����)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        //�븮��Ʈ UI �� ��ü����
        DeleteRoomListUI();
        //�븮��Ʈ ������ ������Ʈ
        UpdateRoomCache(roomList);
        //�븮��Ʈ UI ��ü ����
        CreateRoomListUI();
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

        for(int i = 0; i < roomList.Count; i++)
        {
            // ����, ����
            if(roomCache.ContainsKey(roomList[i].Name))
            {
                //���࿡ �ش� ���� �����Ȱ��̶��
                if(roomList[i].RemovedFromList)
                {
                    //roomCache ���� �ش� ������ ����
                    roomCache.Remove(roomList[i].Name);
                }
                //�׷��� �ʴٸ�
                else
                {
                    //���� ����
                    roomCache[roomList[i].Name] = roomList[i];
                }
            }
            //�߰�
            else
            {
                roomCache[roomList[i].Name] = roomList[i];
            }
        }

        //for (int i = 0; i < roomList.Count; i++)
        //{
        //    // ����, ����
        //    if (roomCache.ContainsKey(roomList[i].Name))
        //    {
        //        //���࿡ �ش� ���� �����Ȱ��̶��
        //        if (roomList[i].RemovedFromList)
        //        {
        //            //roomCache ���� �ش� ������ ����
        //            roomCache.Remove(roomList[i].Name);
        //            continue;
        //        }                
        //    }
        //    roomCache[roomList[i].Name] = roomList[i];            
        //}
    }

    
    void CreateRoomListUI()
    {
        foreach(RoomInfo info in roomCache.Values)
        {
            // print("inputRoomName : " + inputRoomName);
            // print("inputRoomName : " + inputRoomName.text);
            // print("(string)info.CustomProperties.desc : " + (string)info.CustomProperties["desc"]);
            // print("(string)info.CustomProperties.info : " + (string)info.CustomProperties["room_name"]);
            // print("info.CustomProperties.desc : " + info.CustomProperties["desc"]);

            // 방 이름 기본 : 집 만들어짐
            // 그 외 : 작은 집 만들어짐 
            
            if ((string)info.CustomProperties["room_name"] == "기본")
            {
                //������� �����.
                GameObject go = Instantiate(roomItemFactory, trListContent);
                //������� ������ ����(������(0/0))
                RoomItem item = go.GetComponent<RoomItem>();
                item.SetInfo(info);
                item.onClickAction = SetRoomName;
            }
            else
            {
                GameObject go = Instantiate(roomItemFactory2, trListContent);
                //������� ������ ����(������(0/0))
                RoomItem item = go.GetComponent<RoomItem>();
                item.SetInfo(info);
                item.onClickAction = SetRoomName;
            }
                
            
                
                
            
            
            

            //roomItem ��ư�� Ŭ���Ǹ� ȣ��Ǵ� �Լ� ���
            //item.onClickAction = SetRoomName;
            //���ٽ�
            //item.onClickAction = (string room) => {
            //    inputRoomName.text = room;
            //};

            string desc = (string)info.CustomProperties["desc"];
            int map_id = (int)info.CustomProperties["map_id"];
            print(desc + ", " + map_id);
        }
    }


    //���� Thumbnail id
    int prevMapId = -1;
    void SetRoomName(string room, int map_id)
    {
        //���̸� ����
        inputRoomName.text = room;

        //���࿡ ���� �� Thumbnail�� Ȱ��ȭ�� �Ǿ��ִٸ�
        if(prevMapId > -1)
        {
            //���� �� Thumbnail�� ��Ȱ��ȭ
            mapThumbs[prevMapId].SetActive(false);
        }

        //�� Thumbnail ����
        mapThumbs[map_id].SetActive(true);

        //���� �� id ����
        prevMapId = map_id;
    }
}
