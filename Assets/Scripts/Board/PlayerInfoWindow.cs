using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;

//�ٸ� �÷��̾ Ŭ���ϸ� �˾� �����찡 Ȱ��ȭ�ȴ� -> DoublcClick ��ũ��Ʈ���� ��
//�˾� �����쿡 ���� �÷��̾� ����: �ֽİ��, ��ռ��ͷ�
//�÷��̾� �ڽ��� ������ ������� �ʴ´�.

public class PlayerInfoWindow : MonoBehaviour
{
    public GameObject DoubleClick;
    public Canvas playerInfoWindow;

    public Text carrerText;
    public Text yieldText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //���� �˾�â�� Ȱ��ȭ�ȴٸ�
        if(GameObject.Find("PlayerInfoWindow").GetComponent<DoubleClick>().enabled == true)
        {
            //ȸ�������� ����Ǿ��ִ� ���, ���ͷ� �ؽ�Ʈ ����ȭ

        }
    }

    public void OnEscBtn()
    {
        playerInfoWindow.enabled = false;
    }
}
