using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



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
