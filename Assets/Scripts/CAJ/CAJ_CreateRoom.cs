using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;


//포톤말고, 그냥 Instantiate써서 빈 집을 만듦!
//그리고 받은 데이터 연동해서 RoomItem에 제목, 수익률 연동해줌!
//수익률따라 만들어지는 집 종류 다르게 설정해두고
//빈 집 클릭할 때, 제목 받아서 JoinOrRoomCreate에 넣어주기! (꼭, 필수)

[System.Serializable]
public class Room
{
    public string roomName;
    public int desc;
}

public class CAJ_CreateRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateRoomList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject roomItemFactory;
    public Transform spawnPos;
    void CreateRoomList()
    {
        GameObject go = Instantiate(roomItemFactory, spawnPos);
    }
}
