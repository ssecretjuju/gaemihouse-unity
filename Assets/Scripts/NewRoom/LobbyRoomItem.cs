using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//�������, �޾ƿ� ������ ���� + ���ͷ� �������ֱ�!! 
public class LobbyRoomItem : MonoBehaviour
{
    //�� ����
    public TMP_Text roomName;

    //�� ���ͷ�
    public TMP_Text roomYield;

    //���ӿ�����Ʈ�� �̸��� roomName����!
    public void SetInfoName(string roomName)
    {
        name = roomName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
