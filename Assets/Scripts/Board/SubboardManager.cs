using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;


// ������ ���� �Ķ����
public class RoomboardInsertInfo
{
    public int roomBoardCode;
    public string roomBoardTitle;
    public string roomBoardContent;
    public DateTime roomBoardRegistDate;
    public int roomBoardMemberCode;
    public int shareholderRoomCode;
    public int likeCount;
}

// �޴� ������
public class ResponseRoomboard
{
    public int status;
    public string message;
    public RoomboardInsertInfo data;
}



public class SubboardManager : MonoBehaviour
{

    public GameObject SubwriteWindow;
    public GameObject confirmWindow;
    public InputField inputTitle;
    public InputField inputContent;
    public Text nickName;
    //��¥�ؽ�Ʈ-
    public Button writeBtn;
    public Button oKBtn;
    public Button cancelBtn;
    //public Button confirmBtn;
    public GameObject Subboard;
    public Transform boardItemParent;
    public GameObject SubboardCanvas;
    

    public Text confirmTitleText;


    int count = 0;
    public Text likeCountText;


    void Start()
    {
        //confirmBtn.onClick.AddListener(OnClickSubboard);
        confirmWindow.SetActive(false);
       
    }
    //write��ư�� ������ �۾���â�� ���. inputfield ������ �ʱ�ȭ���ش�.

    public void OnClickWriteBtn()
    {
        SubwriteWindow.SetActive(true);      

        //�ٽ� ������ �� �ʱ�ȭ
        if (inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
            ;
        }
    }

    //Ok��ư�� ������ boarditem�� �����Ǿ� ���ĵȴ�.
    //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
    //��ũ��â ����, ������ �Ʒ��� �����ǰ�
    //���� 10���� �Ѿ�� ����������(1������,2������..)�� �����ȴ�.(����)
    public void OnClickOkBtn()
    {
        SubboardCanvas.SetActive(true);

        GameObject Item = Instantiate(Subboard, boardItemParent);

        confirmWindow = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;

        //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
        InputField title = Item.transform.GetChild(0).GetComponent<InputField>();      
        Text content = confirmWindow.transform.GetChild(1).GetComponent<Text>();
        Text confirmTitle = confirmWindow.transform.GetChild(0).GetComponent<Text>();
        Text nickname = Item.transform.GetChild(1).GetComponent<Text>();
        Text date = Item.transform.GetChild(2).GetComponent<Text>();


        confirmTitle.text = inputTitle.text;
        title.text = inputTitle.text;
        content.text = inputContent.text;
        //nickname.text = LoginManager.Instance.playerData.memberNickname;

        string yy = System.DateTime.Now.ToString("yyyy");
        string mm = System.DateTime.Now.ToString("MM");
        string dd = System.DateTime.Now.ToString("dd");

        date.text = yy + "-" + mm + "-" + dd;

        //�۾��� ������ ������
        RoomboardInsertInfo data = new RoomboardInsertInfo();
        data.roomBoardCode = 0;
        data.roomBoardTitle = title.text;
        data.roomBoardContent = content.text;
        data.roomBoardMemberCode = LoginManager.Instance.playerData.memberCode;
        data.shareholderRoomCode = 0;
        data.likeCount = 0;

    HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/roomBoard/insert";
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        //requester.onComplete = OnCilckDownload;

        HttpManager.instance.SendRequest(requester);
       
        //���� ������ �Է��ϰ� ok��ư�� Ŭ���ϸ� �۾���â�� ������.
        if (inputTitle.text != null && inputContent.text != null)
        {
            SubwriteWindow.SetActive(false);

        }

    }


    //back��ư ������ �۾���â�� �������

    public void OnClickLike()
    {
        //count = count + 1;

        //string countNumber = count.ToString();

        //likeCountText.text = countNumber;


    }

    public void OnClickBackBtn()
    {
        SubwriteWindow.SetActive(false);
        SubboardCanvas.SetActive(true);
    }

    //x��ư ������ �� �Խ����� ������
    //x��ư ������ ����,����,����ڵ�,���ڵ尡 ������ ���۵ȴ�.


    public void OnEscBtn()
    {
        SubboardCanvas.SetActive(false);

    }

}
