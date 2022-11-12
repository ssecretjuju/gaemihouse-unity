using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//로그인창에 아이디,비밀번호를 입력하고 서버에 json으로 보낸다
//서버에 내가 보낼 정보들
[Serializable]
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

//로그인 버튼을 눌렀을때
//내가 서버에서 가져와야할 회원정보들
[Serializable]
public class PlayerData
{
    public string memberCode;
    public string memberNickname;
    public string stockCareer;
    public string data; //수익률 data

}



public class LoginManager : MonoBehaviour
{
    public InputField id;
    public InputField password;
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
    }

    public void OnCilckDownload(DownloadHandler handler)
    {
        PostTokenData postTokenData = JsonUtility.FromJson<PostTokenData>(handler.text);

        print(postTokenData.accessToken);

        PlayerPrefs.SetString("token", postTokenData.accessToken);

        print("조회 완료");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
