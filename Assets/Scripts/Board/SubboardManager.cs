using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���� �� ���� �ٸ������ �� �� �ְ� ����ȭ -> BoardItem�� ��ũ��Ʈ?


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
        
        //���� ������ �Է��ϰ� ok��ư�� Ŭ���ϸ� �۾���â�� ������.
        if (inputTitle.text != null && inputContent.text != null)
        {
            SubwriteWindow.SetActive(false);

        }

    }


    //back��ư ������ �۾���â�� �������

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

    //x��ư ������ �� �Խ����� ������
    //x��ư ������ ����,����,����ڵ�,���ڵ尡 ������ ���۵ȴ�.


    public void OnEscBtn()
    {
        SubboardCanvas.SetActive(false);

    }

}
