using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//내가 쓴 글을 다른사람이 볼 수 있게 동기화 -> BoardItem에 스크립트?

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




    //write버튼을 누르면 글쓰기창이 뜬다. inputfield 내용을 초기화해준다.
    
    public void OnClickWriteBtn()
    {
        writeWindow.SetActive(true);
        boardCanvas.SetActive(false);

        //다시 눌렀을 때 초기화
        if (inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
;        }
    }

    //Ok버튼을 누르면 boarditem이 형성되어 정렬된다.
    //write창의 inputfield 내용과 prefab inputfield 내용을 동기화한다.
    //스크롤창 관리, 위에서 아래로 형성되게
    //글이 10개가 넘어가면 다음페이지(1페이지,2페이지..)가 형성된다.(보류)
    public void OnClickOkBtn()
    {
        boardCanvas.SetActive(true);

        GameObject Item = Instantiate(boardItem, boardItemParent);

        //write창의 inputfield 내용과 prefab inputfield 내용을 동기화한다.
        InputField title = Item.transform.GetChild(0).GetComponent<InputField>();
        InputField content = Item.transform.GetChild(1).GetComponent<InputField>();

        title.text = inputTitle.text;
        content.text = inputContent.text;

        //만약 내용을 입력하고 ok버튼을 클릭하면 글쓰기창이 닫힌다.
        if (inputTitle.text != null && inputContent.text != null)
        {
            writeWindow.SetActive(false);
            
        }

    }

    //back버튼 누르면 글쓰기창이 사라진다

    public void OnClickBackBtn()
    {
        writeWindow.SetActive(false);
        boardCanvas.SetActive(true);
    }

    //x버튼 누르면 글 게시판이 닫힌다

    public void OnEscBtn()
    {
        boardCanvas.SetActive(false);
    }
    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            boardCanvas.SetActive(true);
        }
    }
}
