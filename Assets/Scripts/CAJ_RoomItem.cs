using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;

public class CAJ_RoomItem : MonoBehaviour
{
    //제목 
    public TMP_Text roomInfo;
    //public TextMesh roomTitle;

    //수익률
    //public TextMesh roomReturn;
    public TMP_Text roomDesc;

    //맵 id
    int map_id;

    //클릭이 되었을 때 호출되는 함수를 가지고있는 변수
    public System.Action<string, int> onClickAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    public void SetInfo(string roomName, int currPlayer)
    {
        //게임오브젝트의 이름을 roomName으로!
        name = roomName;
        //방이름 (0/0)
        //roomTitle.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")"; 
        roomInfo.text = roomName + " (" + currPlayer + "명)"; 
    }

    public void SetInfo(RoomInfo info)
    {
        //SetInfo((string)info.CustomProperties["room_name"], info.PlayerCount, info.MaxPlayers);
        SetInfo((string)info.CustomProperties["room_name"], info.PlayerCount);
        
        //desc 설정
        string sreturn = info.CustomProperties["desc"].ToString();
        print("string return : " + sreturn);

        roomDesc.text = sreturn;
        // float roomreturnturn = float.Parse(roomReturn.text);
        //
        // //수익률 설정
        // roomreturnturn = (float)info.CustomProperties["room_return"];
        //


        //float roomreturn = info.CustomProperties["room_return"];
        //roomReturn.text = (float)info.CustomProperties["room_return"];

        //map id 설정
        //map_id = (int)info.CustomProperties["map_id"];
    }



    public void OnClick()
    {
        //만약에 onClickAction 가 null이 아니라면
        if(onClickAction != null)
        {
            //onClickAction 실행
            onClickAction(name, map_id);
        }

        ////1. InputRoomName 게임오브젝 찾자
        //GameObject go = GameObject.Find("InputRoomName");
        ////2. InputField 컴포넌트 가져오자
        //InputField inputField = go.GetComponent<InputField>();
        ////3. text에 roomName 넣자.
        //inputField.text = name;
    }
}
