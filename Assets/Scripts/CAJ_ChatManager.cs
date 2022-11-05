using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.EventSystems;

public class CAJ_ChatManager : MonoBehaviourPun
{
    //ChatItme ����
    public GameObject chatItemFactory;
    //InputChat 
    public InputField inputChat;
    //ScrollView�� Content transform
    public RectTransform trContent;

    //���� �г��� ����
    Color nickColor;

    void Start()
    {
        //inputChat���� ���͸� ������ �� ȣ��Ǵ� �Լ� ���
        inputChat.onSubmit.AddListener(OnSubmit);
        //Ŀ���� �Ⱥ��̰�!
        Cursor.visible = false;

        nickColor = new Color(
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f)
       );
    }

    void Update()
    {
        //escŰ�� ������ Ŀ���� Ȱ��ȭ
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        //��򰡸� Ŭ���ϸ� Ŀ���� Ȱ��ȭ
        if(Input.GetMouseButtonDown(0))
        {
            //���࿡ Ŀ���� UI�� ���ٸ�
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                Cursor.visible = false;
            }

            //����϶�
            //if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) == false)
            //{
            //}

        }
    }

    //inputChat���� ���͸� ������ �� ȣ��Ǵ� �Լ�
    void OnSubmit(string s)
    {
        //<color=#FF0000>�г���</color>
        string chatText = "<color=#" + ColorUtility.ToHtmlStringRGB(nickColor) + ">" +
            PhotonNetwork.NickName + "</color>" + " : " + s;

        //1.���� ���ٰ� ���͸� ġ��
        photonView.RPC("RpcAddChat", RpcTarget.All, chatText);

        //4. inputChat�� ������ �ʱ�ȭ
        inputChat.text = "";

        //5. inputChat�� ���õǵ��� �Ѵ�.
        inputChat.ActivateInputField();
    }


    public RectTransform rtScrollView;
    float prevContentH;

    [PunRPC]
    void RpcAddChat(string chat)
    {
        //���� content�� H���� ��������
        prevContentH = trContent.sizeDelta.y;

        //2.ChatItem�� �ϳ� �����. 
        //(�θ� ScrollView - Content)
        GameObject item = Instantiate(chatItemFactory, trContent);

        //3.text ������Ʈ �����ͼ� inputField��
        //������ ����
        ChatItem chatItem = item.GetComponent<ChatItem>();
        chatItem.SetText(chat);

        //4. ������ �ٴڿ� ����־��ٸ�
        StartCoroutine(AutoScrollBottom());
        
    }

    IEnumerator AutoScrollBottom()
    {
        yield return null;
        //��ũ�Ѻ� H���� Content H���� Ŭ ����(��ũ���� ������ ���¶��)
        if(trContent.sizeDelta.y > rtScrollView.sizeDelta.y)
        {            
            //(content y  >= ����Ǳ��� content H - ��ũ�Ѻ� H)
            if (trContent.anchoredPosition.y >= prevContentH - rtScrollView.sizeDelta.y)
            {
                //5. �߰��� ���̸�ŭ content y���� �����ϰڴ�.
                trContent.anchoredPosition = new Vector2(0, trContent.sizeDelta.y - rtScrollView.sizeDelta.y);
            }
        }
    }
}
