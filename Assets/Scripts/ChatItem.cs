using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatItem : MonoBehaviour
{
    //Text
    XRText chatText;
    //RectTransform
    RectTransform rt;
    void Awake()
    {
        chatText = GetComponent<XRText>();
        chatText.onChangedSize = AAA;
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        ////preferredHeight �� ������ �Ǹ� 
        //if(rt.sizeDelta.y != chatText.preferredHeight)
        //{
        //    //height ��������
        //    rt.sizeDelta = new Vector2(rt.sizeDelta.x, chatText.preferredHeight);
        //}
        
    }

    public void SetText(string chat)
    {
        //�ؽ�Ʈ ����
        chatText.text = chat;        
    }

    void AAA()
    {
        print("ũ�Ⱑ ����Ǿ���!!!");
        //height ��������
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, chatText.preferredHeight);
    }
}
