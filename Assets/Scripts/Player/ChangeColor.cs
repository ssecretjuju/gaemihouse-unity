using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//Save ��ư -> Ŀ���������� ������ ������ �� ����г��ӿ� Ŀ����Ÿ�� ������ �����Ѵ�.
//GO ��ư -> ���������� �̵��Ѵ�
//�÷��̾� ��ũ��Ʈ- �������� Ŀ���������� ���ؼ� �� ���� �°� ������ ������ ������ �Լ��ۼ� (Loadmodel)
//���� �α��� �� �̹� Ŀ���Ұ����� ����Ǿ��ִ� ���̵��� �α��� �� �ٷ� �κ�� �� ��������� �̵�
//���� ó�� �α���(Ŀ���Ұ���)�̸� Ŀ���Ҿ����� �̵�

[Serializable]
public class PlayerCustomInfo
{
    public string colorMemberNickname;   
    public int faceType;
    public int bodyType;
    public int accType;
}

public class ChangeColor : MonoBehaviour
{
    public static ChangeColor instance;

    //�÷��̾� �г���
    public Text UserNickname;


   public Toggle m_Toggle;

    //�÷��̾��� �� ����
    public int FaceType;
    public int BodyType;
    public int AccType;

    public List<Toggle> toggleList;
    public List<Toggle> toggleList2;
    public List<Toggle> toggleList3;
    // 0= ����, 1= Ȳ�� ...




    void Start()
    {
        AntCustom.instance.faceType[0].SetActive(true);
        AntCustom.instance.bodyType[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //FACE
        toggleList[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(true);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 0;
        });

        toggleList[1].onValueChanged.AddListener(delegate
        {

            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(true);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 1;
        });

        toggleList[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(true);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 2;
        });

        toggleList[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(true);
            FaceType = 3;
        });
        //BODY
        toggleList2[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(true);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 0;
        });

        toggleList2[1].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(true);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 1;
        });

        toggleList2[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(true);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 2;
        });

        toggleList2[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(true);
            BodyType = 3;

        });
        //ACC
        toggleList3[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 0;
        });

        toggleList3[1].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(true);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 1;
        });

        toggleList3[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(true);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 2;
        });

        toggleList3[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(true);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 3;
        });

        toggleList3[4].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(true);
            AccType = 4;
        });

    }

    ////public void OnClickTypeChange()
    ////{
    ////    for (int i = 0; i < faceType.Length; i++)
    ////    {
    ////        faceType[i].SetActive(false);
    ////    }
    ////    faceType[FaceType].SetActive(true);

    ////    for (int i = 0; i < bodyType.Length; i++)
    ////    {
    ////        bodyType[i].SetActive(false);
    ////    }
    ////    bodyType[BodyType].SetActive(true);

    //}

    public void OnClickSaveCustomData()
    {
        PlayerCustomInfo customdata = new PlayerCustomInfo();
        customdata.faceType = FaceType;
        customdata.bodyType = BodyType;
        customdata.accType = AccType;
        customdata.colorMemberNickname = LoginManager.Instance.playerData.memberNickname;
                                                
        //playerdata.memberAvatarImage = File.ReadAllBytes(Application.persistentDataPath + "/Resources/AvatarImage/avatar0.png");

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/avatar";
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(customdata, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);

    }

    public void Gobtn()
    {
        SceneManager.LoadScene("LYJ_LobbyScene");
    }
}