using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//HttpRequester : Ʋ 

//�Խù� ����
[System.Serializable]
public class RoomData
{
    public int roomCode;
    public string roomTitle;
    public int roomLimitedNumber;
    public int roomRegistedNumber;
    public int roomYield;
    
}

public class ListenData
{
    public string status;
    public string message;
    public RoomData[] data;
}

[Serializable]
public class RoomDataArray
{
    public List<RoomData> data;
}

public enum RequestType
{
    POST,
    GET,
    PUT,
    DELETE
}


public class HttpRequester : MonoBehaviour
{
    //url
    public string url;
    //��û Ÿ�� (GET, POST, PUT, DELETE)
    public RequestType requestType;

    //Post Data 
    public string postData;//(body)

    //������ ���� �� ȣ������ �Լ� (Action)
    //Action : �Լ��� ���� �� �ִ� �ڷ���
    public Action<DownloadHandler> onComplete;


    public string imgUrl;
    ////////////////
    //public Action<UploadHandler> action;
}
