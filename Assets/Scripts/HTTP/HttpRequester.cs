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
    //요청 타입 (GET, POST, PUT, DELETE)
    public RequestType requestType;

    //Post Data 
    public string postData;//(body)

    //응답이 왔을 때 호출해줄 함수 (Action)
    //Action : 함수를 넣을 수 있는 자료형
    public Action<DownloadHandler> onComplete;


    public string imgUrl;
    ////////////////
    //public Action<UploadHandler> action;
}
