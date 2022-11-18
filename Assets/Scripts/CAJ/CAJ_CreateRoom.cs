using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;


//���渻��, �׳� Instantiate�Ἥ �� ���� ����!
//�׸��� ���� ������ �����ؼ� RoomItem�� ����, ���ͷ� ��������!
//���ͷ����� ��������� �� ���� �ٸ��� �����صΰ�
//�� �� Ŭ���� ��, ���� �޾Ƽ� JoinOrRoomCreate�� �־��ֱ�! (��, �ʼ�)

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
