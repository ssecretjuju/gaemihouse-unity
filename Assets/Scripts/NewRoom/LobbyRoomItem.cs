using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//포톤없이, 받아온 정보로 제목 + 수익률 배정해주기!! 
public class LobbyRoomItem : MonoBehaviour
{
    //방 제목
    public TMP_Text roomName;

    //방 수익률
    public TMP_Text roomYield;

    //게임오브젝트의 이름을 roomName으로!
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
