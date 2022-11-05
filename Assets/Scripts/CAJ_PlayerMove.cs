using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CAJ_PlayerMove : MonoBehaviourPun
{
    public Text nickName;
    
    //public PhotonView PV;
    private Transform tr;

    //속력
    public float moveSpeed = 5;
    //characterController 담을 변수
    CharacterController cc;

    //중력
    float gravity = -9.81f;
    //점프파워
    public float jumpPower = 5;
    //y방향 속력
    float yVelocity;

    private Vector3 _input;

    //도착 위치
    Vector3 receivePos;
    //회전되야 하는 값
    Quaternion receiveRot;
    //보간 속력
    public float lerpSpeed = 100;

    //PlayerState 컴포넌트
    //PlayerState playerState;

    public enum State
    {
        Idle,
        Walk,
        Sit,

    }
    public State m_State;
    Animator anim;


    //이모티콘

    public Sprite[] imoticon;
    public GameObject imoticonPrefab;
    private KeyCode[] keyCodes = {
KeyCode.Alpha1,
KeyCode.Alpha2,
KeyCode.Alpha3,
KeyCode.Alpha4,
KeyCode.Alpha5,
KeyCode.Alpha6,
KeyCode.Alpha7,
KeyCode.Alpha8,
KeyCode.Alpha9,
};

    // Start is called before the first frame update
    void Start()
    {
        nickName.text = photonView.Owner.NickName;
        
        //characterController 를 담자
        cc = GetComponent<CharacterController>();
        //PlayerState 컴포넌트 가져오기
        //playerState = GetComponent<PlayerState>();k
        anim = GetComponentInChildren<Animator>();

        // if (photonView.IsMine)
        //     Camera.main.GetComponent<IsometricCamera_YJ>().target = tr.Find("CameraPivot").transform;
        // else
        // {
        //     return;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        //1. WSAD의 신호를 받자.
        float h = Input.GetAxisRaw("Horizontal"); //A : -1, D : 1, 누르지 않으면 : 0
        float v = Input.GetAxisRaw("Vertical");

        if (_input == Vector3.zero)
        {
            anim.SetBool("Walking", false);
            m_State = State.Idle;
        }
        else
        {
            anim.SetBool("Walking", true);
            m_State = State.Walk;
        }

        //2. 받은 신호로 방향을 만든다.
        Vector3 dir = transform.forward * v + transform.right * h; // new Vector3(h, 0, v);
        //방향의 크기를 1로한다.
        dir.Normalize();

        //만약에 바닥에 닿아있다면 yVelocity를 0으로 하자
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        //만약에 스페이바(Jump)를 누르면
        if (Input.GetButtonDown("Jump"))
        {
            //yVelocity에 jumpPower를 셋팅
            yVelocity = jumpPower;
        }

        //yVelocity값을 중력으로 감소시킨다.
        yVelocity += gravity * Time.deltaTime;

        //dir.y에 yVelocity값을 셋팅
        dir.y = yVelocity;

        //3. 그 방향으로 움직이자.
        //P = P0 + vt
        cc.Move(dir * moveSpeed * Time.deltaTime);

        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                // GameObject imo = gameObject.transform.GetChild(0).gameObject;
                // EmoDestory_LYJ emo = imo.GetComponent<EmoDestory_LYJ>();
                // //emo.emoOn = true;
                // //emo.checkTime = 0;
                // SpriteRenderer spriteRenderer = imo.GetComponent<SpriteRenderer>();
                // spriteRenderer.sprite = imoticon[i];
                // imo.transform.parent = gameObject.transform;
            }
        }
    }
}
