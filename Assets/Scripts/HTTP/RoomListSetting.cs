using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;

[Serializable]
public class roomPostInfo
{
    public string roomTitle;
    public int roomLimitedNumber;
}

[Serializable]
public class roomDeleteInfo
{
    public string roomTitle;
}

[Serializable]
public class roomHolderInfo
{
    public int memberCode;
}


public class RoomListSetting : MonoBehaviourPunCallbacks
{
    //���̸� InputField
    public InputField inputRoomName;
    //���ο� InputField
    public InputField inputMaxPlayer;

    //����� Button
    public Button btnCreate;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRoom());
        // ���̸�(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
        //inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
        // ���ο�(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
        //inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);

    }

    public void OnRoomNameValueChanged(string s)
    {
        //����
        btnCreate.interactable = s.Length > 0 && inputMaxPlayer.text.Length > 0;
    }

    public void OnMaxPlayerValueChanged(string s)
    {
        //����
        btnCreate.interactable = s.Length > 0 && inputRoomName.text.Length > 0;
    }


    public void PostRoomInfoClick()
    {
        roomPostInfo data = new roomPostInfo();
        data.roomTitle = inputRoomName.text;
        //data.roomYield = float.Parse(inputReturn.text);
        data.roomLimitedNumber = int.Parse(inputMaxPlayer.text);
        // data.isOpen = true;
        // List<string> roomMember = new List<string>();

        HttpRequester requester = new HttpRequester();
        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.POST;
        print("Post test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);
        print("Post �Ϸ�!");
    }

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
        //hash["desc"] = int.Parse(inputReturn.text);
        //hash["desc"] = float.Parse(inputReturn.text);

        hash["room_name"] = inputRoomName.text;
        print("��ǲ �̸�: " + inputRoomName.text);
        print("���̸�:" + hash["room_name"]);
        //inputReturn = 0;
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

        // �� ���� ��û (�ش� �ɼ��� �̿��ؼ�)
        print(2222222);

        OnClickConnect();


        //PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
        //print(PhotonNetwork.CurrentRoom.Name);
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
        //PhotonNetwork.JoinLobby();
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

        PhotonNetwork.JoinOrCreateRoom(inputRoomName.text, roomOptions, TypedLobby.Default);
    }

    public void OnClickConnect()
    {
        //���� ���� ��û
        PhotonNetwork.ConnectUsingSettings();
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
    }

    //�� ������ ���� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator GetRoom()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    //�� ���� ��, ���� ������ �Ѱ��ְ� �ʹ�.
    //IEnumerator OnClickHolder()
    //{
    //    HttpRequester requester = new HttpRequester();
    //    requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room" + holder.memberCode;
    //    print(requester.url);
    //    requester.requestType = RequestType.POST;

    //    roomHolderInfo data = new roomHolderInfo();
    //    data.memberCode = LoginManager.Instance.playerData.memberCode;
    //    print(LoginManager.Instance.playerData.memberCode);
    //    print(data);
    //    print(data.memberCode);


    //    print("test");

    //    requester.postData = JsonUtility.ToJson(data, true);
    //    print(requester.postData);


    //    ///////////
    //    requester.onComplete = OnCompleteHolder;
    //    HttpManager.instance.SendRequest(requester);
    //}

    public void OnCompleteHolder(DownloadHandler handler)
    {
        
    }


    public InputField roomName;

    //IEnumerator OnClickDeleteRoom()
    //{
    //    UnityWebRequest www = UnityWebRequest.Get("http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room");
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        // Show results as text
    //        Debug.Log(www.downloadHandler.text);

    //        // Or retrieve results as binary data
    //        byte[] results = www.downloadHandler.data;
    //    }
    //}

    //roomTitle, roomDeleteInfo

    public RoomData roomData;
    public void OnClickDelete()
    {
        roomDeleteInfo data = new roomDeleteInfo();
        data.roomTitle = roomName.text;
        print("�����Ϸ��� �� �̸� : " + roomName.text);
        

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room" +roomName.text;
        print(requester.url);
        requester.requestType = RequestType.DELETE;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        //requester.onComplete = OnCilckDownload;


        HttpManager.instance.SendRequest(requester);

        //requester.postData = JsonUtility.ToJson(data, true);
        //print(requester.postData);


        //requester.onComplete = OnCilckDownload;


        //HttpManager.instance.SendRequest(requester);
    }

    //public void OnCilckDownload(DownloadHandler handler)
    //{
    //    string data = System.Text.Encoding.Default.GetString(handler.data);

    //    print("data : " + data);

    //    //ResponseData responseData = JsonUtility.FromJson<ResponseData>(data);

    //    //roomData = responseData.data;

    //    //print(playerData.yield);


    //    //PlayerPrefs.SetString("token", playerData.accessToken);

    //    print("��ȸ �Ϸ�");
    //}

}
