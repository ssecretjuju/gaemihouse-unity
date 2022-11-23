using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//내가 쓴 글을 다른사람이 볼 수 있게 동기화 -> BoardItem에 스크립트?


public class SubboardManager : MonoBehaviour
{

    public GameObject SubwriteWindow;
    public GameObject confirmWindow;
    public InputField inputTitle;
    public InputField inputContent;
    public Text nickName;
    //날짜텍스트-
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
    //write버튼을 누르면 글쓰기창이 뜬다. inputfield 내용을 초기화해준다.

    public void OnClickWriteBtn()
    {
        SubwriteWindow.SetActive(true);      

        //다시 눌렀을 때 초기화
        if (inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
            ;
        }
    }

    //Ok버튼을 누르면 boarditem이 형성되어 정렬된다.
    //write창의 inputfield 내용과 prefab inputfield 내용을 동기화한다.
    //스크롤창 관리, 위에서 아래로 형성되게
    //글이 10개가 넘어가면 다음페이지(1페이지,2페이지..)가 형성된다.(보류)
    public void OnClickOkBtn()
    {
        SubboardCanvas.SetActive(true);

        GameObject Item = Instantiate(Subboard, boardItemParent);

        confirmWindow = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;

        //write창의 inputfield 내용과 prefab inputfield 내용을 동기화한다.
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
        
        //만약 내용을 입력하고 ok버튼을 클릭하면 글쓰기창이 닫힌다.
        if (inputTitle.text != null && inputContent.text != null)
        {
            SubwriteWindow.SetActive(false);

        }

    }


    //back버튼 누르면 글쓰기창이 사라진다

    public void OnClickLike()
    {
        count = count + 1;

        string countNumber = count.ToString();

        likeCountText.text = countNumber;
    }

    public void OnClickBackBtn()
    {
        SubwriteWindow.SetActive(false);
        SubboardCanvas.SetActive(true);
    }

    //x버튼 누르면 글 게시판이 닫힌다
    //x버튼 누르면 제목,내용,멤버코드,룸코드가 서버로 전송된다.


    public void OnEscBtn()
    {
        SubboardCanvas.SetActive(false);

    }

}
