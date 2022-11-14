using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;
using System;

//�ٸ� �÷��̾ Ŭ���ϸ� �˾� �����찡 Ȱ��ȭ�ȴ� -> DoublcClick ��ũ��Ʈ���� ��
//�˾� �����쿡 ���� �÷��̾� ����: �ֽİ��, ��ռ��ͷ�
//�÷��̾� �ڽ��� ������ ������� �ʴ´�.

public class PlayerInfoWindow : MonoBehaviour
{
    public GameObject DoubleClick;
    public GameObject playerInfoWindow;
    public GameObject ChatCanvas;
    public Text nickName;
    public Text carrerText;
    public Text yieldText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerWindow()
    {
        //�˾�â�� Ȱ��ȭ
        playerInfoWindow.SetActive(true);
        print("�Ѡ���");
        print("data :" + LoginManager.Instance.playerData.yield);
        
        carrerText.text = LoginManager.Instance.playerData.stockCareer;

        float yield = float.Parse(LoginManager.Instance.playerData.yield);
        print(yield);
        //yield = Math.Round(yield, 3);
        yieldText.text = yield + "%";
        nickName.text = LoginManager.Instance.playerData.memberNickname;

        //ȸ�������� ����Ǿ��ִ� ���, ���ͷ� �ؽ�Ʈ ����ȭ
        //LoginManager.Instance.playerData.yield = yieldText.text;





    }
    public void OnEscBtn()
    {
        playerInfoWindow.SetActive(false);
    }

    public void OnChatBtn()
    {
        ChatCanvas.SetActive(true);
    }
}
