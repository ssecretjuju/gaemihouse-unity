using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���� �� ���� �ٸ������ �� �� �ְ� ����ȭ -> BoardItem�� ��ũ��Ʈ?

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
    public Canvas boardCanvas;




    //write��ư�� ������ �۾���â�� ���. inputfield ������ �ʱ�ȭ���ش�.
    
    public void OnClickWriteBtn()
    {
        writeWindow.SetActive(true);

        //�ٽ� ������ �� �ʱ�ȭ
        if(inputTitle.text != null && inputContent.text != null)
        {
            inputTitle.text = "";
            inputContent.text = "";
;        }
    }

    //Ok��ư�� ������ boarditem�� �����Ǿ� ���ĵȴ�.
    //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
    //��ũ��â ����, ������ �Ʒ��� �����ǰ�
    //���� 10���� �Ѿ�� ����������(1������,2������..)�� �����ȴ�.(����)
    public void OnClickOkBtn()
    {
        GameObject Item = Instantiate(boardItem, boardItemParent);

        //writeâ�� inputfield ����� prefab inputfield ������ ����ȭ�Ѵ�.
        InputField title = Item.transform.GetChild(0).GetComponent<InputField>();
        InputField content = Item.transform.GetChild(1).GetComponent<InputField>();

        title.text = inputTitle.text;
        content.text = inputContent.text;

        //���� ������ �Է��ϰ� ok��ư�� Ŭ���ϸ� �۾���â�� ������.
        if(inputTitle.text != null && inputContent.text != null)
        {
            writeWindow.SetActive(false);
        }

    }

    //back��ư ������ �۾���â�� �������

    public void OnClickBackBtn()
    {
        writeWindow.SetActive(false);
    }

    //x��ư ������ �� �Խ����� ������

    public void OnEscBtn()
    {
        boardCanvas.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
