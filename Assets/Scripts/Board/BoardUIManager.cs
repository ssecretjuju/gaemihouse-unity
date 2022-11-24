using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;


//���� �� ���� �ٸ������ �� �� �ְ� ����ȭ -> BoardItem�� ��ũ��Ʈ?
public class BoardInfo
{
    public string communityTitle;
    public string communityContent;
    public int memberCode;
    public int shareholderRoomCode;
}

public class roomInfo
{
    public int roomCode;
}

public class BoardUIManager : MonoBehaviour
{

    public GameObject writeWindow;
    public InputField inputTitle;
    public InputField inputContent;
    public Text nickName;
    public Button writeBtn;
    public Button oKBtn;
    public Button cancelBtn;
    public GameObject boardItem;
    public Transform boardItemParent;
    public GameObject boardCanvas;




    //write��ư�� ������ �۾���â�� ���. inputfield ������ �ʱ�ȭ���ش�.
    
    public void OnClickWriteBtn()
    {
        writeWindow.SetActive(true);
        boardCanvas.SetActive(false);

        //�ٽ� ������ �� �ʱ�ȭ
        if (inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
;        }

        //���ڵ� �����͸� �����´�.
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        print("Post test");

        requester.onComplete = OnClickRoomDownload;

        HttpManager.instance.SendRequest(requester);
        print("���ڵ� �� �Ϸ�!");

    }

    public List<int> roomcodeinfo;
    //public int ss;

    public void OnClickRoomDownload(DownloadHandler handler)
    {
        JSONNode node = JSON.Parse(handler.text);
        roomcodeinfo.Clear();

        for (int i = 0; i < node["data"].Count; ++i)
        {
            //ss = node["data"][i]["roomCode"];
            //print(ss);
            roomcodeinfo.Add(node["data"][i]["roomCode"]);
            print(node["data"][i]["roomCode"]);
        }
    }

    //Ok��ư�� ������ boarditem�� �����Ǿ� ���ĵȴ�.
    //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
    //��ũ��â ����, ������ �Ʒ��� �����ǰ�
    //���� 10���� �Ѿ�� ����������(1������,2������..)�� �����ȴ�.(����)
    public void OnClickOkBtn()
    {
        boardCanvas.SetActive(true);

        GameObject Item = Instantiate(boardItem, boardItemParent);

        //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
        InputField title = Item.transform.GetChild(0).GetComponent<InputField>();
        InputField content = Item.transform.GetChild(1).GetComponent<InputField>();

        title.text = inputTitle.text;
        content.text = inputContent.text;

        //���� ������ �Է��ϰ� ok��ư�� Ŭ���ϸ� �۾���â�� ������.
        if (inputTitle.text != null && inputContent.text != null)
        {
            writeWindow.SetActive(false);
            
        }

        List<int> roomcodeInfo = new List<int>();

        BoardInfo boardData = new BoardInfo();
        boardData.communityTitle = inputTitle.text;
        boardData.communityContent = inputContent.text;
        boardData.memberCode = LoginManager.Instance.playerData.memberCode;

        for (int i = 0; i < roomcodeinfo.Count; ++i)
        {
            boardData.shareholderRoomCode = roomcodeinfo[i];
        }

        

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/community/insert";
        print(requester.url);
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(boardData, true);
        print(requester.postData);


        //requester.onComplete = OnCilckDownload;


        HttpManager.instance.SendRequest(requester);

    }

//back��ư ������ �۾���â�� �������

    public void OnClickBackBtn()
    {
        writeWindow.SetActive(false); 
        boardCanvas.SetActive(true);
    }

    //x��ư ������ �� �Խ����� ������

    public void OnEscBtn()
    {
        boardCanvas.SetActive(false);
    }
    void Start()
    {
        
    }

}
