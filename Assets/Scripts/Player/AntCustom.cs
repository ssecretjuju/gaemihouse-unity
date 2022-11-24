using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;

// ������ Ŀ���� ����
[Serializable]
public class CustomData
{
    public string colorMemberNickname;
    public int faceType;
    public int bodyType;
    public int accType;
}

[Serializable]
public class ResponseCustomData
{
    public int status;
    public string message;
    public CustomData data;
}
public class AntCustom : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "LYJ_LobbyScene")
        {
            //CustomCanvas.SetActive(false);
            print("�κ��");
            //onGetCustomData();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CustomData customdata;
    public string colorMemberNickname;

    public void onGetCustomData()
    {
        colorMemberNickname = LoginManager.Instance.playerData.memberNickname;
        print(colorMemberNickname);

        //������ ����� Ŀ���Ұ����� �����´�.
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/avatar" + colorMemberNickname; 
        requester.requestType = RequestType.GET;

        requester.onComplete = OnLoadCustom;

        HttpManager.instance.SendRequest(requester);
        print("Ŀ���� ���� �� �Ϸ�!");
    }


    public void OnLoadCustom(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);
        print("custom data : " + data);

        ResponseCustomData responseCustomData = JsonUtility.FromJson<ResponseCustomData>(data);

        customdata = responseCustomData.data;

        print(customdata.colorMemberNickname);

    }

}
