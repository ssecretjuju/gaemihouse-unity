using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//�������, �޾ƿ� ������ ���� + ���ͷ� �������ֱ�!! 
public class LobbyRoomItem : MonoBehaviour
{
    //�� ����
    public TMP_Text roomInfoTMP;

    //�� ���ͷ�
    public TMP_Text roomYieldTMP;

    //���ӿ�����Ʈ�� �̸��� roomName����!
    public void SetInfoName(string roomName)
    {
        roomInfoTMP.text = roomName;


        //roomName = LobbyRoomList.instance.roomdata.roomTitle;
        //name = roomName;
        //roomYield.text = roomYield.ToString(); , string roomYield
    }

    public void SetInfoYield(double roomYield)
    {
        roomYieldTMP.text = roomYield.ToString() + "%";
    }

    //public void SetInfoYield(double roomYield)
    //{
    //    string sYield = roomYield.ToString();

    //    roomYield.text = sYield + "%";

    //    ////desc ����
    //    //string sreturn = info.CustomProperties["desc"].ToString();
    //    //print("string return : " + sreturn);

    //    //roomDesc.text = sreturn + " %";
    //}
}
