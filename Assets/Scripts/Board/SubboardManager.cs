using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���� �� ���� �ٸ������ �� �� �ְ� ����ȭ -> BoardItem�� ��ũ��Ʈ?

public class SubboardManager : MonoBehaviour
{

    public GameObject SubwriteWindow;
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
    public GameObject confirmWindow;

    public Text confirmTitleText;


    int count = 0;
    public Text likeCountText;


    void Start()
    {
        //confirmBtn.onClick.AddListener(OnClickSubboard);
    }
    //write��ư�� ������ �۾���â�� ���. inputfield ������ �ʱ�ȭ���ش�.

    public void OnClickWriteBtn()
    {
        SubwriteWindow.SetActive(true);
        SubboardCanvas.SetActive(false);

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

        //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
        InputField title = Item.transform.GetChild(0).GetComponent<InputField>();
        Text content = GameObject.Find("content").GetComponent<Text>();
        Text confirmTitle = GameObject.Find("Title").GetComponent<Text>();
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

    public void OnClickSubboard()
    {
        //���� ������ ����,�г���,��¥,������ ǥ�õǾ��ִ� â�� ���.
        confirmWindow.SetActive(true);
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

    public void OnEscBtn()
    {
        SubboardCanvas.SetActive(false);
    }

}
