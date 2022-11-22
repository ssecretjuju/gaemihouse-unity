using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorInfo
{
    public int faceType;
    public int bodyType;
}

public class ChangeColor : MonoBehaviour
{
    public static ChangeColor instance;

    //�÷��̾� �г���
    public Text UserNickname;

    public GameObject[] faceType;

    public GameObject[] bodyType;

   public Toggle m_Toggle;

    //�÷��̾��� �� ����
    public int FaceType;
    public int BodyType;

    public List<Toggle> toggleList;
    // 0= ����, 1= Ȳ�� ...

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {

        toggleList[1].onValueChanged.AddListener(Blackchange);

        //toggleList[1].onValueChanged.AddListener(delegate
        //{
        //    print("ssss");
        //    faceType[0].SetActive(false);
        //    faceType[1].SetActive(true);
        //    faceType[2].SetActive(false);
        //    faceType[3].SetActive(false);
        //});
    }

    public void Blackchange(bool boolean)
    {
        faceType[1].SetActive(boolean);
        Debug.Log("tlqkf");
    }

    // Update is called once per frame
    void Update()
    {

        OnClickTypeChange();
    }

    public void OnClickTypeChange()
    {
        for (int i = 0; i < faceType.Length; i++)
        {
            faceType[i].SetActive(false);
        }
        faceType[FaceType].SetActive(true);

        for (int i = 0; i < bodyType.Length; i++)
        {
            bodyType[i].SetActive(false);
        }
        bodyType[BodyType].SetActive(true);

    }

    //public void OnClickSaveCustomData()
    //{
    //    PlayerColorInfo colordata = new PlayerColorInfo();
    //    colordata.faceType = FaceType;
    //    colordata.bodyType = BodyType;

    //    //playerdata.memberAvatarImage = File.ReadAllBytes(Application.persistentDataPath + "/Resources/AvatarImage/avatar0.png");

    //    HttpRequester requester = new HttpRequester();
    //    requester.url = "http://52.79.209.232:8080/api/v1/avatar/create";
    //    requester.requestType = RequestType.POST;

    //    requester.postData = JsonUtility.ToJson(colordata, true);
    //    print(requester.postData);

    //    HttpManager.instance.SendRequest(requester);

    //}
}