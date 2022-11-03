using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public static ConnectionManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    
    public void Save()
    {
        //string convertName = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name));
        //PlayerPrefs.SetString("Name", convertName);
        PlayerPrefs.SetString("Name", inputNickName.text);
        //DontDestroyOnLoad(inputName);
    }
    
    //�г��� InputField
    public InputField inputNickName;
    //���� Button
    public Button btnConnect;

    void Start()
    {
        // �г���(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
        inputNickName.onValueChanged.AddListener(OnValueChanged);
        // �г���(InputField)���� Enter�� ������ ȣ��Ǵ� �Լ� ���
        inputNickName.onSubmit.AddListener(OnSubmit);
        // �г���(InputField)���� Focusing�� �Ҿ����� ȣ��Ǵ� �Լ� ���
        inputNickName.onEndEdit.AddListener(OnEndEdit);
        Save();
    }

    public void OnValueChanged(string s)
    {
        //���࿡ s�� ���̰� 0���� ũ�ٸ�
        //���� ��ư�� Ȱ��ȭ ����         
        //�׷��� �ʴٸ�
        //���� ��ư�� ��Ȱ��ȭ ����
        btnConnect.interactable = s.Length > 0;       

        print("OnValueChanged : " + s);
    }

    public void OnSubmit(string s)
    {
        //���࿡ s�� ���̰� 0���� ũ�ٸ�
        if(s.Length > 0)
        {
            //���� ����!
            OnClickConnect();
        }
        print("OnSubmit : " + s);
    }

    public void OnEndEdit(string s)
    {
        print("OnEndEdit : " + s);
    }

    public void OnClickConnect()
    {
        //���� ���� ��û
        PhotonNetwork.ConnectUsingSettings();
    }


    //������ ���� ���Ӽ����� ȣ��(Lobby�� ������ �� ���� ����)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //������ ���� ���Ӽ����� ȣ��(Lobby�� ������ �� �ִ� ����)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //�� �г��� ����
        PhotonNetwork.NickName = inputNickName.text;//"������_" + Random.Range(1, 1000);
        //�κ� ���� ��û
        PhotonNetwork.JoinLobby();
    }

    //�κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene���� �̵�
        PhotonNetwork.LoadLevel("LobbyScene");
    }


    void Update()
    {
        
    }
}
