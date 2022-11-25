using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//�α���â�� ���̵�,��й�ȣ�� �Է��ϰ� ������ json���� ������
//������ ���� ���� ������
[Serializable]
public class LoginInfo
{
    public string memberId;
    public string memberPassword;
}

//�α��� ��ư�� ��������
//���� �������� �����;��� ȸ��������

[Serializable]
public class PlayerData
{
    public int memberCode;
    public string memberId;
    public string memberPassword;
    public string memberRole;
    public string memberNickname;
    public string memberName;
    public string stockFirm;
    public int accountNum;
    public string appKey;
    public string appSecret;
    public string appKeyExpiresin;
    public string termsAgreementYn;
    public int reportCount;
    public string blacklistYn;
    public string stockCareer;
    public string withdrawYn;
    public string authorities;
    public bool enabled;
    public string username;
    public string password;
    public bool accountNonExpired;
    public bool accountNonLocked;
    public bool credentialsNonExpired;
    public string yield;
    public string accessToken;

    //public string data; //���ͷ� data
}

[Serializable]
public class ResponseData
{
    public int status;
    public string message;
    public PlayerData data;
}

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public InputField id;
    public InputField password;
    public PlayerData playerData;

    public void OnClickLogin()
    {
        LoginInfo data = new LoginInfo();
        data.memberId = id.text;
        print(id.text);
        data.memberPassword = password.text;

       
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/member/id/" + id.text;
        print(requester.url);
        requester.requestType = RequestType.GET;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        requester.onComplete = OnCilckDownload;


        HttpManager.instance.SendRequest(requester);
    }

    public void OnCilckDownload(DownloadHandler handler)
    {
        

        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);

        ResponseData responseData = JsonUtility.FromJson<ResponseData>(data);

        playerData = responseData.data;

        print(playerData.yield);
        

        //PlayerPrefs.SetString("token", playerData.accessToken);

        //print("��ȸ �Ϸ�");

        SceneManager.LoadScene("LYJ_CharacterSelection");
    }

    public void CAJ_OnClickLogin()
    {
        LoginInfo data = new LoginInfo();
        data.memberId = id.text;
        print(id.text);
        data.memberPassword = password.text;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/member/id/" + id.text;
        print(requester.url);
        requester.requestType = RequestType.GET;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        requester.onComplete = CAJ_OnCilckDownload;


        HttpManager.instance.SendRequest(requester);
    }

    public void CAJ_OnCilckDownload(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);

        ResponseData responseData = JsonUtility.FromJson<ResponseData>(data);

        playerData = responseData.data;

        print(playerData.yield);


        //PlayerPrefs.SetString("token", playerData.accessToken);

        //print("��ȸ �Ϸ�");

        SceneManager.LoadScene("Test)CAJ_LobbyScene");

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

