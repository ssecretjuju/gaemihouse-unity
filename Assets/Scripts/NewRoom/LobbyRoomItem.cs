using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//포톤없이, 받아온 정보로 제목 + 수익률 배정해주기!! 
public class LobbyRoomItem : MonoBehaviour
{
    //방 제목
    public TMP_Text roomInfo;

    //방 수익률
    public TMP_Text roomYield;

    //게임오브젝트의 이름을 roomName으로!
    public void SetInfo(string roomName, string roomYield)
    {
        //roomName = LobbyRoomList.instance.roomdata.roomTitle;
        //name = roomName;
        roomInfo.text = roomName;
        //roomYield.text = roomYield.ToString();
    }

    //public void SetInfoYield(double roomYield)
    //{
    //    string sYield = roomYield.ToString();

    //    roomYield.text = sYield + "%";

    //    ////desc 설정
    //    //string sreturn = info.CustomProperties["desc"].ToString();
    //    //print("string return : " + sreturn);

    //    //roomDesc.text = sreturn + " %";
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
