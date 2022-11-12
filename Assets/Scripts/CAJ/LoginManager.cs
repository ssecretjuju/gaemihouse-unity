using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[Serializable]
public class UserInfo
{
    public int memberCode;
    public string memberId;
    public string memberName;
    public string memberNickname;
    public string memberPassword;
    public string password;
    public string stockCareer;
    public string stockFirm;
    
}

public class LoginInfo
{
    public string memberId;
    public string memberPassword;
}


[Serializable]
public class PostTokenData
{
    public string accessToken;
}


public class LoginManager : MonoBehaviour
{
    //로그인
    public InputField id;
    public InputField password;
    
    //로그인
    public void OnClickLogin()
    {
        LoginInfo data = new LoginInfo();
        data.memberId = id.text;
        data.memberPassword = password.text;
        
        HttpRequester requester = new HttpRequester();
        requester.url = "http://3.34.133.115:8080/auth/login";
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        
        requester.onComplete = OnCilckDownload;
        
        
        HttpManager.instance.SendRequest(requester);
        //HttpManager.instance.
        
        
        //if(webRequest.result == UnityWebRequest.Result.Success)

        // if (requester.postData.Contains("성공"))
        // {
        //     LoginFail.SetActive(true);
        // }
        //if(BatteryStatus )
        //print("sendrequest 성공");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSave()
    {
        // UserInfo data = new UserInfo();
        // data.memberId = memberId.text;
        // data.memberPassword = password.text;
        // data.memberName = memeberName.text;
        // data.memberNickname = memberNickname.text;
        //
        // HttpRequester requester = new HttpRequester();
        // requester.url = "http://3.34.133.115:8080/auth/signup";
        // requester.requestType = RequestType.POST;
        //
        // requester.postData = JsonUtility.ToJson(data, true);
        // print(requester.postData);
        //
        //
        // requester.onComplete = OnCilckDownload;
        //
        //
        // HttpManager.instance.SendRequest(requester);
    }
    
    public void OnCilckDownload(DownloadHandler handler)
    {
        //배열 데이터를 키값에 넣는다.
        //string s = "{\"accessToken\":" + handler.text + "}";

        //List<PostData>
        //PostTokenData postTokenData = JsonUtility.FromJson<PostTokenData>(handler.text);

        //print(postTokenData.accessToken);

        //PlayerPrefs.SetString("token", postTokenData.accessToken);
     
        print("조회 완료");
    }
    //
}
