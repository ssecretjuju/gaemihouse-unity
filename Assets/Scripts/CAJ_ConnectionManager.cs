using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CAJ_ConnectionManager : MonoBehaviourPunCallbacks
{
    public static CAJ_ConnectionManager instance;
    
    //접속 Button
    public Button btnConnect;

    
    //닉네임 InputField
    public InputField inputNickName;
    
    private void Awake()
    {
        instance = this;
    }
    
    
    public void NickNameSave()
    {
        PlayerPrefs.SetString("Name", inputNickName.text);
    }
    
    public void OnValueChanged(string s)
    {
        //만약에 s의 길이가 0보다 크다면 : 접속 버튼 활성화      
        //그렇지 않다면 : 접속 버튼 비활성화 
        btnConnect.interactable = s.Length > 0;       

        //print("OnValueChanged : " + s);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // 닉네임(InputField)이 변경될때 호출되는 함수 등록
        inputNickName.onValueChanged.AddListener(OnValueChanged);
        // 닉네임(InputField)에서 Enter를 쳤을때 호출되는 함수 등록
        inputNickName.onSubmit.AddListener(OnSubmit);
        // 닉네임(InputField)에서 Focusing을 잃었을때 호출되는 함수 등록
        inputNickName.onEndEdit.AddListener(OnEndEdit);
    }
    
    public void OnSubmit(string s)
    {
        //만약에 s의 길이가 0보다 크다면
        if(s.Length > 0)
        {
            //접속!
            OnClickConnect();
        }
        //print("닉네임 입력 : " + s);
    }
    
    public void OnEndEdit(string s)
    {
        //print("OnEndEdit : " + s);
    }
    
    public void OnClickConnect()
    {
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }
    
    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 없는 상태)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        
        //내 닉네임 설정
        PhotonNetwork.NickName = inputNickName.text;
        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    //로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene으로 이동
        SceneManager.LoadScene("CAJ_LobbyScene");
        //PhotonNetwork.LoadLevel("CAJ_CreateScene");
        print("닉네임 : " + PhotonNetwork.NickName);
    }
}
