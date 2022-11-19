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
    public GameObject Subboard;
    public Transform boardItemParent;
    public GameObject SubboardCanvas;




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
        //InputField content = Item.transform.GetChild(1).GetComponent<InputField>();

        title.text = inputTitle.text;
        //content.text = inputContent.text;

        //���� ������ �Է��ϰ� ok��ư�� Ŭ���ϸ� �۾���â�� ������.
        if (inputTitle.text != null && inputContent.text != null)
        {
            SubwriteWindow.SetActive(false);

        }

    }

    public void OnClickSubboard()
    {
        //���� ������ ����,�г���,��¥,������ ǥ�õǾ��ִ� â�� ���.


    }
    //back��ư ������ �۾���â�� �������

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
    void Start()
    {

    }


}
