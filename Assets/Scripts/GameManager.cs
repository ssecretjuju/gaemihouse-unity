using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;

    //SpawnPos ��
    public Vector3[] spawnPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //PhotonNetwork.Instantiate("Player2", new Vector3(0, 2, 0), Quaternion.identity);
        PhotonNetwork.Instantiate("Player2", new Vector3(-2, 2, -4), Quaternion.identity);
        //OnPhotonSerializeView ȣ�� ��
        PhotonNetwork.SerializationRate = 60;
        //Rpc ȣ�� ��
        PhotonNetwork.SendRate = 60;

        //�ڸ� ��� 
        //1. spawnPos�� ������ �Ҵ�
        spawnPos = new Vector3[4];
        
        //2. ������� (360 / maxPlayer)
        float angle = 360.0f / spawnPos.Length;
        //3. GameManager �߽ɿ��� 5��ŭ ������ ��ġ�� ���
        for(int i = 0; i < spawnPos.Length; i++)
        {
            spawnPos[i] = transform.position + transform.forward * 5;
            transform.Rotate(0, angle, 0);

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = spawnPos[i];
        }

        //���� �濡 �����ִ� �ο����� �̿��ؼ� idx ������
        int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //�÷��̾ �����Ѵ�.
        //PhotonNetwork.Instantiate("Player", spawnPos[idx], Quaternion.identity);
        //PhotonNetwork.Instantiate("Plane", Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        
    }

    //���� �濡 �ִ� Player�� ��Ƴ���.
    public List<PhotonView> players = new List<PhotonView>();
    public void AddPlayer(PhotonView pv)
    {
        players.Add(pv);
        //���࿡ �ο��� �ٵ�������
        if(players.Count == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            //�� ����
            ChangeTurn();
        }
    }

    //�� ����� ȣ�� ���ִ� �Լ�
    public int turnIdx = -1;
    public void ChangeTurn()
    {
        //������ �ƴ϶�� �Լ��� ������!
        if (PhotonNetwork.IsMasterClient == false) return;

        //���� ���ʿ��� �ָ� ���� ���� ���ϰ�!
        if(turnIdx > -1)
        {
            players[turnIdx].RPC("SetMyTurn", RpcTarget.All, false);
        }
        //�̹� ���� ���ʴ�
        turnIdx++;
        turnIdx %= players.Count;
        players[turnIdx].RPC("SetMyTurn", RpcTarget.All, true);
    }

    //�濡 �÷��̾ ���� ���� �� ȣ�����ִ� �Լ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + "�� �濡 ���Խ��ϴ�.");
    }
}
